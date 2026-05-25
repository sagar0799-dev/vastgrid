import type { Visitor } from '../types';
import { createLogger } from '../utils/logger';

const log = createLogger('VisitorApi');

export const getInitialVisitors = (): Visitor[] => {
  return [
    { id: 'V-1021', name: 'Guest Visitor Alpha', purpose: 'Family Visit', flat: '402', time: '09:12 AM', code: 'AH-9281', status: 'Approved' },
    { id: 'V-1022', name: 'Delivery Partner Beta', purpose: 'Delivery Partner', flat: '104', time: '10:45 AM', code: 'AH-3829', status: 'Approved' }
  ];
};

/**
 * Communicates with visitor service and registers a new guest pass.
 */
export const registerNewVisitor = async (
  name: string,
  purpose: string
): Promise<Visitor> => {
  log.info('Registering new guest through visitor services', { name, purpose });
  
  // Simulate network timing
  await new Promise(resolve => setTimeout(resolve, 200));
  
  const guestCode = `AH-${Math.floor(1000 + Math.random() * 9000)}`;
  const id = `V-${Math.floor(1000 + Math.random() * 9000)}`;
  const time = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  
  const newVisitor: Visitor = {
    id,
    name,
    purpose,
    flat: '402',
    time,
    code: guestCode,
    status: 'Approved'
  };

  log.info('Visitor guest pass registered successfully', { id, guestCode });
  return newVisitor;
};
