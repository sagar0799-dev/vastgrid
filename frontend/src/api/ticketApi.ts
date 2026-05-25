import type { Ticket, Diagnosis, TechSpec } from '../types';
import { createLogger } from '../utils/logger';

const log = createLogger('TicketApi');

/**
 * Creates and registers a critical resident escalation ticket.
 */
export const escalateResidentTicket = async (
  presetKey: 'drain' | 'pipe' | 'socket' | 'gas',
  diagnosis: Diagnosis,
  userName?: string
): Promise<Ticket> => {
  log.info('Compiling critical anomaly ticket escalation', { presetKey });
  
  await new Promise(resolve => setTimeout(resolve, 300));
  
  const ticketId = `T-${Math.floor(1000 + Math.random() * 9000)}`;
  const defaultTech: TechSpec = diagnosis.techSpec || {
    name: 'Water Grid Emergency Specialist',
    role: 'Water Systems Specialist',
    rating: '⭐ 4.91',
    vehicle: 'Blue Chevrolet Express - WH921',
    photo: '',
    eta: '8 mins'
  };

  const newTicket: Ticket = {
    id: ticketId,
    name: diagnosis.name,
    description: diagnosis.desc,
    severity: diagnosis.severity,
    flat: '402',
    resident: userName || 'Resident User',
    presetKey,
    status: 'Pending Review',
    timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }),
    techSpec: defaultTech
  };

  log.info('Work order emergency ticket established in dispatcher registry', { ticketId });
  return newTicket;
};

/**
 * Approves a ticket and accepts technician dispatch.
 */
export const dispatchTechnician = async (ticketId: string): Promise<boolean> => {
  log.info('Manager dispatch link authorized for ticket', { ticketId });
  // Simulate carrier call network latency
  await new Promise(resolve => setTimeout(resolve, 3200));
  return true;
};

/**
 * Declines a technical ticket.
 */
export const declineTechnicianTicket = async (ticketId: string): Promise<boolean> => {
  log.warn('Ticket decline operation submitted to dispatcher', { ticketId });
  await new Promise(resolve => setTimeout(resolve, 200));
  return true;
};

/**
 * Marks technical tickets as resolved.
 */
export const resolveTechnicianTicket = async (ticketId: string): Promise<boolean> => {
  log.info('Operator job resolution checklist clearance accepted', { ticketId });
  await new Promise(resolve => setTimeout(resolve, 300));
  return true;
};
