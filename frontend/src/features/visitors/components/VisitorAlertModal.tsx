import React from 'react';
import { type VisitorLog } from '../types/index';
import { visitorApi } from '../api/visitorApi';

interface VisitorAlertModalProps {
  request: VisitorLog;
  onClose: () => void;
}

export const VisitorAlertModal: React.FC<VisitorAlertModalProps> = ({ request, onClose }) => {
  const handleResponse = async (status: 'Approved' | 'Denied') => {
    try {
      await visitorApi.respond(request.id, status);
      onClose();
    } catch (e) {
      alert('Action failed. Please try again.');
    }
  };

  return (
    <div className="fixed inset-0 z-[200] flex items-center justify-center p-4 bg-aura-text-primary/40 backdrop-blur-md animate-in fade-in duration-300">
      <div className="glass-panel w-full max-w-md rounded-[3rem] p-10 shadow-2xl border-2 border-white/50 animate-in zoom-in-95 duration-500 text-center relative overflow-hidden">
        {/* Pulsing Aura */}
        <div className="absolute top-0 left-0 w-full h-2 bg-gradient-to-r from-aura-primary to-aura-primary-light animate-pulse" />
        
        <div className="w-20 h-20 rounded-full bg-aura-primary/10 text-aura-primary flex items-center justify-center mx-auto mb-8 shadow-aura-soft">
           <svg width="40" height="40" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
             <path d="M16 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
             <circle cx="8.5" cy="7" r="4"></circle>
             <line x1="20" y1="8" x2="20" y2="14"></line>
             <line x1="23" y1="11" x2="17" y2="11"></line>
           </svg>
        </div>

        <h2 className="text-3xl font-display font-extrabold text-aura-text-primary tracking-tight mb-2">Visitor at Gate</h2>
        <p className="text-aura-text-secondary font-medium mb-8">
          <span className="text-aura-primary font-bold">{request.visitorName}</span> is requesting entry for <span className="font-bold text-aura-text-primary">{request.purpose}</span>.
        </p>

        <div className="grid grid-cols-2 gap-4">
          <button 
            onClick={() => handleResponse('Denied')}
            className="py-4 rounded-2xl border-2 border-aura-danger/20 text-aura-danger font-bold hover:bg-aura-danger hover:text-white transition-all active:scale-95 shadow-sm"
          >
            Deny Access
          </button>
          <button 
            onClick={() => handleResponse('Approved')}
            className="py-4 rounded-2xl bg-aura-primary text-white font-bold hover:shadow-aura-glow transition-all active:scale-95 shadow-aura-soft"
          >
            Approve Entry
          </button>
        </div>

        <p className="mt-8 text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest opacity-40">Security Event ID: LOG-{request.id}</p>
      </div>
    </div>
  );
};
