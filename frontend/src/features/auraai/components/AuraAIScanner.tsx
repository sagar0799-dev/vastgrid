import React, { useState } from 'react';
import { useAuraAI } from '../hooks/useAuraAI';
import { useToast } from '../../../utils/toastManager';
import { createLogger } from '../../../utils/logger';

const logger = createLogger('AuraAI');

export const AuraAIScanner: React.FC = () => {
  const { addToast } = useToast();
  const { startAnalysis, analyzing, diagnosis, lastRaisedTicket, error, reset } = useAuraAI();
  const [preview, setPreview] = useState<string | null>(null);

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      logger.info('User initiated hazard scan');
      const reader = new FileReader();
      reader.onloadend = () => {
        const base64 = reader.result as string;
        setPreview(base64);
        startAnalysis(base64);
      };
      reader.readAsDataURL(file);
    }
  };

  // Sync error to Toast
  React.useEffect(() => {
    if (error) {
      logger.error('Neural analysis failed', error);
      addToast('AI Analysis Failed. Please try a clearer photo.', 'danger');
    }
  }, [error, addToast]);

  // Success Toast for Tickets
  React.useEffect(() => {
    if (lastRaisedTicket) {
      logger.info(`Automated ticket T-${lastRaisedTicket.id} raised successfully`);
      addToast('Emergency Ticket Raised Automatically.', 'success');
    }
  }, [lastRaisedTicket, addToast]);

  return (
    <div className="glass-panel p-8 rounded-[2.5rem] relative overflow-hidden group border-2 border-white/50">
      {/* Scanning Animation Overlays */}
      {analyzing && (
        <div className="absolute inset-0 z-20 pointer-events-none overflow-hidden">
          <div className="w-full h-1 bg-gradient-to-r from-transparent via-aura-primary to-transparent absolute top-0 animate-scan-line" />
          <div className="w-full h-full bg-aura-primary/5 animate-pulse" />
        </div>
      )}

      <div className="flex flex-col items-center text-center space-y-6">
        {!diagnosis && !analyzing ? (
          <>
            <div className="w-20 h-20 rounded-3xl bg-aura-primary/10 text-aura-primary flex items-center justify-center group-hover:scale-110 transition-transform duration-500 shadow-aura-soft">
               <svg width="40" height="40" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                 <path d="M23 19a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2h4l2-3h6l2 3h4a2 2 0 0 1 2 2z"/><circle cx="12" cy="13" r="4"/>
               </svg>
            </div>
            <div>
              <h3 className="text-2xl font-display font-extrabold text-aura-text-primary tracking-tight">Neural Diagnosis</h3>
              <p className="text-sm text-aura-text-secondary max-w-xs mx-auto mt-1">Upload a photo of the hazard for instant AI analysis and DIY resolution.</p>
            </div>
            <label className="cursor-pointer bg-aura-primary text-white font-bold py-4 px-10 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.98] transition-all">
               Initialize Scan
               <input type="file" accept="image/*" className="hidden" onChange={handleFileChange} />
            </label>
          </>
        ) : analyzing ? (
          <>
            <div className="w-48 h-48 rounded-[2rem] border-4 border-aura-primary/20 p-2 relative overflow-hidden text-[0px]">
               <img src={preview!} className="w-full h-full object-cover rounded-2xl opacity-40 grayscale" alt="Scanning" />
               <div className="absolute inset-0 flex items-center justify-center">
                  <div className="w-12 h-12 border-4 border-aura-primary border-t-transparent rounded-full animate-spin" />
               </div>
            </div>
            <div>
              <div className="text-xs font-extrabold text-aura-primary uppercase tracking-[0.3em] animate-pulse">Running Neural Inference...</div>
              <p className="text-[10px] text-aura-text-secondary font-medium mt-2">Identifying pattern vectors & hazard severity</p>
            </div>
          </>
        ) : (
          <div className="w-full text-left space-y-6 animate-in fade-in slide-in-from-bottom-4 duration-700">
             <div className="flex items-center justify-between">
                <h3 className="text-xl font-display font-bold text-aura-text-primary">{diagnosis!.title}</h3>
                <div className={`px-4 py-1 rounded-full text-[10px] font-bold uppercase tracking-widest ${diagnosis!.severity === 'Big' ? 'bg-aura-danger/10 text-aura-danger' : 'bg-aura-success/10 text-aura-success'}`}>
                   {diagnosis!.severity} Issue
                </div>
             </div>

             <p className="text-sm text-aura-text-secondary leading-relaxed bg-white/40 p-5 rounded-2xl border border-white/40 italic">
                "{diagnosis!.description}"
             </p>

             <div className="space-y-3">
                <div className="text-[10px] font-bold text-aura-primary uppercase tracking-widest ml-1">AI Recommendation (DIY Steps)</div>
                <div className="space-y-2">
                   {diagnosis!.diySteps.map((step, i) => (
                     <div key={i} className="flex gap-3 items-start p-4 bg-white/20 rounded-2xl border border-white/20">
                        <span className="w-6 h-6 rounded-lg bg-aura-primary/10 text-aura-primary text-xs font-bold flex items-center justify-center flex-none">{i+1}</span>
                        <span className="text-xs font-medium text-aura-text-primary leading-tight">{step}</span>
                     </div>
                   ))}
                </div>
             </div>

             {diagnosis!.severity === 'Big' && (
                <div className="p-5 bg-aura-danger/10 border border-aura-danger/20 rounded-2xl flex items-center gap-4 animate-in slide-in-from-left-4">
                   <div className="w-10 h-10 rounded-xl bg-aura-danger text-white flex items-center justify-center shadow-aura-soft">
                      <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M10.29 3.86L1.82 18a2 2 0 0 0 1.71 3h16.94a2 2 0 0 0 1.71-3L13.71 3.86a2 2 0 0 0-3.42 0z"/><line x1="12" y1="9" x2="12" y2="13"/><line x1="12" y1="17" x2="12.01" y2="17"/></svg>
                   </div>
                   <div>
                      <div className="text-[10px] font-extrabold text-aura-danger uppercase tracking-widest">Escalated to Maintenance</div>
                      <div className="text-xs font-bold text-aura-text-primary">Ticket #T-{lastRaisedTicket?.id || 'PENDING'} Raised Automatically</div>
                   </div>
                </div>
             )}

             <button 
               onClick={() => { setPreview(null); reset(); }}
               className="w-full py-4 text-[10px] font-bold text-aura-text-secondary uppercase tracking-[0.2em] border-2 border-dashed border-aura-border/50 rounded-2xl hover:border-aura-primary/50 hover:text-aura-primary transition-all"
             >
                Reset Scanner
             </button>
          </div>
        )}
      </div>
    </div>
  );
};
