import React, { useState, useEffect } from 'react';
import { type VisitorLog } from '../types/index';

export const VisitorHistory: React.FC = () => {
  const [history, setHistory] = useState<VisitorLog[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchHistory = async () => {
      try {
        const data = await fetch('/api/visitors/history', {
          headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
        }).then(res => res.json());
        setHistory(data);
      } catch (e) {
        console.error('Failed to load history', e);
      } finally {
        setLoading(false);
      }
    };
    fetchHistory();
  }, []);

  if (loading) return <div className="animate-pulse h-40 bg-white/10 rounded-3xl" />;

  return (
    <div className="glass-panel rounded-[2rem] overflow-hidden mt-8">
      <div className="px-8 py-6 border-b border-aura-border/30 bg-white/10 flex justify-between items-center">
        <h3 className="text-xl font-display font-bold text-aura-text-primary text-[clamp(1.1rem,3vw,1.5rem)]">Visitor Activity</h3>
        <span className="text-[10px] font-bold text-aura-primary uppercase tracking-widest bg-aura-primary/10 px-3 py-1 rounded-lg">Live Audit</span>
      </div>
      <div className="overflow-x-auto">
        <table className="w-full text-left text-sm">
          <thead className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-[0.2em] bg-white/5">
            <tr>
              <th className="px-8 py-4">Visitor</th>
              <th className="px-8 py-4">Purpose</th>
              <th className="px-8 py-4 text-center">Status</th>
              <th className="px-8 py-4 text-right">Arrived</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-aura-border/20">
            {history.map((log) => (
              <tr key={log.id} className="hover:bg-white/5 transition-colors">
                <td className="px-8 py-5">
                   <div className="font-bold text-aura-text-primary">{log.visitorName}</div>
                </td>
                <td className="px-8 py-5 text-aura-text-secondary font-medium">{log.purpose}</td>
                <td className="px-8 py-5">
                   <div className="flex justify-center">
                     <span className={`px-3 py-1 rounded-full text-[9px] font-bold uppercase tracking-wider ${
                       log.status === 'Approved' ? 'bg-aura-success/10 text-aura-success' : 
                       log.status === 'Denied' ? 'bg-aura-danger/10 text-aura-danger' : 'bg-aura-emergency/10 text-aura-emergency'
                     }`}>
                       {log.status}
                     </span>
                   </div>
                </td>
                <td className="px-8 py-5 text-right font-mono text-[10px] text-aura-text-secondary opacity-60">
                   {new Date(log.timestamp).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                </td>
              </tr>
            ))}
            {history.length === 0 && (
              <tr>
                <td colSpan={4} className="px-8 py-10 text-center text-aura-text-secondary italic opacity-50">No recent visitor activity recorded.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};
