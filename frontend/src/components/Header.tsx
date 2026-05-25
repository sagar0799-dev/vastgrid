import React from 'react';

import { type UserRole } from '../types/index';

interface HeaderProps {
  isLoggedIn: boolean;
  activeUserRole: UserRole;
  userName?: string;
  userAvatar?: string;
  handleLogout: () => void;
  setConfigDrawerOpen?: (open: boolean) => void;
}

export const Header: React.FC<HeaderProps> = ({
  isLoggedIn,
  activeUserRole,
  userName,
  userAvatar,
  handleLogout,
  setConfigDrawerOpen
}) => {
  // Extract user initial dynamically
  const userInitial = userName ? userName.trim().charAt(0).toUpperCase() : 'U';

  return (
    <header className="sticky top-0 z-50 flex items-center justify-between px-4 md:px-6 py-4 bg-aura-background/50 backdrop-blur-xl border-b border-aura-border/50 font-sans aura-container w-full">
      <div className="flex items-center gap-2 md:gap-3 group cursor-pointer">
        <div className="w-10 h-10 md:w-12 md:h-12 rounded-xl md:rounded-2xl bg-gradient-to-tr from-aura-primary to-aura-primary-light text-white font-extrabold flex items-center justify-center shadow-aura-soft group-hover:scale-110 transition-transform duration-500">
          <svg width="20" height="20" className="md:w-6 md:h-6" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round">
            <path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/>
            <polyline points="9 22 9 12 15 12 15 22"/>
          </svg>
        </div>
        <div className="block">
          <div className="text-xl md:text-2xl font-display font-extrabold tracking-tight text-aura-text-primary leading-none mb-1">
            Aura<span className="text-aura-primary">Home</span>
          </div>
          <div className="hidden xs:block text-[8px] md:text-[10px] font-bold tracking-[0.2em] text-aura-primary-light uppercase leading-none opacity-80">
            Intelligent Living
          </div>
        </div>
      </div>

      {isLoggedIn && (
        <div className="flex items-center gap-2 md:gap-4">
          <div className="hidden sm:flex items-center gap-3 bg-white/40 backdrop-blur-md border border-white/20 px-4 py-2 rounded-2xl shadow-aura-soft">
            {userAvatar ? (
              <img 
                src={userAvatar} 
                alt="User profile" 
                className="w-8 h-8 md:w-9 md:h-9 rounded-xl object-cover border border-white/40 shadow-sm" 
              />
            ) : (
              <div className="w-8 h-8 md:w-9 md:h-9 rounded-xl bg-gradient-to-tr from-aura-primary to-aura-primary-light text-white font-bold flex items-center justify-center shadow-sm text-xs md:text-sm">
                {userInitial}
              </div>
            )}
            <div className="flex flex-col leading-tight">
              <span className="font-bold text-xs md:text-sm text-aura-text-primary truncate max-w-[80px] md:max-w-none">
                {userName || 'User'}
              </span>
              <span className="text-[8px] md:text-[10px] text-aura-primary font-bold uppercase tracking-wider">
                {activeUserRole}
              </span>
            </div>
          </div>
          
          <div className="flex items-center gap-2">
            {setConfigDrawerOpen && (
              <button 
                className="hidden sm:flex glass-panel p-2.5 rounded-xl text-aura-text-secondary hover:text-aura-primary transition-all duration-300 hover:scale-110 active:scale-95 group" 
                onClick={() => setConfigDrawerOpen(true)}
              >
                <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="group-hover:rotate-90 transition-transform duration-500">
                  <path d="M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.1a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"/>
                  <circle cx="12" cy="12" r="3"/>
                </svg>
              </button>
            )}
            <button 
              className="hidden sm:flex bg-aura-danger/10 border border-aura-danger/20 text-aura-danger font-bold rounded-xl text-xs px-4 py-2.5 transition-all duration-300 hover:bg-aura-danger hover:text-white hover:shadow-aura-soft active:scale-95" 
              onClick={handleLogout}
            >
              Logout
            </button>
          </div>
        </div>
      )}
    </header>
  );
};
