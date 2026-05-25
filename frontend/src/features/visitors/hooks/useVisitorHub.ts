import { useEffect, useState, useCallback } from 'react';
import * as signalR from '@microsoft/signalr';
import { type VisitorLog } from '../types/index';
import { createLogger } from '../../../utils/logger';
import { visitorApi } from '../api/visitorApi';

const logger = createLogger('VisitorHub');

/**
 * useVisitorHub Hook
 * Manages the SignalR connection and real-time event listeners.
 * Now includes Offline Sync to fetch missed notifications.
 */
export const useVisitorHub = (role: string, userId?: string) => {
  const [connection, setConnection] = useState<signalR.HubConnection | null>(null);
  const [pendingRequests, setPendingRequests] = useState<VisitorLog[]>([]);
  const [statusUpdate, setStatusUpdate] = useState<{ logId: number; status: string } | null>(null);

  // Sync Offline/Missed Notifications
  const syncMissedNotifications = useCallback(async () => {
    if (role === 'resident') {
      try {
        logger.debug('Synchronizing missed visitor requests');
        const missed = await visitorApi.getMyPending();
        if (missed.length > 0) {
          logger.info(`Found ${missed.length} missed visitor requests`);
          setPendingRequests(missed);
        }
      } catch (e) {
        logger.error('Failed to sync missed notifications', e);
      }
    }
  }, [role]);

  useEffect(() => {
    const newConnection = new signalR.HubConnectionBuilder()
      .withUrl('/hubs/visitor', {
        accessTokenFactory: () => localStorage.getItem('aura_token') || ''
      })
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection.start()
        .then(() => {
          logger.info('SignalR WebSocket session established');
          
          // Trigger Offline Sync immediately upon connection
          syncMissedNotifications();

          // Join appropriate group based on role
          if (role === 'resident' && userId) {
            connection.invoke('JoinResidentGroup', userId);
            logger.debug(`Joining Resident Group: Resident_${userId}`);
          } else if (role === 'watchman') {
            connection.invoke('JoinWatchmanGroup');
            logger.debug('Joining Watchman broadcast group');
          }

          // Global Listeners
          connection.on('ReceiveVisitorRequest', (request: VisitorLog) => {
            logger.info('Incoming visitor request received', request);
            setPendingRequests(prev => [request, ...prev]);
          });

          connection.on('ReceiveStatusUpdate', (update: { logId: number; status: string }) => {
            logger.info(`Visitor status update: LOG-${update.logId} set to ${update.status}`);
            setStatusUpdate(update);
          });
        })
        .catch(e => logger.error('SignalR Handshake failed', e));
    }

    return () => {
      connection?.stop();
    };
  }, [connection, role, userId, syncMissedNotifications]);

  const removeRequest = (id: number) => {
    setPendingRequests(prev => prev.filter(r => r.id !== id));
  };

  return {
    pendingRequests,
    removeRequest,
    statusUpdate,
    clearStatus: () => setStatusUpdate(null),
    isConnected: connection?.state === signalR.HubConnectionState.Connected
  };
};
