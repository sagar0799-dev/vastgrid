import { type AuraAIDiagnosis } from '../types/index';

/**
 * AuraAI API Service
 * Interacts with the .NET AuraAIController for neural image diagnosis.
 */
export const auraApi = {
  analyzeImage: async (base64Image: string): Promise<AuraAIDiagnosis> => {
    const response = await fetch('/api/auraai/analyze', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      },
      body: JSON.stringify(base64Image)
    });
    if (!response.ok) throw new Error('Neural analysis failed.');
    return response.json();
  }
};
