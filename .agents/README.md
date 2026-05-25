# 🤖 VastGrid Agent Workspace Manifest

Welcome to the **VastGrid** agentic workspace! This `.agents/` folder contains machine-readable manifests and specific, local execution skills designed to empower AI coding assistants and developers.

---

## 📂 Folder Structure

```text
.agents/
├── agent.json            # Machine-readable profile, application metadata & action catalog
├── instructions.md       # 📜 Strict coding guidelines (React Separation, .NET Repositories, OAuth, Docker)
├── README.md             # This documentation / entry-point router
├── prompts/              # 🤖 Task-Specific Prompt Files / Custom Agents
│   ├── code-reviewer-reviver.prompt.md  # React & .NET Code Reviver Agent
│   ├── scenarios-validator.prompt.md    # Scenarios Validator Agent
│   └── ui-ux-agent.prompt.md            # UI & UX Agent
└── skills/
    ├── aspire/
    │   └── SKILL.md      # Instruction set for ongoing Aspire CLI orchestrations
    └── aspireify/
        └── SKILL.md      # One-time bootstrap checklist for migrating services to Aspire
```

---

## 🤖 Task-Specific Custom Agents (Prompts)

We have created dedicated, high-fidelity prompt definitions for three specialized assistant roles:

1. **React & .NET Code Reviver**:
   * **Path**: [`./prompts/code-reviewer-reviver.prompt.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/prompts/code-reviewer-reviver.prompt.md)
   * **Purpose**: Audit components for separation of presentation and hooks, type strictness, and clean service injection.
2. **Scenarios Validator**:
   * **Path**: [`./prompts/scenarios-validator.prompt.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/prompts/scenarios-validator.prompt.md)
   * **Purpose**: Intercept boundary error states, test OIDC conflicts, check input DTO validation constraints, and logging safety.
3. **UI & UX Designer**:
   * **Path**: [`./prompts/ui-ux-agent.prompt.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/prompts/ui-ux-agent.prompt.md)
   * **Purpose**: Polish interfaces to meet premium glassmorphic standards, Tailwind transitions, typography, and URL search parameter sync.
4. **Playwright QA & E2E Testing**:
   * **Path**: [`./prompts/playwright-agent.prompt.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/prompts/playwright-agent.prompt.md)
   * **Purpose**: Write, audit, and execute robust Playwright E2E integration test suites leveraging accessible locators and dynamic URL parameter assertions.

---

## 📜 Architectural Coding Rules

For any developer agent editing the React or .NET core backend, we enforce strict decoupled development patterns:
- **Path to Rules Card**: [`./instructions.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/instructions.md)
- **Key Concepts Enforced**:
  - **React UI/Logic Decoupling**: `.tsx` files strictly render HTML/CSS; custom `.ts` React hooks house state operations; API call managers are isolated to one place (no hardcoding).
  - **.NET Clean Architecture**: Controllers handle incoming requests; Service classes execute business rules; Repository structures contain Database accesses via EF Core; interfaces facilitate DI (Dependency Injection).
  - **Containerization**: Both stacks must be mapped via Docker images.
  - **Keycloak Integration**: Centralized OAuth realm authentication.

---

## 🛠️ Local Agent Skills

### 1. `aspire` Skill
- **Path**: [`./skills/aspire/SKILL.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/skills/aspire/SKILL.md)
- **Purpose**: Manage ongoing .NET Aspire distributed orchestrations.
- **Key Capabilities**: 
  - Manage AppHost runtime states (`aspire start`, `aspire stop`)
  - Inspect running services, OTel telemetry logs, and API health maps
  - Safely add integrations, scale resources, and run targeted steps.

### 2. `aspireify` Skill
- **Path**: [`./skills/aspireify/SKILL.md`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/.agents/skills/aspireify/SKILL.md)
- **Purpose**: One-time wiring wizard for integrating services.
- **Key Capabilities**:
  - Centralize `.env` files into AppHost secret parameters
  - Route ports dynamically avoiding collisions
  - Standardize logging/traces setup inside solutions cleanly.

---

## 🚀 Application Profiles

Our agent oversees two major components inside the `VastGrid` project:

### 📱 1. AuraHome Portal (React Frontend)
- **Directory**: [`./frontend`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/frontend)
- **Engine**: React 19 + TypeScript 5 + Vite 6
- **Description**: An ultra-premium, real-time apartment emergency and visitor check-in system designed with Outfit & Inter typography, delicate glassmorphic gradients, 3D login animations, laser diagnostic sweepers, and technician GPS dispatcher flows.
- **Key Files**:
  - [App.tsx](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/frontend/src/App.tsx) — Main interactive client state engine.
  - [App.css](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/frontend/src/App.css) — Custom light theme and glassmorphic micro-animations.
- **Credentials Hint**:
  - 🏠 **Resident**: Passcode `402`
  - 🏢 **Building Manager**: Passcode `admin`
  - 🔧 **Emergency Technician**: Passcode `tech`

### ⚙️ 2. VastGrid AppHost (.NET Aspire Orchestrator)
- **Directory**: [`./VastGrid.AppHost`](file:///C:/Users/Sagar%20vyavhare/VastGrid/VastGrid/VastGrid.AppHost)
- **TFM**: `.NET 9` (with Aspire integration support)
- **Description**: Orchestrates the service cluster, handles port mapping, and boots container dependencies seamlessly.

---

## 🤖 Common Command Catalog

Other agents or developers can trigger local commands through standard sandboxed terminal runs:

| Action | Description | Cwd | Command |
| :--- | :--- | :--- | :--- |
| **Run Frontend** | Launches the premium AuraHome developer dashboard | `./frontend` | `npm run dev` |
| **Run Host** | Launches the backend AppHost & services via Aspire | `.` | `aspire start` |
| **Verify Environment** | Performs quick health check checks on Docker / SDKs | `.` | `aspire doctor` |

---

*Formulated by your developer assistant, Antigravity.*
