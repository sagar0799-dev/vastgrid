import React from 'react';

export const TechnicianDashboard: React.FC = () => {
  return (
    <div className="space-y-6 sm:space-y-8 animate-in fade-in slide-in-from-bottom-4 duration-1000 max-w-4xl mx-auto">
      {/* Header Section */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-[clamp(1.75rem,5vw,2.5rem)] font-display font-extrabold text-aura-text-primary tracking-tight">
            Dispatch Queue
          </h1>
          <p className="text-sm sm:text-base text-aura-text-secondary font-medium mt-1">
            Active maintenance routes & <span className="font-bold text-aura-danger">critical alerts</span>
          </p>
        </div>
        <div className="self-start md:self-auto flex items-center gap-3 bg-aura-danger/10 border border-aura-danger/20 px-4 py-2 rounded-2xl">
          <span className="relative flex h-3 w-3">
            <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-aura-danger opacity-75"></span>
            <span className="relative inline-flex rounded-full h-3 w-3 bg-aura-danger"></span>
          </span>
          <span className="text-aura-danger font-bold text-[10px] sm:text-xs uppercase tracking-widest">2 Urgent Calls</span>
        </div>
      </div>

      <div className="grid grid-cols-1 gap-4 sm:gap-6">
        {/* Urgent Job Card */}
        <div className="glass-panel p-6 sm:p-8 rounded-[2rem] border-l-8 border-l-aura-danger group hover:border-aura-danger/30 transition-all duration-500">
          <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 mb-6">
            <div className="flex items-center gap-4">
              <div className="w-12 h-12 sm:w-14 sm:h-14 rounded-2xl bg-aura-danger/10 text-aura-danger flex items-center justify-center group-hover:scale-110 transition-transform duration-500">
                <svg width="24" height="24" className="sm:w-7 sm:h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                  <path d="M10.29 3.86L1.82 18a2 2 0 0 0 1.71 3h16.94a2 2 0 0 0 1.71-3L13.71 3.86a2 2 0 0 0-3.42 0z"></path>
                  <line x1="12" y1="9" x2="12" y2="13"></line>
                  <line x1="12" y1="17" x2="12.01" y2="17"></line>
                </svg>
              </div>
              <div>
                <div className="text-[9px] sm:text-[10px] font-bold text-aura-danger uppercase tracking-[0.2em] mb-1">Emergency Dispatch</div>
                <h3 className="text-xl sm:text-2xl font-display font-bold text-aura-text-primary">Job #A12-Leak</h3>
              </div>
            </div>
            <div className="flex items-center gap-2 bg-aura-background/50 border border-aura-border/50 px-3 py-1.5 sm:px-4 sm:py-2 rounded-xl text-[10px] sm:text-xs font-bold text-aura-text-secondary">
               <svg width="12" height="12" className="sm:w-3.5 sm:h-3.5" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                 <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z"></path>
                 <circle cx="12" cy="10" r="3"></circle>
               </svg>
               Block Alpha • Flat 402
            </div>
          </div>
          
          <p className="text-aura-text-secondary leading-relaxed mb-6 sm:mb-8 text-sm sm:text-lg font-medium">
            Major pipe burst detected in master bathroom. AuraAI Neural Diagnosis confirms high-flow leakage. <span className="text-aura-danger font-bold">Requires immediate valve shutoff.</span>
          </p>
          
          <div className="flex flex-col sm:flex-row gap-3 sm:gap-4">
            <button className="flex-1 bg-aura-primary text-white font-bold py-3.5 sm:py-4 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all duration-300 flex items-center justify-center gap-2 text-sm sm:text-base">
              <svg width="18" height="18" className="sm:w-5 sm:h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                <polygon points="3 11 22 2 13 21 11 13 3 11"></polygon>
              </svg>
              GPS Route
            </button>
            <button className="flex-1 glass-panel text-aura-success font-bold py-3.5 sm:py-4 rounded-2xl border-2 border-aura-success/20 hover:bg-aura-success hover:text-white transition-all duration-300 text-sm sm:text-base">
              Mark Resolved
            </button>
          </div>
        </div>

        {/* Pending Job Card */}
        <div className="glass-panel p-6 sm:p-8 rounded-[2rem] border-l-8 border-l-aura-emergency group hover:border-aura-emergency/30 transition-all duration-500">
          <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 mb-6">
            <div className="flex items-center gap-4">
              <div className="w-12 h-12 sm:w-14 sm:h-14 rounded-2xl bg-aura-emergency/10 text-aura-emergency flex items-center justify-center group-hover:scale-110 transition-transform duration-500">
                <svg width="24" height="24" className="sm:w-7 sm:h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                  <path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"></path>
                  <polyline points="3.27 6.96 12 12.01 20.73 6.96"></polyline>
                  <line x1="12" y1="22.08" x2="12" y2="12"></line>
                </svg>
              </div>
              <div>
                <div className="text-[9px] sm:text-[10px] font-bold text-aura-emergency uppercase tracking-[0.2em] mb-1">Standard Maintenance</div>
                <h3 className="text-xl sm:text-2xl font-display font-bold text-aura-text-primary">Job #B04-HVAC</h3>
              </div>
            </div>
            <div className="flex items-center gap-2 bg-aura-background/50 border border-aura-border/50 px-3 py-1.5 sm:px-4 sm:py-2 rounded-xl text-[10px] sm:text-xs font-bold text-aura-text-secondary">
               <svg width="12" height="12" className="sm:w-3.5 sm:h-3.5" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                 <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z"></path>
                 <circle cx="12" cy="10" r="3"></circle>
               </svg>
               Block Beta • Corridors
            </div>
          </div>
          
          <p className="text-aura-text-secondary leading-relaxed mb-6 sm:mb-8 text-sm sm:text-lg font-medium">
            Routine AC filter replacement for common areas. System efficiency at 82%. Non-critical but recommended within 48 hours.
          </p>
          
          <div className="flex flex-col sm:flex-row gap-3 sm:gap-4">
            <button className="flex-1 bg-aura-primary text-white font-bold py-3.5 sm:py-4 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all duration-300 flex items-center justify-center gap-2 text-sm sm:text-base">
              <svg width="18" height="18" className="sm:w-5 sm:h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                <polygon points="3 11 22 2 13 21 11 13 3 11"></polygon>
              </svg>
              GPS Route
            </button>
            <button className="flex-1 glass-panel text-aura-success font-bold py-3.5 sm:py-4 rounded-2xl border-2 border-aura-success/20 hover:bg-aura-success hover:text-white transition-all duration-300 text-sm sm:text-base">
              Mark Resolved
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
