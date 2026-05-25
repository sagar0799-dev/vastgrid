import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { Header } from './Header';

import { type UserRole } from '../types/index';

interface ProtectedRouteProps {
  isLoggedIn: boolean;
  isAuthenticating?: boolean;
  requiredRole?: UserRole;
  activeUserRole?: UserRole;
  userName?: string;
  userAvatar?: string;
  logout?: () => void;
  setConfigDrawerOpen?: (open: boolean) => void;
}

export const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ 
  isLoggedIn, 
  isAuthenticating,
  requiredRole, 
  activeUserRole,
  userName,
  userAvatar,
  logout = () => {},
  setConfigDrawerOpen = () => {}
}) => {
  if (isAuthenticating) {
    return (
      <div className="min-h-screen bg-aura-background flex flex-col items-center justify-center gap-4">
         <div className="w-12 h-12 border-4 border-aura-primary/20 border-t-aura-primary rounded-full animate-spin" />
         <p className="text-aura-text-secondary font-bold text-[10px] uppercase tracking-[0.2em] animate-pulse">Establishing Secure Session...</p>
      </div>
    );
  }

  if (!isLoggedIn) {
    return <Navigate to="/" replace />;
  }

  if (requiredRole && activeUserRole !== requiredRole) {
    if (activeUserRole === 'manager') return <Navigate to="/manager" replace />;
    if (activeUserRole === 'technician') return <Navigate to="/technician" replace />;
    return <Navigate to="/resident" replace />;
  }

  return (
    <div className="min-h-screen bg-aura-background flex flex-col font-sans relative overflow-hidden pb-24 lg:pb-0">
      {/* Dynamic Background Glows */}
      <div className="absolute top-[-10%] left-[-10%] w-[40%] h-[40%] bg-aura-primary/10 rounded-full blur-[120px] pointer-events-none" />
      <div className="absolute bottom-[-10%] right-[-10%] w-[40%] h-[40%] bg-aura-primary-light/10 rounded-full blur-[120px] pointer-events-none" />

      <Header 
        isLoggedIn={isLoggedIn} 
        activeUserRole={activeUserRole || 'resident'} 
        userName={userName}
        userAvatar={userAvatar}
        handleLogout={logout}
        setConfigDrawerOpen={setConfigDrawerOpen}
      />
      
      <div className="flex-1 flex flex-col lg:flex-row p-4 md:p-6 lg:p-8 gap-6 z-10 relative aura-container w-full">
        {/* Floating Glass Sidebar - Desktop Only */}
        <aside className="hidden lg:flex w-72 glass-panel rounded-[2.5rem] flex-col p-8 sticky top-28 self-start h-[calc(100vh-160px)] border-2 border-white/50">
          <nav className="flex-1 space-y-3">
            <div className="text-[10px] font-bold text-aura-primary uppercase tracking-[0.2em] mb-6 ml-2">Main Console</div>
            
            {[
              { label: 'Dashboard', icon: 'M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z', active: true },
              { label: 'Security', icon: 'M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z', active: false },
              { label: 'Reports', icon: 'M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z', active: false },
              { label: 'Settings', icon: 'M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.1a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z', active: false },
            ].map((item) => (
              <button
                key={item.label}
                className={`w-full flex items-center gap-4 px-5 py-4 rounded-2xl transition-all duration-300 group ${
                  item.active 
                    ? 'bg-aura-primary text-white shadow-aura-soft' 
                    : 'text-aura-text-secondary hover:bg-aura-primary/10 hover:text-aura-primary'
                }`}
              >
                <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round" className={item.active ? '' : 'opacity-50 group-hover:opacity-100'}>
                  <path d={item.icon}></path>
                </svg>
                <span className="font-bold text-sm">{item.label}</span>
              </button>
            ))}
          </nav>
          
          <div className="pt-8 border-t border-aura-border/50">
             <div className="bg-aura-background/40 p-5 rounded-3xl border border-white/20">
                <div className="text-[10px] font-bold text-aura-text-secondary uppercase tracking-widest mb-1 opacity-60">System Version</div>
                <div className="text-sm font-display font-extrabold text-aura-text-primary">v1.2.0-Aura</div>
             </div>
          </div>
        </aside>

        {/* Frosted Content Area */}
        <main className="flex-1 glass-panel rounded-[2rem] md:rounded-[2.5rem] overflow-hidden flex flex-col border-2 border-white/50 shadow-2xl relative min-h-0">
          <div className="flex-1 overflow-auto p-4 md:p-8">
            <Outlet />
          </div>
        </main>
      </div>

      {/* Liquid Glass Bottom Navigation Hub (Mobile Diamond-Standard) */}
      <nav className="lg:hidden fixed bottom-6 left-1/2 -translate-x-1/2 w-[calc(100%-2rem)] max-w-md z-[100] h-20 bg-white/60 backdrop-blur-2xl border-2 border-white/40 rounded-[2.5rem] shadow-2xl flex items-center justify-around px-2 overflow-visible">
        <button className="flex flex-col items-center gap-1 group w-14">
          <div className="p-2 rounded-xl bg-aura-primary/10 text-aura-primary active:scale-90 transition-transform">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"></path></svg>
          </div>
          <span className="text-[8px] font-bold text-aura-primary uppercase tracking-tighter">Home</span>
        </button>

        <button className="flex flex-col items-center gap-1 group w-14">
          <div className="p-2 rounded-xl text-aura-text-secondary active:scale-90 transition-transform">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M18 8A6 6 0 0 0 6 8c0 7-3 9-3 9h18s-3-2-3-9"></path><path d="M13.73 21a2 2 0 0 1-3.46 0"></path></svg>
          </div>
          <span className="text-[8px] font-bold text-aura-text-secondary uppercase tracking-tighter">Alerts</span>
        </button>

        {/* Central Primary Intent Hub (FAB) */}
        <div className="flex-none -mt-10">
          <button className="w-14 h-14 rounded-full bg-gradient-to-tr from-aura-primary to-aura-primary-light text-white flex items-center justify-center shadow-aura-glow border-4 border-white/40 active:scale-90 transition-transform">
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
          </button>
        </div>

        <button 
          onClick={logout}
          className="flex flex-col items-center gap-1 group w-14"
        >
          <div className="p-2 rounded-xl text-aura-danger/80 active:scale-90 transition-transform">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"><path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4M16 17l5-5-5-5M21 12H9"/></svg>
          </div>
          <span className="text-[8px] font-bold text-aura-danger uppercase tracking-tighter">Logout</span>
        </button>

        <button className="flex flex-col items-center gap-1 group w-14">
           <div className="w-9 h-9 rounded-full border-2 border-aura-primary/30 p-0.5 overflow-hidden active:scale-90 transition-transform">
             {userAvatar ? (
               <img src={userAvatar} className="w-full h-full rounded-full object-cover" alt="Profile" />
             ) : (
               <div className="w-full h-full rounded-full bg-aura-primary text-white flex items-center justify-center text-[10px] font-bold uppercase">{(userName || 'U')[0]}</div>
             )}
           </div>
          <span className="text-[8px] font-bold text-aura-text-secondary uppercase tracking-tighter">Profile</span>
        </button>
      </nav>
    </div>
  );
};