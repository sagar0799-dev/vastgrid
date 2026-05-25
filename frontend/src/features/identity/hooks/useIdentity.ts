import { useState, useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { type User } from '../../../types/index';
import { identityApi } from '../api/identityApi';

/**
 * useIdentity Hook
 * Centralizes OIDC authentication, role extraction, and session persistence.
 */
export const useIdentity = () => {
  const [user, setUser] = useState<User | null>(null);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isAuthenticating, setIsAuthenticating] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  const handleToken = useCallback((token: string) => {
    const userProfile = identityApi.getUserFromToken(token);
    if (userProfile) {
      localStorage.setItem('aura_token', token);
      setUser(userProfile);
      setIsLoggedIn(true);
      return userProfile;
    }
    return null;
  }, []);

  // Initialize: Check for Auth Code in URL or Token in Storage
  useEffect(() => {
    const initAuth = async () => {
      const params = new URLSearchParams(window.location.search);
      const code = params.get('code');
      const storedToken = localStorage.getItem('aura_token');

      // 1. If we have an OIDC Code, exchange it for a token
      if (code) {
        // Clean up URL immediately to prevent re-exchange on refresh
        window.history.replaceState({}, document.title, window.location.pathname);
        
        try {
          const token = await identityApi.exchangeCodeForToken(code);
          if (token) {
            const profile = handleToken(token);
            if (profile) {
               navigate(`/${profile.role}`, { replace: true });
            }
          } else {
            setError('Failed to establish secure session from identity provider.');
          }
        } catch (e) {
          setError('OIDC Authentication error. Please try again.');
        }
      } 
      // 2. Otherwise, check for an existing valid session
      else if (storedToken) {
        handleToken(storedToken);
      }

      setIsAuthenticating(false);
    };

    initAuth();
  }, [handleToken, navigate]);

  const login = useCallback(() => {
    identityApi.redirectToSso();
  }, []);

  const logout = useCallback(async () => {
    await identityApi.logout();
    localStorage.removeItem('aura_token');
    setUser(null);
    setIsLoggedIn(false);
    navigate('/', { replace: true });
  }, [navigate]);

  return {
    user,
    isLoggedIn,
    isAuthenticating,
    error,
    login,
    logout,
    activeRole: user?.role || null,
    isAdmin: user?.role === 'builder' || user?.role === 'manager'
  };
};
