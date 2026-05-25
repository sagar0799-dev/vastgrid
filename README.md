# 🏢 VastGrid – Distributed Apartment Operations Platform

**VastGrid** is an enterprise-grade distributed operations engine designed for real estate developers and builders managing large multi-apartment portfolios. Integrated into the VastGrid ecosystem is **AuraHome**—an ultra-premium, real-time resident emergency portal and automated visitor check-in system.

---

## 🎨 AuraHome System Blueprint

AuraHome operates as a secure, role-verified, and intelligent resident-to-builder operations bridge:

- 🏠 **Residents**: Instantly generate encrypted visitor passes with dynamic QR vectors. Spot plumbing, gas, or electrical hazards and trigger **Automated AI Neural Diagnosis** via live camera simulation and sweeping laser scan line feedback.
- 🏢 **Building Managers**: Oversee multi-property dashboards (swapping names instantly like *Aura Heights - Block Alpha* or *VastGrid Residences - Phase II*), review checked-in guests, and handle critical maintenance alerts by invoking a simulated emergency dispatcher call sequence.
- 🔧 **Emergency Technicians**: Dispatched automatically upon ticket approval. Track coordinate telemetry routes in real-time on live maps, access active vehicle data, and close out maintenance work order loops.

---

## 🏗️ Technical Architecture & Coding Guidelines

To preserve code maintainability, clean decoupling, and modular testing, this repository adheres to strict programming guidelines across frontend and backend boundaries.

### 📱 Frontend Layer: React + TypeScript
We enforce a strict separation of **Presentation (UI)** and **State/Business Logic (UX)**:

1. **Strict File Extension Separations**:
   - **`.tsx` (Strictly UI)**: Exclusively handles rendering HTML markup, CSS styling, and design components. Absolutely no database interactions, direct API requests, or complex state routines.
   - **`.ts` (Strictly Logic)**: All state transitions, validation, side-effects, calculations, and business routines must reside in pure TypeScript custom hooks (e.g., `useAuth.ts`, `useVisitors.ts`).
2. **Decoupled API Boundary**:
   - Hardcoding URLs or executing raw `fetch` / `axios` calls directly inside components or hooks is prohibited.
   - All connection interfaces must reside in a centralized, well-typed `src/api/` folder (e.g., `src/api/visitorApi.ts`), importing endpoints and handling requests in one isolated place.

### 🖥️ Backend Layer: .NET Core Web API
The backend is built utilizing Clean Architecture, the Repository Pattern, and Dependency Injection:

1. **Controllers (`Controllers/`)**:
   - Expose REST API endpoints, validate incoming request payloads (using strict DTO formats), and map HTTP status codes. No database or business routines are allowed here.
2. **Services (`Services/` & `Interfaces/`)**:
   - Services implement strict domain interfaces to support robust **Dependency Injection (DI)**.
   - Contain the core business rules, operations, validations, and security constraints.
3. **Repositories (`Repositories/` & `Interfaces/`)**:
   - Repositories encapsulate all data access details using **Entity Framework Core (EF Core)**.
   - Decouples business services from direct database providers (**SQL Server** or **PostgreSQL**).

### 🔒 Identity & Authentication (Keycloak OAuth)
- **Keycloak** is integrated as the central Identity Provider using OAuth 2.0 / OpenID Connect (OIDC).
- Client authorization tokens are parsed and mapped securely inside frontend authentication custom hooks (`src/hooks/useAuth.ts`).
- Backend Web APIs validate JWT claims using standard JwtBearer middleware matching the Keycloak realm metadata endpoints.

### 🐳 Infrastructure & Virtualization (Docker)
- Both application stacks, local database layers (PostgreSQL / SQL Server), and the Keycloak realm servers are fully containerized using optimized **Docker Images** to guarantee environment uniformity.

---

## 📂 Project Directory Structure

```text
VastGrid/
├── .agents/                      # 🤖 Machine-readable agent capability manifests
│   ├── agent.json                # Agent profile card and capabilities mapping
│   ├── instructions.md           # Strict React/C# Architectural coding guidelines
│   ├── README.md                 # Agent directory router
│   └── skills/                   # Modular execution routines (aspire, aspireify)
├── frontend/                     # 📱 React + Vite + TypeScript Frontend
│   ├── src/
│   │   ├── api/                  # 🌐 Reusable API Client callers (Pure .ts)
│   │   │   ├── authApi.ts
│   │   │   ├── visitorApi.ts
│   │   │   └── ticketApi.ts
│   │   ├── components/           # 🎨 Presentation UI components (Strictly .tsx)
│   │   │   ├── LoginPage.tsx
│   │   │   ├── ResidentDashboard.tsx
│   │   │   └── ManagerDashboard.tsx
│   │   ├── hooks/                # 🧠 Custom Hooks and Logic Managers (Pure .ts)
│   │   │   ├── useAuth.ts
│   │   │   ├── useVisitors.ts
│   │   │   └── useTickets.ts
│   │   ├── types/                # 📝 Typings and Data Interfaces (Pure .ts)
│   │   │   └── index.ts
│   │   ├── App.tsx               # Entry Component Orchestrator (.tsx)
│   │   ├── App.css               # Premium Light Styles
│   │   └── main.tsx              # React mounting root (.tsx)
│   ├── index.html                # Main entry HTML containing fonts & preconnects
│   ├── package.json
│   └── vite.config.ts
├── VastGrid.AppHost/             # ⚙️ .NET Aspire Orchestrator (Program.cs)
├── VastGrid.Server/              # 🖥️ .NET Core Web API (Clean Repository Architecture)
│   ├── Controllers/              # 📥 Requests entry points
│   ├── Services/                 # 🧠 Domain logic routines
│   ├── Interfaces/               # 🔑 Dependency Injection (DI) contracts
│   ├── Repositories/             # 💾 EF Core database access layer
│   ├── Data/                     # 🗄️ DbContext & migrations (SQL Server/Postgres)
│   ├── Models/                   # 📦 DB Entities and API DTO contracts
│   └── Program.cs                # Middleware setup and Keycloak JWT mapping
├── VastGrid.sln                  # .NET Solution wrapper
└── README.md                     # This official project documentation
```

---

## 🚀 Local Operations Guide

### 1. Verification of Local Tools
Verify that your local system has .NET, Docker, and the Aspire developer environment correctly configured:
```powershell
aspire doctor
```

### 2. Spinning Up Frontend Dev Server
To test and iterate on the premium light-themed AuraHome React portal:
```powershell
cd frontend
npm install
npm run dev
```
Open your browser to the local Vite port (typically `http://localhost:5173`) and validate authentication:
* 🏠 **Resident**: Passcode `402`
* 🏢 **Building Manager**: Passcode `admin`
* 🔧 **Emergency Technician**: Passcode `tech`

### 3. Launching Aspire Orchestration
To boot all backend containers, databases, and dependencies in local dev mode:
```powershell
aspire start
```
Copy the printed Dashboard URL containing the login token parameter (e.g., `http://localhost:18888/login?t=<token>`) into your browser to monitor real-time OpenTelemetry trace loops.
