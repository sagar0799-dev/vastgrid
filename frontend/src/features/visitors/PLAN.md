# Gate Keeper Visitor System: Feature Implementation

I am now implementing the 'Gate Keeper' visitor management within the `src/features/visitors/` folder.

## 👮 Watchman Check-In Experience
1.  **Block Selection**: A liquid-glass grid to select the target Apartment Block.
2.  **Resident Finder**: A searchable list of residents with their `Flat Number` and `Phone Number` (for fallback).
3.  **Real-Time Queue**: A live feed of active requests showing status: `Approving...`, `Approved`, or `Denied`.

## 🏠 Resident Real-Time Experience
1.  **Identity Notification**: A pulsing, high-priority "Liquid Glass" modal that appears instantly via SignalR.
2.  **Audit Hub**: A dedicated history card in the dashboard showing `Who`, `When`, and `Status`.

---

## 🏢 Visitor Folder Structure
*   `types/index.ts`: Shared visitor interfaces.
*   `api/visitorApi.ts`: REST client for check-ins and responses.
*   `hooks/useVisitorHub.ts`: SignalR connection manager.
*   `components/WatchmanDashboard.tsx`: Primary check-in interface.
*   `components/VisitorAlertModal.tsx`: Real-time notification UI.
*   `components/VisitorHistory.tsx`: Resident audit log.
