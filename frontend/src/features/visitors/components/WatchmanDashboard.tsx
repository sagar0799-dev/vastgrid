import React, { useState, useEffect } from 'react';
import { visitorApi } from '../api/visitorApi';
import { type VisitorLog } from '../types/index';
import { useVisitorHub } from '../hooks/useVisitorHub';
import { useToast } from '../../../utils/toastManager';
import { createLogger } from '../../../utils/logger';
import { AuraDropdown } from '../../../components/AuraDropdown';

const logger = createLogger('WatchmanDashboard');

export const WatchmanDashboard: React.FC = () => {
  const { addToast } = useToast();
  const [apartments, setApartments] = useState<any[]>([]);
  const [residents, setResidents] = useState<any[]>([]);
  const [selectedApt, setSelectedApt] = useState<number | ''>('');
  const [selectedResident, setSelectedResident] = useState<number | ''>('');
  const [visitorName, setVisitorName] = useState('');
  const [purpose, setPurpose] = useState('');
  const [pendingLogs, setPendingLogs] = useState<VisitorLog[]>([]);
  const [submitting, setSubmitting] = useState(false);

  const { statusUpdate, clearStatus } = useVisitorHub('watchman');

  // Load Initial Data
  useEffect(() => {
    logger.debug('Initializing dashboard data');
    
    // Fetch Apartments
    fetch('/api/managerdashboard/apartments', {
      headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
    }).then(res => {
      if (!res.ok) throw new Error(`HTTP ${res.status}`);
      return res.json();
    }).then(data => {
      setApartments(data);
      logger.info(`Loaded ${data.length} apartment blocks`);
    }).catch(e => logger.error('Failed to load apartments', e));

    const fetchPending = async () => {
      try {
        const logs = await visitorApi.getPending();
        setPendingLogs(logs);
        logger.debug(`Synchronized ${logs.length} pending requests`);
      } catch (e) {
        logger.error('Failed to sync pending queue', e);
      }
    };
    fetchPending();
  }, []);

  // Sync Status Updates via SignalR
  useEffect(() => {
    if (statusUpdate) {
      const log = pendingLogs.find(p => p.id === statusUpdate.logId);
      logger.info(`Live Status update received for LOG-${statusUpdate.logId}`, statusUpdate);
      
      addToast(
        `Visitor ${log?.visitorName || ''} was ${statusUpdate.status}`,
        statusUpdate.status === 'Approved' ? 'success' : 'danger'
      );

      setPendingLogs(prev => prev.filter(p => p.id !== statusUpdate.logId));
      clearStatus();
    }
  }, [statusUpdate, clearStatus, pendingLogs, addToast]);

  // Load Residents when Apartment Changes
  useEffect(() => {
    if (selectedApt) {
       logger.debug(`Fetching residents for block ${selectedApt}`);
       fetch('/api/managerdashboard/residents', {
         headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
       }).then(res => {
         if (!res.ok) throw new Error(`HTTP ${res.status}`);
         return res.json();
       }).then(data => {
         setResidents(data);
         logger.info(`Found ${data.length} residents in selected block`);
       }).catch(e => logger.error('Failed to load residents', e));
    }
  }, [selectedApt]);

  const handleCheckIn = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedResident || !visitorName) return;
    
    logger.info(`Initiating check-in for ${visitorName}`);
    setSubmitting(true);
    
    try {
      const newLog = await visitorApi.checkIn({
        visitorName,
        purpose,
        residentId: Number(selectedResident)
      });
      
      setPendingLogs(prev => [newLog, ...prev]);
      setVisitorName('');
      setPurpose('');
      
      addToast(`Request sent to ${newLog.residentName}`, 'info');
      logger.info(`Check-in LOG-${newLog.id} dispatched successfully`);
    } catch (err) {
      logger.error('Dispatch failed', err);
      addToast('Security Dispatch Failed. Please retry.', 'danger');
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-bottom-4 duration-1000 max-w-5xl mx-auto">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-[clamp(1.75rem,5vw,2.5rem)] font-display font-extrabold text-aura-text-primary tracking-tight">
            Gate <span className="text-aura-primary">Security</span>
          </h1>
          <p className="text-sm sm:text-base text-aura-text-secondary font-medium mt-1">
            Real-time visitor dispatch & Resident authorization hub.
          </p>
        </div>
        <div className="flex items-center gap-2 bg-aura-primary/10 border border-aura-primary/20 px-4 py-2 rounded-2xl">
           <span className="w-2 h-2 rounded-full bg-aura-primary animate-pulse" />
           <span className="text-aura-primary font-bold text-[10px] uppercase tracking-widest">Post Alpha Active</span>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
        {/* Check-In Form */}
        <div className="lg:col-span-1 space-y-6">
          <div className="glass-panel p-8 rounded-[2.5rem] border-2 border-white/50">
            <h3 className="text-xl font-display font-bold text-aura-text-primary mb-6">Visitor Entry</h3>
            <form onSubmit={handleCheckIn} className="space-y-6">
              <AuraDropdown 
                label="Apartment Block"
                placeholder="Select Block"
                value={selectedApt}
                onChange={setSelectedApt}
                options={apartments.map(a => ({ value: a.id, label: a.blockName, subLabel: `${a.totalFlats} Units` }))}
              />

              <AuraDropdown 
                label="Resident / Flat"
                placeholder="Select Resident"
                value={selectedResident}
                onChange={setSelectedResident}
                disabled={!selectedApt}
                options={residents.map(r => ({ value: r.id, label: `${r.firstName} ${r.lastName}`, subLabel: `Flat ${r.apartment}` }))}
              />

              <div className="space-y-2">
                <label className="text-[10px] font-bold text-aura-primary uppercase tracking-widest ml-1">Visitor Name</label>
                <input 
                  type="text" 
                  value={visitorName} 
                  onChange={e => setVisitorName(e.target.value)}
                  placeholder="Full Name"
                  className="w-full bg-white/50 border-2 border-aura-border/30 rounded-2xl px-4 py-3 text-sm font-bold focus:border-aura-primary/50 outline-none transition-all"
                />
              </div>

              <div className="space-y-2">
                <label className="text-[10px] font-bold text-aura-primary uppercase tracking-widest ml-1">Purpose</label>
                <input 
                  type="text" 
                  value={purpose} 
                  onChange={e => setPurpose(e.target.value)}
                  placeholder="e.g. Courier, Guest"
                  className="w-full bg-white/50 border-2 border-aura-border/30 rounded-2xl px-4 py-3 text-sm font-bold focus:border-aura-primary/50 outline-none transition-all"
                />
              </div>

              <button 
                type="submit"
                disabled={submitting || !selectedResident || !visitorName}
                className="w-full bg-aura-primary text-white font-bold py-4 rounded-2xl shadow-aura-soft hover:shadow-aura-glow active:scale-95 transition-all disabled:opacity-50"
              >
                {submitting ? 'Dispatching...' : 'Request Entry'}
              </button>
            </form>
          </div>
        </div>

        {/* Real-Time Queue */}
        <div className="lg:col-span-2 space-y-6">
          <div className="glass-panel p-8 rounded-[2.5rem] border-2 border-white/50 min-h-[400px]">
            <h3 className="text-xl font-display font-bold text-aura-text-primary mb-6 flex items-center gap-2">
              Live Queue
              <span className="text-[10px] bg-aura-emergency/10 text-aura-emergency px-2 py-1 rounded-lg uppercase">{pendingLogs.length} Pending</span>
            </h3>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              {pendingLogs.map((log) => (
                <div key={log.id} className="p-6 bg-white/30 rounded-3xl border border-white/40 flex flex-col group animate-in slide-in-from-right-4 duration-500">
                   <div className="flex justify-between items-start mb-4">
                      <div>
                        <div className="text-lg font-bold text-aura-text-primary">{log.visitorName}</div>
                        <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest">Purpose: {log.purpose}</div>
                      </div>
                      <div className="w-8 h-8 rounded-full bg-aura-emergency/10 text-aura-emergency flex items-center justify-center animate-pulse">
                         <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M12 2v4m0 14v4m10-12h-4M6 12H2m17.657-7.657l-2.828 2.828M7.071 16.929l-2.828 2.828M17.657 19.657l-2.828-2.828M7.071 7.071L4.243 4.243"/></svg>
                      </div>
                   </div>
                   
                   <div className="mt-auto space-y-3 pt-4 border-t border-aura-border/20">
                      <div className="text-[10px] font-bold text-aura-text-secondary uppercase">Waiting for: <span className="text-aura-text-primary">{log.residentName} ({log.apartmentBlock})</span></div>
                      <div className="flex items-center justify-between">
                         <div className="text-[10px] font-medium text-aura-text-secondary opacity-60">No response?</div>
                         <a href={`tel:${log.residentPhone}`} className="text-xs font-bold text-aura-primary hover:underline flex items-center gap-1">
                            <svg width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.79 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"/></svg>
                            Call Resident
                         </a>
                      </div>
                   </div>
                </div>
              ))}
              {pendingLogs.length === 0 && (
                <div className="col-span-full py-20 text-center text-aura-text-secondary font-medium italic opacity-40">
                  Secure area. No active visitor requests.
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
