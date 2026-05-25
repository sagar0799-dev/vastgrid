import { Routes, Route, Navigate } from 'react-router-dom';
import { AuraLoginPage } from './features/identity/components/AuraLoginPage';
import { BuilderDashboard } from './features/portfolio/components/BuilderDashboard';
import { AuraManagerDashboard } from './features/management/components/AuraManagerDashboard';
import { ResidentDashboard } from './components/ResidentDashboard';
import { TechnicianDashboard } from './components/TechnicianDashboard';
import { WatchmanDashboard } from './features/visitors/components/WatchmanDashboard';
import { ProtectedRoute } from './components/ProtectedRoute';
import { useIdentity } from './features/identity/hooks/useIdentity';
import { ToastProvider } from './utils/toastManager';

// Inner App component
const AppContent = () => {
  const { user, isLoggedIn, logout, isAuthenticating } = useIdentity();

  return (
    <>
      <Routes>
        <Route path="/" element={<AuraLoginPage />} />

        {/* Protected Routes Wrapper */}
        <Route element={
          <ProtectedRoute 
            isLoggedIn={isLoggedIn} 
            isAuthenticating={isAuthenticating}
            activeUserRole={user?.role} 
            userName={user?.firstName} 
            userAvatar={user?.avatar} 
            logout={logout} 
          />
        }>
          <Route path="/builder" element={<BuilderDashboard />} />
          <Route path="/manager" element={<AuraManagerDashboard />} />
          <Route path="/resident" element={<ResidentDashboard />} />
          <Route path="/watchman" element={<WatchmanDashboard />} />
          <Route path="/technician" element={<TechnicianDashboard />} />
        </Route>

        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </>
  );
};

export default function App() {
  return (
    <ToastProvider>
      <AppContent />
    </ToastProvider>
  );
}
