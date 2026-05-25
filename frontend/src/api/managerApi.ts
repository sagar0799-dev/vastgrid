import type { Resident, Statistics, Apartment, SellFlatPayload } from '../types';
import { createLogger } from '../utils/logger';

const log = createLogger('ManagerApi');

/**
 * Centralized API service caller functions for building manager dashboard actions.
 * Adheres strictly to instructions.md rules by encapsulating all dynamic fetches, endpoints, and Bearer token mappings.
 */

/**
 * Fetches the list of residents managed by the active manager.
 */
export const getResidents = async (token: string): Promise<Resident[]> => {
  log.info('Fetching residents directory list from manager endpoint');
  const headers = { 'Authorization': `Bearer ${token}` };

  try {
    const response = await fetch('/api/ManagerDashboard/residents', { headers });
    if (!response.ok) {
      let errorMessage = `Failed to fetch residents: ${response.status}`;
      const errText = await response.text();
      try {
        const errData = JSON.parse(errText);
        errorMessage = errData.message || errData.Message || errorMessage;
      } catch {
        if (errText) errorMessage = errText;
      }
      log.error('Failed to fetch residents list from backend', { status: response.status, details: errorMessage });
      throw new Error(errorMessage);
    }

    const data = await response.json();
    log.debug('Successfully resolved residents directory dataset', { count: data.length });
    return data;
  } catch (error: any) {
    log.error('Network or database exception in getResidents', { message: error.message });
    throw error;
  }
};

/**
 * Fetches the property portfolio occupancy statistics for pie charts.
 */
export const getStatistics = async (token: string): Promise<Statistics[]> => {
  log.info('Compiling occupancy statistics from backend metrics');
  const headers = { 'Authorization': `Bearer ${token}` };

  try {
    const response = await fetch('/api/ManagerDashboard/statistics', { headers });
    if (!response.ok) {
      let errorMessage = `Failed to compile statistics: ${response.status}`;
      const errText = await response.text();
      try {
        const errData = JSON.parse(errText);
        errorMessage = errData.message || errData.Message || errorMessage;
      } catch {
        if (errText) errorMessage = errText;
      }
      log.error('Failed to compile property statistics', { status: response.status, details: errorMessage });
      throw new Error(errorMessage);
    }

    const data = await response.json();
    log.debug('Successfully resolved occupancy statistics metrics', data);
    return data;
  } catch (error: any) {
    log.error('Network or database exception in getStatistics', { message: error.message });
    throw error;
  }
};

/**
 * Fetches the apartments managed by the logged-in manager for dropdown selectors.
 */
export const getApartments = async (token: string): Promise<Apartment[]> => {
  log.info('Fetching assigned apartments list for block dropdown selection');
  const headers = { 'Authorization': `Bearer ${token}` };

  try {
    const response = await fetch('/api/ManagerDashboard/apartments', { headers });
    if (!response.ok) {
      let errorMessage = `Failed to fetch apartments: ${response.status}`;
      const errText = await response.text();
      try {
        const errData = JSON.parse(errText);
        errorMessage = errData.message || errData.Message || errorMessage;
      } catch {
        if (errText) errorMessage = errText;
      }
      log.error('Failed to fetch apartments list', { status: response.status, details: errorMessage });
      throw new Error(errorMessage);
    }

    const data = await response.json();
    log.debug('Successfully resolved apartments dropdown list', { count: data.length });
    return data;
  } catch (error: any) {
    log.error('Network or database exception in getApartments', { message: error.message });
    throw error;
  }
};

/**
 * Onboards a new resident, provisions their credentials in Keycloak, and records the sale in the database.
 */
export const sellFlat = async (
  token: string,
  payload: SellFlatPayload
): Promise<{ message: string; residentId: number }> => {
  log.info('Initiating flat sale request and OIDC account provisioning', {
    username: payload.username,
    email: payload.email,
    apartmentId: payload.apartmentId
  });

  try {
    const response = await fetch('/api/ManagerDashboard/sell-flat', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
      body: JSON.stringify(payload)
    });

    if (!response.ok) {
      let errorMessage = 'Failed to complete flat sale transaction.';
      const resText = await response.text();
      try {
        const errData = JSON.parse(resText);
        errorMessage = errData.message || errData.Message || errorMessage;
      } catch {
        if (resText) {
          errorMessage = resText;
        }
      }
      log.error('Flat sale transaction declined', { status: response.status, message: errorMessage });
      throw new Error(errorMessage);
    }

    const data = await response.json();
    log.info('Flat sale committed and resident user provisioned successfully');
    return data;
  } catch (error: any) {
    log.error('Transaction failed during sellFlat operations', { message: error.message });
    throw error;
  }
};
