export type PortfolioStats = {
  totalBlocks: number;
  totalResidents: number;
  totalEstimatedRevenue: number;
  averageOccupancy: number;
};

export type ApartmentPortfolioItem = {
  id: number;
  blockName: string;
  totalFlats: number;
  occupiedFlats: number;
  occupancyRate: number;
  estimatedMonthlyRevenue: number;
  openTickets: number;
  healthStatus: 'Stable' | 'Warning' | 'Critical';
};

export type BuilderPortfolio = {
  builderId: number;
  companyName: string;
  summary: PortfolioStats;
  blocks: ApartmentPortfolioItem[];
};
