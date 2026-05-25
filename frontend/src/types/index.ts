export type UserRole = 'builder' | 'manager' | 'resident' | 'watchman' | 'technician';

export type User = {
  id: string;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  role: UserRole;
  avatar?: string;
};

export type Visitor = {
  id: string;
  name: string;
  purpose: string;
  flat: string;
  time: string;
  code: string;
  status: 'Approved';
};

export type TechSpec = {
  name: string;
  role: string;
  rating: string;
  vehicle: string;
  photo: string;
  eta: string;
};

export type Ticket = {
  id: string;
  name: string;
  description: string;
  severity: 'Small' | 'Big';
  flat: string;
  resident: string;
  presetKey: 'drain' | 'pipe' | 'socket' | 'gas';
  status: 'Pending Review' | 'Calling Dispatch' | 'Dispatched' | 'Resolved';
  timestamp: string;
  techSpec: TechSpec;
};

export type Toast = {
  id: number;
  message: string;
  type: 'success' | 'warning' | 'danger' | 'info';
};

export type Diagnosis = {
  name: string;
  severity: 'Small' | 'Big';
  confidence: string;
  desc: string;
  steps?: string[];
  techSpec?: TechSpec;
};

export type Resident = {
  id: number;
  firstName: string;
  lastName: string;
  apartment: string;
};

export type Statistics = {
  blockName: string;
  sold: number;
  unsold: number;
};

export type Apartment = {
  id: number;
  blockName: string;
  totalFlats: number;
};

export type SellFlatPayload = {
  firstName: string;
  lastName: string;
  email: string;
  username: string;
  password: string;
  apartmentId: number;
};
