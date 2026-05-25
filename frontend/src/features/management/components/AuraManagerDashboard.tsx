import React, { useState, useEffect } from 'react';
import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer } from 'recharts';
import { managementApi } from '../api/managementApi';
import { useTicketHub } from '../hooks/useTicketHub';
import { type Ticket } from '../../auraai/types/index';
import { type ManagerStats } from '../types/index';
import { useToast } from '../../../utils/toastManager';
import { createLogger } from '../../../utils/logger';
import { AuraDropdown } from '../../../components/AuraDropdown';

const logger = createLogger('ManagerDashboard');

export const AuraManagerDashboard: React.FC = () => {
  const { addToast } = useToast();
  const [stats, setStats] = useState<ManagerStats[]>([]);
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [loading, setLoading] = useState(true);

  // Form States for Sell Flat (if we re-implement the modal here)
  const [selectedApt, setSelectedApt] = useState<number | ''>('');

  const { newTicket, clearTicket } = useTicketHub('manager');

  useEffect(() => {
    const loadData = async () => {
      try {
        const [statsData, ticketData] = await Promise.all([
          managementApi.getStats(),
          managementApi.getManagedTickets()
        ]);
        setStats(statsData);
        setTickets(ticketData);
        logger.info(`Dashboard loaded with ${ticketData.length} tickets`);
      } catch (e) {
        logger.error('Failed to initialize dashboard', e);
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, []);

  // Real-time Ticket Handling
  useEffect(() => {
    if (newTicket) {
      setTickets(prev => [newTicket, ...prev]);
      addToast(`NEW AI TICKET: ${newTicket.title}`, 'warning');
      clearTicket();
    }
  }, [newTicket, clearTicket, addToast]);

  const COLORS = ['#0d9488', '#f59e0b'];

  if (loading) return <div className="min-h-screen bg-aura-background flex items-center justify-center animate-pulse text-aura-primary font-bold uppercase tracking-widest">Synchronizing AI Queue...</div>;

  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-bottom-4 duration-1000">
      {/* Header */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-[clamp(1.75rem,5vw,2.5rem)] font-display font-extrabold text-aura-text-primary tracking-tight">
            Management <span className="text-aura-primary">Pulse</span>
          </h1>
          <p className="text-sm text-aura-text-secondary font-medium">Real-time portfolio metrics & intelligent maintenance queue.</p>
        </div>
        
        {/* Quick Filter using Custom Dropdown */}
        <div className="w-full md:w-64">
           <AuraDropdown 
             label="Filter Portfolio"
             placeholder="All Blocks"
             value={selectedApt}
             onChange={setSelectedApt}
             options={stats.map(s => ({ value: s.blockName, label: s.blockName, subLabel: `${s.sold} Units Sold` }))}
           />
        </div>
      </div>

      {/* Analytics Bento */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {stats.filter(s => !selectedApt || s.blockName === selectedApt).map((stat, idx) => (
          <div key={idx} className="glass-panel p-8 rounded-[2rem] border-2 border-white/50 group hover:shadow-aura-glow transition-all duration-500 relative overflow-hidden">
            <div className="absolute top-0 right-0 w-24 h-24 bg-aura-primary/5 rounded-full blur-2xl -mr-8 -mt-8" />
            <h3 className="text-xl font-display font-bold text-aura-text-primary mb-4 relative z-10">{stat.blockName}</h3>
            <div className="h-48 relative z-10">
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie data={[{ name: 'Sold', value: stat.sold }, { name: 'Empty', value: stat.unsold }]} innerRadius={50} outerRadius={70} dataKey="value" paddingAngle={5}>
                    <Cell fill={COLORS[0]} className="stroke-white/10" /><Cell fill={COLORS[1]} className="stroke-white/10" />
                  </Pie>
                  <Tooltip 
                    contentStyle={{ backgroundColor: 'rgba(255, 255, 255, 0.8)', backdropFilter: 'blur(8px)', borderRadius: '16px', border: 'none', boxShadow: '0 10px 15px -3px rgba(0, 0, 0, 0.1)' }}
                  />
                </PieChart>
              </ResponsiveContainer>
            </div>
            <div className="flex justify-center gap-4 mt-2">
               <div className="flex items-center gap-1.5">
                  <div className="w-2 h-2 rounded-full bg-aura-primary" />
                  <span className="text-[10px] font-bold text-aura-text-secondary uppercase">Sold: {stat.sold}</span>
               </div>
               <div className="flex items-center gap-1.5">
                  <div className="w-2 h-2 rounded-full bg-aura-emergency" />
                  <span className="text-[10px] font-bold text-aura-text-secondary uppercase">Empty: {stat.unsold}</span>
               </div>
            </div>
          </div>
        ))}
      </div>

      {/* Intelligent AI Maintenance Queue */}
      <div className="glass-panel rounded-[2.5rem] overflow-hidden border-2 border-white/50 shadow-2xl">
        <div className="px-8 py-6 border-b border-aura-border/30 bg-white/10 flex justify-between items-center">
          <h3 className="text-2xl font-display font-extrabold text-aura-text-primary tracking-tight">Maintenance Pulse</h3>
          <span className="text-[10px] font-bold text-aura-danger uppercase tracking-[0.2em] bg-aura-danger/10 px-3 py-1 rounded-lg animate-pulse">Live SignalR Feed</span>
        </div>

        <div className="divide-y divide-aura-border/20">
          {tickets.map((t) => (
            <div key={t.id} className="p-8 hover:bg-white/10 transition-all group">
              <div className="flex flex-col lg:flex-row gap-8">
                 {t.imageUrl && (
                   <div className="w-full lg:w-48 h-48 rounded-3xl overflow-hidden border-2 border-white/40 shadow-aura-soft relative group-hover:scale-[1.02] transition-transform duration-500">
                      <img src={t.imageUrl} className="w-full h-full object-cover" alt="Issue Scan" />
                      <div className="absolute inset-0 bg-gradient-to-t from-black/40 to-transparent opacity-0 group-hover:opacity-100 transition-opacity" />
                   </div>
                 )}
                 <div className="flex-1 space-y-4">
                    <div className="flex items-center justify-between">
                       <h4 className="text-2xl font-display font-bold text-aura-text-primary">{t.title}</h4>
                       <span className={`px-4 py-1.5 rounded-full text-[10px] font-bold uppercase tracking-widest ${t.severity === 'Big' ? 'bg-aura-danger/10 text-aura-danger' : 'bg-aura-success/10 text-aura-success'}`}>
                          AI {t.severity} Escalation
                       </span>
                    </div>
                    <p className="text-sm text-aura-text-secondary leading-relaxed italic bg-white/40 p-4 rounded-2xl border border-white/40">"{t.description}"</p>
                    
                    <div className="grid grid-cols-2 md:grid-cols-4 gap-6 pt-4 border-t border-aura-border/20">
                       <div>
                          <div className="text-[9px] font-bold text-aura-text-secondary uppercase tracking-wider">Origin Resident</div>
                          <div className="text-xs font-bold text-aura-text-primary">Resident ID: {t.id}</div>
                       </div>
                       <div>
                          <div className="text-[9px] font-bold text-aura-text-secondary uppercase tracking-wider">Current Status</div>
                          <div className="text-xs font-bold text-aura-primary">{t.status}</div>
                       </div>
                       <button className="col-span-2 bg-aura-primary text-white text-xs font-bold py-3 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all">
                          Dispatch Responder
                       </button>
                    </div>
                 </div>
              </div>
            </div>
          ))}
          {tickets.length === 0 && (
            <div className="py-24 text-center text-aura-text-secondary font-medium italic opacity-50">No active maintenance alerts in the queue.</div>
          )}
        </div>
      </div>
    </div>
  );
};
