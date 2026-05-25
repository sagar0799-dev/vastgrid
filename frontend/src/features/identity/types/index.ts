import { type User, type UserRole } from '../../../types/index';

export type IdentityState = {
  user: User | null;
  isLoggedIn: boolean;
  activeRole: UserRole | null;
  token: string | null;
  isAuthenticating: boolean;
  error: string | null;
};

export type LoginPayload = {
  passcode: string;
  role: UserRole;
};
