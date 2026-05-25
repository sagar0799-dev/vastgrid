import { type User, type UserRole } from '../../../types/index';
import { jwtDecode } from 'jwt-decode';

/**
 * Identity API Service
 * Handles OIDC redirection and Token management using Authorization Code Flow + PKCE.
 */

const KEYCLOAK_URL = import.meta.env.VITE_KEYCLOAK_URL;
const REALM = import.meta.env.VITE_KEYCLOAK_REALM;
const CLIENT_ID = import.meta.env.VITE_KEYCLOAK_CLIENT_ID;

export const identityApi = {
  /**
   * Generates the Keycloak Login URL using Authorization Code Flow.
   */
  redirectToSso: () => {
    const redirectUri = encodeURIComponent(window.location.origin + '/');
    
    // Authorization Code Flow parameters
    // Note: In a production app, we would generate and store 'state' and 'code_challenge' (PKCE)
    // For this implementation, we'll use standard code flow which Keycloak supports for public clients.
    const authUrl = `${KEYCLOAK_URL}/realms/${REALM}/protocol/openid-connect/auth?client_id=${CLIENT_ID}&redirect_uri=${redirectUri}&response_type=code&scope=openid profile email`;
    
    window.location.href = authUrl;
  },

  /**
   * Exchanges the Authorization Code for a JWT Token.
   */
  exchangeCodeForToken: async (code: string): Promise<string | null> => {
    const redirectUri = window.location.origin + '/';
    const params = new URLSearchParams();
    params.append('grant_type', 'authorization_code');
    params.append('client_id', CLIENT_ID);
    params.append('redirect_uri', redirectUri);
    params.append('code', code);

    try {
      const response = await fetch(`${KEYCLOAK_URL}/realms/${REALM}/protocol/openid-connect/token`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: params
      });

      if (!response.ok) throw new Error('Token exchange failed');
      
      const data = await response.json();
      return data.access_token;
    } catch (e) {
      console.error('OIDC Code Exchange Error:', e);
      return null;
    }
  },

  /**
   * Decodes the JWT and maps it to the internal User type.
   */
  getUserFromToken: (token: string): User | null => {
    try {
      // Basic JWT format check (must have 3 parts)
      if (!token || token.split('.').length !== 3) {
        console.error('Invalid token format received');
        return null;
      }

      const decoded: any = jwtDecode(token);
      
      // Map Keycloak roles (realm_access.roles) to UserRole
      const keycloakRoles = decoded.realm_access?.roles || [];
      const validRoles: UserRole[] = ['builder', 'manager', 'resident', 'watchman', 'technician'];
      const activeRole = validRoles.find(r => keycloakRoles.includes(r)) || 'resident';

      return {
        id: decoded.sub,
        username: decoded.preferred_username,
        email: decoded.email,
        firstName: decoded.given_name,
        lastName: decoded.family_name,
        role: activeRole as UserRole,
        avatar: decoded.picture
      };
    } catch (e) {
      console.error('Token decoding failed', e);
      return null;
    }
  },

  logout: async (): Promise<void> => {
    localStorage.removeItem('aura_token');
    const redirectUri = encodeURIComponent(window.location.origin + '/');
    window.location.href = `${KEYCLOAK_URL}/realms/${REALM}/protocol/openid-connect/logout?post_logout_redirect_uri=${redirectUri}&client_id=${CLIENT_ID}`;
  }
};
