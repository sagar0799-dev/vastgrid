import React, { useState, useEffect } from 'react';
import type { Resident, Statistics, Apartment } from '../types';
import { getResidents, getStatistics, getApartments, sellFlat } from '../api/managerApi';
import { createLogger } from '../utils/logger';

const log = createLogger('UseManager');

/**
 * Custom React Hook that encapsulates all states, validations, and operations for property building managers.
 * Completely decouples business operations and side-effects from the TSX rendering layouts.
 */
export const useManager = () => {
  const [residents, setResidents] = useState<Resident[]>([]);
  const [stats, setStats] = useState<Statistics[]>([]);
  const [apartments, setApartments] = useState<Apartment[]>([]);
  const [loading, setLoading] = useState(true);

  // Form & modal state management
  const [isSellModalOpen, setIsSellModalOpen] = useState(false);
  const [selectedApartmentId, setSelectedApartmentId] = useState<number | ''>('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  
  const [submitting, setSubmitting] = useState(false);
  const [formError, setFormError] = useState('');
  const [formSuccess, setFormSuccess] = useState('');

  /**
   * Fetches and compiles all building portfolio, statistics, and directory datasets in parallel.
   */
  const fetchData = async () => {
    log.info('Refreshing manager dashboard datasets');
    const token = sessionStorage.getItem('accessToken');
    if (!token) {
      log.warn('No active OAuth2 access token found in session storage. Aborting load.');
      setLoading(false);
      return;
    }

    try {
      const [residentsData, statsData, apartmentsData] = await Promise.all([
        getResidents(token),
        getStatistics(token),
        getApartments(token)
      ]);

      setResidents(residentsData);
      setStats(statsData);
      setApartments(apartmentsData);

      // Smart Auto-selection: If there is exactly one apartment block, pre-select it
      if (apartmentsData.length === 1) {
        log.info(`Smart auto-selecting single available block: ${apartmentsData[0].blockName}`);
        setSelectedApartmentId(apartmentsData[0].id);
      }
    } catch (error: any) {
      log.error('Failed to resolve property portfolio dashboard data', { error: error.message });
    } finally {
      setLoading(false);
    }
  };

  // Initial load
  useEffect(() => {
    fetchData();
  }, []);

  /**
   * Submits the resident registration and flat allocation transaction.
   */
  const handleSellFlatSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    log.info('Processing resident flat sale form submission');

    if (!selectedApartmentId) {
      log.warn('Validation failed: apartment block select parameter is missing');
      setFormError('Please select an apartment block.');
      return;
    }

    const token = sessionStorage.getItem('accessToken');
    if (!token) {
      log.error('Unauthorized: access token missing during transaction dispatch');
      setFormError('Session has expired. Please log in again.');
      return;
    }

    setSubmitting(true);
    setFormError('');
    setFormSuccess('');

    try {
      const payload = {
        firstName,
        lastName,
        email,
        username,
        password,
        apartmentId: Number(selectedApartmentId)
      };

      const result = await sellFlat(token, payload);
      log.info('Flat sale confirmed successfully. Response:', result);

      setFormSuccess(result.message || 'Flat sold and resident registered successfully!');
      
      // Auto-refresh the dashboard directory and stats instantly
      await fetchData();

      // Reset form variables
      setFirstName('');
      setLastName('');
      setEmail('');
      setUsername('');
      setPassword('');
      if (apartments.length > 1) {
        setSelectedApartmentId('');
      }

      // Close the modal cleanly after displaying success feedback
      setTimeout(() => {
        setIsSellModalOpen(false);
        setFormSuccess('');
      }, 1500);
    } catch (err: any) {
      log.error('Flat sale transaction aborted due to exception', { error: err.message });
      setFormError(err.message || 'A network error occurred. Please try again.');
    } finally {
      setSubmitting(false);
    }
  };

  const openSellModal = () => {
    log.info('Opening Resident Onboarding / Flat Sale dialog');
    setIsSellModalOpen(true);
  };

  const closeSellModal = () => {
    log.info('Closing Resident Onboarding / Flat Sale dialog');
    setIsSellModalOpen(false);
    setFormError('');
    setFormSuccess('');
  };

  return {
    residents,
    stats,
    apartments,
    loading,
    
    // Modal & Form Values
    isSellModalOpen,
    selectedApartmentId,
    firstName,
    lastName,
    email,
    username,
    password,
    submitting,
    formError,
    formSuccess,

    // Set Actions
    setSelectedApartmentId,
    setFirstName,
    setLastName,
    setEmail,
    setUsername,
    setPassword,
    openSellModal,
    closeSellModal,

    // Handlers & Refreshes
    handleSellFlatSubmit,
    refreshData: fetchData
  };
};
