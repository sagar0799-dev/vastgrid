# Builder Portfolio Feature: Portfolio Feature Folder

I am now implementing the 'Builder Portfolio Overview' within the `src/features/portfolio/` folder, following the mandated feature-based architecture.

## 🏢 Portfolio Folder Structure
I'll create the following files to ensure clean decoupling and live data flow:
*   `types/index.ts`: Maps the `BuilderPortfolioDto` from the backend to TypeScript.
*   `api/portfolioApi.ts`: Implements the `GET /api/builders/portfolio` caller.
*   `hooks/usePortfolio.ts`: Manages the data fetching state and analytics calculations.
*   `components/BuilderDashboard.tsx`: The primary 'Liquid Glass' UI component.

---

## 🎨 Diamond-Standard UX Blueprint
1.  **Global Bento Box**: Top-level stats (Revenue, Occupancy, Units) in a 4-column responsive grid.
2.  **Portfolio Grid**: Individual property blocks represented as large frosted-glass cards.
3.  **Micro-Interactions**: Hover glows on blocks to reveal 'Maintenance Health' and 'Manager Assignment' details.
4.  **Mobile Flow**: Grid collapses to 1-column with the Bottom Hub providing quick filters (e.g., 'View All', 'Critical Alerts').
