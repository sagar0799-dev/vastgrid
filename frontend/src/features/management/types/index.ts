import { type Ticket } from '../../auraai/types/index';

export type ManagerStats = {
  blockName: string;
  sold: number;
  unsold: number;
};

export type ManagementState = {
  tickets: Ticket[];
  stats: ManagerStats[];
  loading: boolean;
  error: string | null;
};

// Re-export Ticket to ensure it's available to components importing from this module
export type { Ticket };
