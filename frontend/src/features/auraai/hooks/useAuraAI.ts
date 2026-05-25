import { useState, useCallback } from 'react';
import { type AuraAIDiagnosis, type Ticket } from '../types/index';
import { auraApi } from '../api/auraApi';
import { ticketApi } from '../api/ticketApi';

/**
 * useAuraAI Hook
 * Manages the full AI diagnosis lifecycle: Upload -> Analyze -> Escalation.
 */
export const useAuraAI = () => {
  const [analyzing, setAnalyzing] = useState(false);
  const [diagnosis, setDiagnosis] = useState<AuraAIDiagnosis | null>(null);
  const [lastRaisedTicket, setLastRaisedTicket] = useState<Ticket | null>(null);
  const [error, setError] = useState<string | null>(null);

  const startAnalysis = useCallback(async (base64Image: string) => {
    setAnalyzing(true);
    setDiagnosis(null);
    setLastRaisedTicket(null);
    setError(null);

    try {
      const result = await auraApi.analyzeImage(base64Image);
      setDiagnosis(result);

      // Automatic Escalation if Severity is "Big"
      if (result.severity === 'Big') {
        const ticket = await ticketApi.escalateToTicket({
          title: result.title,
          description: result.description,
          imageUrl: base64Image, // In production, this would be a cloud storage URL
          diagnosis: result.diySteps.join('\n')
        });
        setLastRaisedTicket(ticket);
      }
    } catch (err: any) {
      setError(err.message || 'AI processing error.');
    } finally {
      setAnalyzing(false);
    }
  }, []);

  return {
    startAnalysis,
    analyzing,
    diagnosis,
    lastRaisedTicket,
    error,
    reset: () => { setDiagnosis(null); setLastRaisedTicket(null); }
  };
};
