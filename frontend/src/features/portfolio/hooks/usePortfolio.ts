import { useState, useEffect, useCallback } from 'react';
import { type BuilderPortfolio } from '../types/index';
import { portfolioApi } from '../api/portfolioApi';

/**
 * usePortfolio Hook
 * Manages the fetching, caching, and state transitions for the Builder Portfolio.
 */
export const usePortfolio = () => {
  const [data, setData] = useState<BuilderPortfolio | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchPortfolio = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const portfolio = await portfolioApi.getPortfolio();
      setData(portfolio);
    } catch (err: any) {
      setError(err.message || 'Failed to sync portfolio data.');
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchPortfolio();
  }, [fetchPortfolio]);

  return {
    data,
    loading,
    error,
    refresh: fetchPortfolio
  };
};
