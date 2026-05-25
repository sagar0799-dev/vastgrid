import React from 'react';
import { useIdentity } from '../hooks/useIdentity';

export const AuraLoginPage: React.FC = () => {
  const { login, isAuthenticating, error } = useIdentity();

  return (
    <div className="min-h-screen bg-aura-background flex items-center justify-center p-4 sm:p-6 relative overflow-hidden font-sans">
      {/* Background Orbs */}
      <div className="absolute top-[-20%] left-[-10%] w-[60%] h-[60%] bg-aura-primary/10 rounded-full blur-[120px] animate-pulse" />
      <div className="absolute bottom-[-20%] right-[-10%] w-[60%] h-[60%] bg-aura-primary-light/10 rounded-full blur-[120px] animate-pulse delay-700" />

      <div className="w-full max-w-md z-10">
        <div className="text-center mb-6 sm:mb-10">
          <div className="inline-flex w-16 h-16 sm:w-20 sm:h-20 rounded-2xl sm:rounded-3xl bg-gradient-to-tr from-aura-primary to-aura-primary-light text-white items-center justify-center shadow-aura-soft mb-4 sm:mb-6">
            <svg width="32" height="32" className="sm:w-10 sm:h-10" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
              <path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/>
              <polyline points="9 22 9 12 15 12 15 22"/>
            </svg>
          </div>
          <h1 className="text-4xl sm:text-5xl font-display font-extrabold text-aura-text-primary tracking-tighter mb-2">
            Aura<span className="text-aura-primary">Home</span>
          </h1>
          <p className="text-aura-text-secondary font-medium tracking-widest uppercase text-[10px] sm:text-xs opacity-70">
            Intelligent Living & Operations
          </p>
        </div>

        <main className="glass-panel rounded-[2rem] sm:rounded-[2.5rem] p-8 sm:p-12 text-center relative border-2 border-white/50">
          <div className="mb-10">
            <h2 className="text-2xl font-display font-bold text-aura-text-primary mb-2 text-[clamp(1.2rem,4vw,1.75rem)]">Welcome Back</h2>
            <p className="text-sm text-aura-text-secondary">Sign in securely with your organizational identity.</p>
          </div>

          <div className="space-y-6">
            <button 
              onClick={login}
              disabled={isAuthenticating}
              className="w-full bg-gradient-to-r from-aura-primary to-aura-primary-light text-white font-bold py-4 rounded-2xl shadow-aura-soft hover:shadow-aura-glow hover:scale-[1.02] active:scale-[0.95] transition-all duration-300 disabled:opacity-50 flex items-center justify-center gap-3 overflow-hidden group text-sm sm:text-base"
            >
              {isAuthenticating ? (
                <div className="w-5 h-5 sm:w-6 sm:h-6 border-3 border-white/30 border-t-white rounded-full animate-spin" />
              ) : (
                <>
                  <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
                    <path d="M15 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4M10 17l5-5-5-5M15 12H3"/>
                  </svg>
                  <span>Sign In with Aura SSO</span>
                </>
              )}
            </button>
            
            {error && (
              <div className="p-3 bg-aura-danger/10 border border-aura-danger/20 text-aura-danger text-[10px] font-bold rounded-xl animate-in shake duration-500">
                ⚠️ {error}
              </div>
            )}

            <div className="pt-6 border-t border-aura-border/30 flex justify-between items-center text-[8px] sm:text-[10px] font-bold uppercase tracking-widest text-aura-text-secondary opacity-50">
               <span className="flex items-center gap-1.5">
                  <span className="w-1.5 h-1.5 rounded-full bg-aura-success animate-pulse" />
                  Keycloak OIDC Enabled
               </span>
               <span>v1.2.0 Stable</span>
            </div>
          </div>
        </main>
        
        <p className="text-center mt-8 text-aura-text-secondary/60 text-[10px] font-medium uppercase tracking-widest">
          &copy; 2026 VastGrid Distributed Systems
        </p>
      </div>
    </div>
  );
};
