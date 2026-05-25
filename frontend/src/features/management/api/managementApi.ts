import { type Ticket } from '../../auraai/types/index';
import { type ManagerStats } from '../types/index';

/**
 * Management API Service
 */
export const managementApi = {
  getManagedTickets: async (): Promise<Ticket[]> => {
    const response = await fetch('/api/tickets/managed', {
      headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
    });
    if (!response.ok) throw new Error('Failed to load tickets.');
    return response.json();
  },

  getStats: async (): Promise<ManagerStats[]> => {
    const response = await fetch('/api/managerdashboard/stats', {
      headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
    });
    if (!response.ok) throw new Error('Failed to load analytics.');
    return response.json();
  }
};
