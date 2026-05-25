# VastGrid Workspace Instruction Manifest

This file contains the strict coding standards, technology stack definitions, and architectural guidelines for the VastGrid workspace. All coding assistants, Copilots, and developer agents must strictly adhere to these rules.

```yaml
# Global Configuration Metadata
applyTo:
  - "frontend/**/*"
  - "VastGrid.Server/**/*"
  - "VastGrid.AppHost/**/*"
techStack:
  frontend: "React 19, Vite 6, TypeScript ~5.9.3, TailwindCSS ^3.4.19"
  backend: ".NET 10 (C# 14, EF Core 10), SQL Server, PostgreSQL"
  identity: "Keycloak 24+ (OIDC / OAuth 2.0)"
  orchestration: ".NET Aspire 10"
```

---

## 🏗️ Feature-Based Architecture (Strict Rule)
Starting now, all new functional domains must follow the **Feature Folder** pattern. Each domain (e.g., `identity`, `visitors`, `tickets`) must reside in `src/features/[feature-name]/` and contain:
*   `components/`: React UI components (`.tsx`).
*   `hooks/`: Feature-specific logic (`.ts`).
*   `api/`: Dedicated API callers (`.ts`).
*   `types/`: Domain-specific TypeScript interfaces (`.ts`).

## 🔐 Extended Role Hierarchy
The system supports a hierarchical, extensible role model:
1.  **Builder**: Global portfolio oversight and property creation.
2.  **Manager**: Property-specific operations and resident onboarding.
3.  **Resident**: Unit management, visitor passes, and hazard reporting.
4.  **Watchman**: Visitor verification and real-time security logs.
5.  **Technician**: Maintenance execution and telemetry tracking.

### 2. Centralized API Communication
*   **No Inline API Fetching**: Direct `fetch` or API libraries inside UI files or general hooks are strictly forbidden.
*   **Centralized API Clients**: All server endpoints and request/response mapping must be encapsulated as reusable async functions inside the centralized `src/api/` directory (e.g., `src/api/visitorApi.ts`).

### 3. Deep-Linking URL State Rule (Portability)
*   **Deep-Linking for Major Transitions**: Any structural UI state changes (active tabs, open modals, selected apartment blocks, portfolio items) must be stored in the browser's URL search parameters (e.g. `?apartment=BlockA&activeTab=tickets`) or hash parameters.
*   **Zero Transient Desyncs**: A user must be able to copy the URL from their address bar, paste it into another window, and load the **identical** active view state.

### 🛑 Frontend Negative Examples (FORBIDDEN PATTERNS)
```typescript
// ❌ FORBIDDEN: Direct fetch and local isolated state inside .tsx components
export const TicketView = () => {
  const [selectedTab, setSelectedTab] = useState('open'); // ❌ Error: Tab state must sync to URL!
  
  useEffect(() => {
    fetch('/api/tickets') // ❌ Error: Direct API call in UI!
      .then(res => res.json())
      .then(data => console.log(data));
  }, []);

  return <div className="p-4">...</div>;
};
```

---

## 🖥️ Backend Architecture Rules (.NET Core Web API)

The backend follows Clean Architecture using the Repository, Service, and Dependency Injection patterns.

### 1. Unified JSON Error Responses
*   **No Plain Text Errors**: All API controllers must return structured JSON objects (e.g., `new { Message = "..." }`) rather than plain text strings. This prevents frontend JSON parsing syntax crashes (`Unexpected token... is not valid JSON`).
*   **Conflict Validation Handling**: Gracefully catch OIDC/Keycloak `Conflict` status codes (HTTP 409) and database duplicate keys. Translate them into distinct user-friendly JSON message warnings rather than throwing unhandled exception stack traces.

### 2. Decoupled Service Layers
*   **Controllers (`Controllers/`)**: Handle routes, map incoming DTO models, validate inputs, and return standardized HTTP status responses. **Controllers must contain zero business logic or EF database context references.**
*   **Services (`Services/`)**: House core business workflow logic and validations. Every service must implement an interface to facilitate Dependency Injection.
*   **Repositories (`Repositories/`)**: Isolate database access queries and transactions using Entity Framework Core async methods (`ToListAsync`, `FirstOrDefaultAsync`).

### 🛑 Backend Negative Examples (FORBIDDEN PATTERNS)
```csharp
// ❌ FORBIDDEN: DB context references in Controller and plain text error responses
[ApiController]
[Route("api/[controller]")]
public class TicketController(VastGridDbContext dbContext) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult> CreateTicket([FromBody] TicketDto dto)
    {
        if (dto == null) 
        {
            return BadRequest("Invalid ticket data"); // ❌ Error: Plain text response!
        }

        dbContext.Tickets.Add(new Ticket { Details = dto.Details }); // ❌ Error: Direct EF DB write in Controller!
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
```

---

## 🪵 Structured Logging Rules (Frontend & Backend)

To ensure high maintainability, observability, and observability trace analytics, all agents must implement structured logging.

### 1. Frontend Logging
*   **Centralized Logger**: Direct `console.log` statements are forbidden. Instantiation must use the custom logger utility in `src/utils/logger.ts` (`createLogger('Context')`).
*   **Levels Enforcement**:
    *   `DEBUG`: Low-level telemetry metrics (suppressed in production).
    *   `INFO`: User interactive milestones, auth callbacks, and committed operations.
    *   `WARN`: Validation declines, invalid client credentials, or user cancellations.
    *   `ERROR`: System failures, API connection timeouts, or caught exceptions.

### 2. Backend Logging
*   **Structured Context Properties**: Log traces must interpolate parameters cleanly (e.g. `_logger.LogInformation("Selling flat {FlatId}", flatId)`) instead of standard string interpolation to support OpenTelemetry indexing.
*   **Levels Enforcement**:
    *   `LogInformation`: Operation milestones, start/end of core actions.
    *   `LogWarning`: Cleanly handled expected exceptions (e.g., entity not found).
    *   `LogError`: Fatal system errors, database connection faults, or Keycloak OIDC failures.

---

## 🔒 Configuration & Environment Management

> [!IMPORTANT]
> **CRITICAL RULE: DO NOT HARDCODE SENSITIVE VALUES!**
> Under no circumstances should passwords, Client Secrets, connection strings, ports, hosts, or OIDC authority domains be hardcoded. 

*   **Frontend**: All settings must be retrieved from Vite `import.meta.env` system variables prefixed with `VITE_` (e.g., `import.meta.env.VITE_API_URL`).
*   **Backend**: Read settings dynamically using the Strongly-Typed Options pattern or from `IConfiguration` injected parameters. 

---

## 🚀 .NET Aspire & Container Integration

*   **AppHost Orchestration**: Centralize multi-service systems, databases, and third-party containers inside the `VastGrid.AppHost` project.
*   **Dynamic Credentials Injecting**: Reference environments and passwords using `builder.AddParameter(...)` and dynamic `.WithEnvironment("Keycloak__AdminPassword", ...)` mappings to avoid static configurations.
