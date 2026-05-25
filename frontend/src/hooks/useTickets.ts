import { useState } from 'react';
import type { Ticket } from '../types';
import { createLogger } from '../utils/logger';
import { dispatchTechnician, declineTechnicianTicket, resolveTechnicianTicket } from '../api/ticketApi';

const log = createLogger('UseTicketsHook');

export const useTickets = (addToast: (msg: string, type: 'success' | 'warning' | 'danger' | 'info') => void) => {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [activeDispatchTicket, setActiveDispatchTicket] = useState<Ticket | null>(null);
  const [callingOverlay, setCallingOverlay] = useState<{ active: boolean; message: string }>({ active: false, message: '' });
  const [gpsTrackerProgress, setGpsTrackerProgress] = useState<'idle' | 'enroute' | 'arrived'>('idle');
  const [dispatchEvents, setDispatchEvents] = useState<Array<{ time: string; title: string; desc: string }>>([]);

  const addTicket = (newTicket: Ticket) => {
    setTickets(prev => [...prev, newTicket]);
    log.info('New ticket loaded locally', { ticketId: newTicket.id });
  };

  const initiateGPSTelemetry = (ticket: Ticket) => {
    log.info('Uplinking real-time GPS fleet telemetry tracking', { ticketId: ticket.id });
    setGpsTrackerProgress('enroute');
    setDispatchEvents([
      { time: '10:15 AM', title: 'Telemetry Uplink Active', desc: 'Secure connection established. Telemetric beacons active.' },
      { time: '10:16 AM', title: 'Work Order Dispatched', desc: `Manager approved ticket. Emergency crew assigned: ${ticket.techSpec.name}.` },
      { time: '10:17 AM', title: 'En Route', desc: `Technician accepted call. GPS matches vehicle ${ticket.techSpec.vehicle}.` }
    ]);

    // Fast-forward arrival
    setTimeout(() => {
      setGpsTrackerProgress('arrived');
      setDispatchEvents(prev => [
        ...prev,
        { time: '10:20 AM', title: 'Technician Arrived', desc: 'GPS marker registers technician on-site. Proceeding to Flat 402.' }
      ]);
      log.info('GPS telemetry indicates dispatch crew arrived on-site', {
        ticketId: ticket.id,
        technician: ticket.techSpec.name
      });
    }, 4500);
  };

  const handleApproveAndCall = async (ticketId: string) => {
    const ticket = tickets.find(t => t.id === ticketId);
    if (!ticket) {
      log.warn('Admin dispatch operation failed: ticket reference not found', { ticketId });
      return;
    }

    log.info('Admin approved emergency work order. Establishing operator uplink...', {
      ticketId,
      assignedTech: ticket.techSpec.name,
      specialty: ticket.techSpec.role
    });

    // Set ticket state to Calling
    setTickets(prev => prev.map(t => t.id === ticketId ? { ...t, status: 'Calling Dispatch' } : t));

    // Show Overlay Call Ringing
    setCallingOverlay({
      active: true,
      message: `Establishing secure link to operator dispatch... Deploying ${ticket.techSpec.role} ${ticket.techSpec.name}.`
    });

    try {
      await dispatchTechnician(ticketId);
      
      setCallingOverlay({ active: false, message: '' });
      addToast(`Link established! Technician ${ticket.techSpec.name} deployed.`, 'success');

      // Update to Dispatched
      setTickets(prev => prev.map(t => t.id === ticketId ? { ...t, status: 'Dispatched' } : t));
      
      const updatedTicket: Ticket = { ...ticket, status: 'Dispatched' };
      setActiveDispatchTicket(updatedTicket);
      initiateGPSTelemetry(updatedTicket);
      
      log.info('Operator crew dispatched. GPS telemetric beacon activated.', {
        ticketId,
        techSpec: ticket.techSpec
      });
    } catch (err: any) {
      setCallingOverlay({ active: false, message: '' });
      addToast('🚨 Dispatch Connection Error.', 'danger');
      log.error('Dispatch failed', { error: err.message });
    }
  };

  const handleDeclineTicket = async (ticketId: string) => {
    log.warn('Admin declined and terminated work order ticket.', { ticketId });
    try {
      await declineTechnicianTicket(ticketId);
      setTickets(prev => prev.filter(t => t.id !== ticketId));
      addToast('Work order ticket declined and closed.', 'warning');
    } catch (err: any) {
      log.error('Decline action failed', { error: err.message });
    }
  };

  const handleResolveJob = async (ticketId: string) => {
    log.info('Operator submitted job resolution clearance report', { ticketId });
    try {
      await resolveTechnicianTicket(ticketId);
      setTickets(prev => prev.map(t => t.id === ticketId ? { ...t, status: 'Resolved' } : t));
      setActiveDispatchTicket(null);
      setGpsTrackerProgress('idle');
      addToast(`Work Order ${ticketId} marked as RESOLVED by technician. System nominal.`, 'success');
      log.info('Technical ticket resolved. Building infrastructure nominal.', { ticketId });
    } catch (err: any) {
      log.error('Resolution submission failed', { error: err.message });
    }
  };

  return {
    tickets,
    activeDispatchTicket,
    callingOverlay,
    gpsTrackerProgress,
    dispatchEvents,
    addTicket,
    handleApproveAndCall,
    handleDeclineTicket,
    handleResolveJob
  };
};
