import React, { useEffect, useState } from 'react';
import { type Ticket } from '../types/index';
import { ticketApi } from '../api/ticketApi';

export const ResidentTicketHistory: React.FC = () => {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchTickets = async () => {
      try {
        const data = await ticketApi.getResidentTickets();
        setTickets(data);
      } catch (e) {
        console.error('Failed to load tickets', e);
      } finally {
        setLoading(false);
      }
    };
    fetchTickets();
  }, []);

  if (loading) return <div className="h-48 bg-white/10 rounded-3xl animate-pulse mt-8" />;

  return (
    <div className="glass-panel rounded-[2rem] overflow-hidden mt-8 border-2 border-white/50">
      <div className="px-8 py-6 border-b border-aura-border/30 bg-white/10 flex justify-between items-center">
        <h3 className="text-xl font-display font-bold text-aura-text-primary tracking-tight">Maintenance History</h3>
        <span className="text-[10px] font-bold text-aura-primary uppercase tracking-widest bg-aura-primary/10 px-3 py-1 rounded-lg">Real-Time Sync</span>
      </div>
      
      <div className="divide-y divide-aura-border/20">
        {tickets.map((t) => (
          <div key={t.id} className="p-6 hover:bg-white/10 transition-colors group cursor-default">
            <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4">
              <div className="flex items-center gap-4">
                 <div className={`w-12 h-12 rounded-xl flex items-center justify-center flex-none ${t.status === 'Resolved' ? 'bg-aura-success/10 text-aura-success' : 'bg-aura-emergency/10 text-aura-emergency'}`}>
                   <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                     <path d="M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"/>
                   </svg>
                 </div>
                 <div>
                    <div className="text-lg font-bold text-aura-text-primary group-hover:text-aura-primary transition-colors">{t.title}</div>
                    <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest">
                       Reference: #T-{t.id.toString().padStart(4, '0')} • {new Date(t.createdAt).toLocaleDateString()}
                    </div>
                 </div>
              </div>
              
              <div className="flex items-center gap-3 self-end md:self-auto">
                 <span className={`px-4 py-1.5 rounded-full text-[9px] font-bold uppercase tracking-wider ${
                   t.status === 'Resolved' ? 'bg-aura-success/10 text-aura-success' : 
                   t.status === 'InProgress' ? 'bg-aura-primary/10 text-aura-primary' : 'bg-aura-emergency/10 text-aura-emergency'
                 }`}>
                   {t.status}
                 </span>
                 <button className="w-10 h-10 rounded-full glass-panel flex items-center justify-center text-aura-text-secondary hover:text-aura-primary transition-all">
                    <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><polyline points="9 18 15 12 9 6"/></svg>
                 </button>
              </div>
            </div>
            
            {t.diagnosisResult && (
               <div className="mt-4 ml-16 p-4 bg-white/30 rounded-2xl border border-white/20 text-[11px] font-medium text-aura-text-secondary italic">
                  AI Summary: "{t.diagnosisResult.substring(0, 120)}..."
               </div>
            )}
          </div>
        ))}
        
        {tickets.length === 0 && (
          <div className="py-20 text-center text-aura-text-secondary font-medium italic opacity-50">
             No maintenance tickets on record for this unit.
          </div>
        )}
      </div>
    </div>
  );
};
