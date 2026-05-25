import React from 'react';

interface NavbarProps {
  apartmentName: string;
  userName: string;
  userAvatar?: string;
  logout: () => void;
}

export const Navbar: React.FC<NavbarProps> = ({ apartmentName, userName, userAvatar, logout }) => {
  const [imageError, setImageError] = React.useState(false);

  // Re-enable/reset image loading state if userAvatar changes
  React.useEffect(() => {
    setImageError(false);
  }, [userAvatar]);

  // Extract initials for the premium visual fallback
  const initials = userName
    .split(' ')
    .filter(Boolean)
    .map(n => n[0])
    .slice(0, 2)
    .join('')
    .toUpperCase() || 'U';

  // Compute a deterministic premium gradient based on the username hash
  let hash = 0;
  for (let i = 0; i < userName.length; i++) {
    hash = userName.charCodeAt(i) + ((hash << 5) - hash);
  }
  const gradients = [
    'from-indigo-500 to-purple-600',
    'from-emerald-400 to-teal-600',
    'from-rose-500 to-red-600',
    'from-amber-400 to-orange-600',
    'from-cyan-400 to-blue-600',
    'from-pink-500 to-rose-600'
  ];
  const gradientClass = gradients[Math.abs(hash) % gradients.length];

  return (
    <nav className="bg-white border-b border-slate-200 px-6 py-4 shadow-sm font-sans flex justify-between items-center sticky top-0 z-50">
      <div className="flex items-center gap-3">
        <div className="w-10 h-10 bg-indigo-600 rounded-xl flex items-center justify-center shadow-inner">
          <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1v1H9V7zm5 0h1v1h-1V7zm-5 4h1v1H9v-1zm5 0h1v1h-1v-1zm-5 4h1v1H9v-1zm5 0h1v1h-1v-1z" /></svg>
        </div>
        <div>
          <h1 className="text-xl font-bold text-slate-800 tracking-tight m-0 leading-tight">VastGrid</h1>
          <p className="text-xs font-semibold text-slate-500 uppercase tracking-wider m-0">{apartmentName}</p>
        </div>
      </div>
      
      <div className="flex items-center gap-4">
        <div className="hidden md:flex flex-col items-end">
          <span className="text-sm font-semibold text-slate-800">{userName}</span>
        </div>
        <div className="w-10 h-10 rounded-full border-2 border-slate-200 flex items-center justify-center overflow-hidden bg-slate-100 shadow-sm relative group cursor-pointer transition-transform duration-300 hover:scale-105">
          {userAvatar && !imageError ? (
            <img 
              src={userAvatar} 
              alt={userName} 
              onError={() => setImageError(true)} 
              className="w-full h-full object-cover transition-opacity duration-300 group-hover:opacity-90"
            />
          ) : (
            <div className={`w-full h-full bg-gradient-to-br ${gradientClass} flex items-center justify-center text-white font-bold text-xs tracking-wider uppercase`}>
              {initials}
            </div>
          )}
        </div>
        <button 
          onClick={logout}
          className="ml-2 bg-white text-slate-600 hover:text-red-600 hover:bg-red-50 border border-slate-200 hover:border-red-200 font-medium py-2 px-4 rounded-lg transition-all focus:outline-none focus:ring-2 focus:ring-red-500/20 text-sm"
        >
          Sign Out
        </button>
      </div>
    </nav>
  );
};
