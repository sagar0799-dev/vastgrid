import { type Ticket, type EscalationPayload } from '../types/index';

/**
 * Ticket API Service
 * Manages maintenance tickets and AI-escalated requests.
 */
export const ticketApi = {
  getResidentTickets: async (): Promise<Ticket[]> => {
    const response = await fetch('/api/tickets/mine', {
      headers: { 'Authorization': `Bearer ${localStorage.getItem('aura_token')}` }
    });
    if (!response.ok) throw new Error('Failed to fetch ticket history.');
    return response.json();
  },

  escalateToTicket: async (payload: EscalationPayload): Promise<Ticket> => {
    const response = await fetch('/api/tickets/escalate', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      },
      body: JSON.stringify(payload)
    });
    if (!response.ok) throw new Error('Escalation failed.');
    return response.json();
  }
};
