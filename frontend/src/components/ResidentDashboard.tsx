import React from 'react';
import { useVisitorHub } from '../features/visitors/hooks/useVisitorHub';
import { useIdentity } from '../features/identity/hooks/useIdentity';
import { VisitorAlertModal } from '../features/visitors/components/VisitorAlertModal';
import { VisitorHistory } from '../features/visitors/components/VisitorHistory';
import { AuraAIScanner } from '../features/auraai/components/AuraAIScanner';
import { ResidentTicketHistory } from '../features/auraai/components/ResidentTicketHistory';
import { createLogger } from '../utils/logger';

const logger = createLogger('ResidentDashboard');

export const ResidentDashboard: React.FC = () => {
  const { user } = useIdentity();
  const { pendingRequests, removeRequest } = useVisitorHub('resident', user?.id);

  React.useEffect(() => {
    logger.info(`Resident Portal initialized for session ${user?.id}`);
  }, [user]);

  return (
    <div className="space-y-6 sm:space-y-8 animate-in fade-in slide-in-from-bottom-4 duration-1000">
      {/* Real-Time Visitor Alerts (Handles multiple requests via queue) */}
      {pendingRequests.map((request) => (
        <VisitorAlertModal 
          key={request.id}
          request={request} 
          onClose={() => removeRequest(request.id)} 
        />
      ))}

      {/* Welcome Section */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-[clamp(1.75rem,5vw,2.5rem)] font-display font-extrabold text-aura-text-primary tracking-tight">
            Welcome Home, <span className="text-aura-primary">{user?.firstName || 'Sagar'}</span>
          </h1>
          <p className="text-sm sm:text-base text-aura-text-secondary font-medium mt-1">
            Everything is running smoothly at <span className="font-bold text-aura-text-primary">Aura Heights • Flat 402</span>
          </p>
        </div>
        <div className="self-start md:self-auto flex items-center gap-3 bg-aura-success/10 border border-aura-success/20 px-4 py-2 rounded-2xl">
          <span className="relative flex h-3 w-3">
            <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-aura-success opacity-75"></span>
            <span className="relative inline-flex rounded-full h-3 w-3 bg-aura-success"></span>
          </span>
          <span className="text-aura-success font-bold text-[10px] sm:text-xs uppercase tracking-widest">System Secure</span>
        </div>
      </div>

      {/* Primary Actions Grid */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 sm:gap-6">
        
        {/* AuraAI Scanner Card - Full Width on Mobile/Tablet */}
        <div className="md:col-span-2 lg:col-span-1 order-first lg:order-none">
          <AuraAIScanner />
        </div>

        {/* Quick Access Card */}
        <div className="glass-panel p-6 sm:p-8 rounded-[2rem] flex flex-col group hover:border-aura-primary/30 transition-all duration-500">
          <div className="w-12 h-12 sm:w-14 sm:h-14 rounded-2xl bg-aura-primary/10 text-aura-primary flex items-center justify-center mb-4 sm:mb-6 group-hover:scale-110 group-hover:bg-aura-primary group-hover:text-white transition-all duration-500 shadow-aura-soft">
            <svg width="24" height="24" className="sm:w-7 sm:h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
              <rect x="3" y="11" width="18" height="11" rx="2" ry="2"></rect>
              <path d="M7 11V7a5 5 0 0 1 10 0v4"></path>
            </svg>
          </div>
          <h3 className="text-lg sm:text-xl font-display font-bold text-aura-text-primary mb-2">Guest Access</h3>
          <p className="text-xs sm:text-sm text-aura-text-secondary leading-relaxed mb-6 sm:mb-8 flex-1">
            Instantly generate encrypted visitor passes with dynamic QR vectors for your expected guests.
          </p>
          <button className="w-full bg-aura-primary text-white font-bold py-3 sm:py-3.5 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all duration-300 text-sm sm:text-base">
            Register Visitor
          </button>
        </div>

        {/* AI Telemetry Card */}
        <div className="glass-panel p-6 sm:p-8 rounded-[2rem] flex flex-col group hover:border-aura-success/30 transition-all duration-500 shadow-aura-soft">
          <div className="w-12 h-12 sm:w-14 sm:h-14 rounded-2xl bg-aura-success/10 text-aura-success flex items-center justify-center mb-4 sm:mb-6 group-hover:scale-110 group-hover:bg-aura-success group-hover:text-white transition-all duration-500">
            <svg width="24" height="24" className="sm:w-7 sm:h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
              <path d="M22 12h-4l-3 9L9 3l-3 9H2"></path>
            </svg>
          </div>
          <h3 className="text-lg sm:text-xl font-display font-bold text-aura-text-primary mb-2">AuraAI Pulse</h3>
          <p className="text-xs sm:text-sm text-aura-text-secondary leading-relaxed mb-6 sm:mb-8 flex-1">
            Monitor real-time sweeping laser scan line feedback and home diagnostic telemetry from AuraAI.
          </p>
          <button className="w-full bg-aura-success text-white font-bold py-3 sm:py-3.5 rounded-2xl shadow-aura-soft hover:shadow-emerald-500/20 hover:scale-[1.02] active:scale-[0.98] transition-all duration-300 text-sm sm:text-base">
            View Telemetry
          </button>
        </div>
      </div>

      {/* Visitor Activity Audit */}
      <VisitorHistory />

      {/* Intelligent Maintenance History */}
      <ResidentTicketHistory />
    </div>
  );
};
