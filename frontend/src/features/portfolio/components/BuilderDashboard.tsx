import React from 'react';
import { usePortfolio } from '../hooks/usePortfolio';

export const BuilderDashboard: React.FC = () => {
  const { data, loading, error, refresh } = usePortfolio();

  if (loading) {
    return (
      <div className="flex flex-col items-center justify-center min-h-[400px] gap-4">
        <div className="w-12 h-12 border-4 border-aura-primary/20 border-t-aura-primary rounded-full animate-spin" />
        <p className="text-aura-text-secondary font-bold text-xs uppercase tracking-[0.2em] animate-pulse">
          Synchronizing Global Portfolio...
        </p>
      </div>
    );
  }

  if (error || !data) {
    return (
      <div className="p-8 glass-panel rounded-3xl text-center space-y-4">
        <div className="text-4xl">⚠️</div>
        <h3 className="text-xl font-bold text-aura-text-primary">Portfolio Sync Failed</h3>
        <p className="text-aura-text-secondary max-w-xs mx-auto">{error || 'Data unavailable.'}</p>
        <button 
          onClick={refresh}
          className="bg-aura-primary text-white font-bold py-2 px-6 rounded-xl shadow-aura-soft active:scale-95 transition-all"
        >
          Retry Connection
        </button>
      </div>
    );
  }

  return (
    <div className="space-y-8 animate-in fade-in slide-in-from-bottom-4 duration-1000">
      {/* Header Section */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-[clamp(1.75rem,5vw,2.5rem)] font-display font-extrabold text-aura-text-primary tracking-tight">
            Portfolio <span className="text-aura-primary">Pulse</span>
          </h1>
          <p className="text-sm sm:text-base text-aura-text-secondary font-medium mt-1">
            Global oversight for <span className="font-bold text-aura-text-primary">{data.companyName}</span>
          </p>
        </div>
        <div className="flex gap-3">
          <button className="bg-aura-primary text-white font-bold py-3 px-6 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all duration-300 flex items-center gap-2">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
            <span className="hidden sm:inline">Initialize Project</span>
          </button>
        </div>
      </div>

      {/* Global Bento Box Stats */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 sm:gap-6">
        {[
          { label: 'Total Blocks', value: data.summary.totalBlocks, color: 'aura-primary', icon: 'M19 21V5a2 2 0 0 0-2-2H7a2 2 0 0 0-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1v1H9V7zm5 0h1v1h-1V7zm-5 4h1v1H9v-1zm5 0h1v1h-1v-1zm-5 4h1v1H9v-1zm5 0h1v1h-1v-1z' },
          { label: 'Active Residents', value: data.summary.totalResidents, color: 'aura-success', icon: 'M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2M9 7a4 4 0 1 1 0-8 4 4 0 0 1 0 8zm7 0a3 3 0 1 1 0-6 3 3 0 0 1 0 6zm3 16v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75' },
          { label: 'Avg Occupancy', value: `${data.summary.averageOccupancy}%`, color: 'aura-primary', icon: 'M12 2v20M2 12h20' },
          { label: 'Est. Revenue', value: `$${data.summary.totalEstimatedRevenue.toLocaleString()}`, color: 'aura-success', icon: 'M12 1v22M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6' },
        ].map((stat, i) => (
          <div key={i} className="glass-panel p-6 sm:p-8 rounded-[2rem] flex flex-col group hover:shadow-aura-glow transition-all duration-500">
             <div className={`w-10 h-10 rounded-xl bg-${stat.color}/10 text-${stat.color} flex items-center justify-center mb-4 group-hover:scale-110 transition-transform`}>
               <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d={stat.icon} /></svg>
             </div>
             <div className="text-2xl sm:text-3xl font-display font-extrabold text-aura-text-primary tracking-tight">{stat.value}</div>
             <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-[0.2em] mt-1">{stat.label}</div>
          </div>
        ))}
      </div>

      {/* Portfolio Grid */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {data.blocks.map((block) => (
          <div key={block.id} className="glass-panel p-8 rounded-[2.5rem] flex flex-col group hover:border-aura-primary/30 transition-all duration-500 border-2 border-white/50 relative overflow-hidden">
             {/* Background Decoration */}
             <div className={`absolute top-0 right-0 w-32 h-32 bg-aura-${block.healthStatus === 'Stable' ? 'success' : block.healthStatus === 'Warning' ? 'emergency' : 'danger'}/5 rounded-full blur-3xl -mr-16 -mt-16`} />
             
             <div className="flex justify-between items-start mb-8 relative z-10">
               <div>
                 <h3 className="text-2xl font-display font-bold text-aura-text-primary">{block.blockName}</h3>
                 <div className="flex items-center gap-2 mt-1">
                    <span className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest">Global ID: RE-{block.id.toString().padStart(3, '0')}</span>
                 </div>
               </div>
               <div className={`px-4 py-1.5 rounded-full bg-${block.healthStatus === 'Stable' ? 'aura-success' : 'aura-emergency'}/10 border border-${block.healthStatus === 'Stable' ? 'aura-success' : 'aura-emergency'}/20 text-${block.healthStatus === 'Stable' ? 'aura-success' : 'aura-emergency'} text-[10px] font-bold uppercase tracking-wider`}>
                 {block.healthStatus}
               </div>
             </div>

             <div className="grid grid-cols-2 gap-6 mb-8 relative z-10">
                <div className="space-y-1">
                   <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest">Occupancy</div>
                   <div className="text-lg font-bold text-aura-text-primary">{block.occupiedFlats} / {block.totalFlats} Units</div>
                   <div className="w-full h-1.5 bg-aura-border/30 rounded-full overflow-hidden">
                      <div className="h-full bg-aura-primary rounded-full transition-all duration-1000" style={{ width: `${block.occupancyRate}%` }} />
                   </div>
                </div>
                <div className="space-y-1">
                   <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest">Monthly Est.</div>
                   <div className="text-lg font-bold text-aura-success">${block.estimatedMonthlyRevenue.toLocaleString()}</div>
                   <div className="text-[10px] font-medium text-aura-text-secondary">Next Payout: June 1st</div>
                </div>
             </div>

             <div className="mt-auto flex items-center justify-between pt-6 border-t border-aura-border/30 relative z-10">
                <div className="flex items-center gap-2">
                   <div className="w-8 h-8 rounded-lg bg-aura-primary/10 flex items-center justify-center text-aura-primary">
                     <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M14.7 6.3a1 1 0 0 0 0 1.4l1.6 1.6a1 1 0 0 0 1.4 0l3.77-3.77a6 6 0 0 1-7.94 7.94l-6.91 6.91a2.12 2.12 0 0 1-3-3l6.91-6.91a6 6 0 0 1 7.94-7.94l-3.76 3.76z"/></svg>
                   </div>
                   <span className="text-xs font-bold text-aura-text-primary">{block.openTickets} Open Tickets</span>
                </div>
                <button className="text-aura-primary font-bold text-xs uppercase tracking-[0.1em] hover:translate-x-1 transition-transform flex items-center gap-1">
                   Block Details
                   <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"><polyline points="9 18 15 12 9 6"/></svg>
                </button>
             </div>
          </div>
        ))}
      </div>
    </div>
  );
};
