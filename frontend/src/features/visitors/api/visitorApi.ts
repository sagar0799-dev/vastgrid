import { type VisitorLog, type VisitorCheckInPayload } from '../types/index';

/**
 * Visitor API Service
 * Handles REST operations for visitor logging and status updates.
 */
export const visitorApi = {
  checkIn: async (payload: VisitorCheckInPayload): Promise<VisitorLog> => {
    const response = await fetch('/api/visitors/check-in', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      },
      body: JSON.stringify(payload)
    });
    if (!response.ok) throw new Error('Check-in failed.');
    return response.json();
  },

  respond: async (logId: number, status: 'Approved' | 'Denied'): Promise<void> => {
    const response = await fetch(`/api/visitors/respond/${logId}?status=${status}`, {
      method: 'PATCH',
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      }
    });
    if (!response.ok) throw new Error('Failed to submit response.');
  },

  getHistory: async (): Promise<VisitorLog[]> => {
    const response = await fetch('/api/visitors/history', {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      }
    });
    if (!response.ok) throw new Error('Failed to fetch history.');
    return response.json();
  },

  getMyPending: async (): Promise<VisitorLog[]> => {
    const response = await fetch('/api/visitors/my-pending', {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      }
    });
    if (!response.ok) throw new Error('Failed to fetch missed requests.');
    return response.json();
  },

  getPending: async (): Promise<VisitorLog[]> => {
    const response = await fetch('/api/visitors/pending', {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      }
    });
    if (!response.ok) throw new Error('Failed to fetch pending requests.');
    return response.json();
  }
};
