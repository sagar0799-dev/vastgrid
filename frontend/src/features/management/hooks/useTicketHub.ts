import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import { type Ticket } from '../../auraai/types/index';
import { createLogger } from '../../../utils/logger';

const logger = createLogger('TicketHub');

/**
 * useTicketHub Hook
 * Listens for real-time maintenance tickets via SignalR.
 */
export const useTicketHub = (role: string) => {
  const [newTicket, setNewTicket] = useState<Ticket | null>(null);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('/hubs/ticket', {
        accessTokenFactory: () => localStorage.getItem('aura_token') || ''
      })
      .withAutomaticReconnect()
      .build();

    connection.start()
      .then(() => {
        logger.info('SignalR Connected to TicketHub');
        if (role === 'manager') connection.invoke('JoinManagerGroup');
        else if (role === 'technician') connection.invoke('JoinTechnicianGroup');

        connection.on('ReceiveNewTicket', (ticket: Ticket) => {
          logger.info(`New AI Escalated Ticket: ${ticket.title}`);
          setNewTicket(ticket);
        });
      })
      .catch(e => logger.error('SignalR Hub failed', e));

    return () => {
      connection.stop();
    };
  }, [role]);

  return { newTicket, clearTicket: () => setNewTicket(null) };
};
