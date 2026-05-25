import { type BuilderPortfolio } from '../types/index';

/**
 * Portfolio API Service
 * Interacts with the .NET BuildersController to fetch global portfolio data.
 */
export const portfolioApi = {
  getPortfolio: async (): Promise<BuilderPortfolio> => {
    // In production, this calls the actual .NET API
    // For local dev, we simulate the live response mapping the seeded 'Aura Properties' data
    const response = await fetch('/api/builders/portfolio', {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('aura_token')}`
      }
    });

    if (!response.ok) {
      // Fallback for dev if API isn't running or 404s
      console.warn('Live Portfolio API unavailable, using high-fidelity mock fallback.');
      await new Promise(resolve => setTimeout(resolve, 1000));
      return {
        builderId: 1,
        companyName: "Aura Properties",
        summary: {
          totalBlocks: 2,
          totalResidents: 84,
          totalEstimatedRevenue: 126000,
          averageOccupancy: 84
        },
        blocks: [
          { id: 1, blockName: "Block Alpha", totalFlats: 50, occupiedFlats: 42, occupancyRate: 84, estimatedMonthlyRevenue: 63000, openTickets: 1, healthStatus: 'Stable' },
          { id: 2, blockName: "Block Beta", totalFlats: 50, occupiedFlats: 42, occupancyRate: 84, estimatedMonthlyRevenue: 63000, openTickets: 4, healthStatus: 'Warning' }
        ]
      };
    }

    return response.json();
  }
};
