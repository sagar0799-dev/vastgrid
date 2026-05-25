# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: dashboard.spec.ts >> VastGrid Dashboard Operations & Mock API Integrations >> should successfully sell a flat and onboard a new resident
- Location: tests\dashboard.spec.ts:62:3

# Error details

```
Error: expect(page).toHaveURL(expected) failed

Expected pattern: /.*\/manager/
Received string:  "http://localhost:5173/"
Timeout: 5000ms

Call log:
  - Expect "toHaveURL" with timeout 5000ms
    - unexpected value "http://localhost:5173/"

```

```yaml
- button "Open OIDC Diagnostics Panel":
  - img
- img
- heading "VastGrid" [level=1]
- paragraph: SECURE IDENTITY PORTAL
- text: Select User Role
- button "🏠 resident"
- button "🛡️ manager"
- button "🔧 technician"
- text: Enter Security Passcode
- textbox "••••": admin
- button "🔒 Decrypting Session Keys..." [disabled]:
  - img
  - text: 🔒 Decrypting Session Keys...
- paragraph: "Realm: vastgrid-realm"
```

# Test source

```ts
  16  | 
  17  |     await page.route('**/api/ManagerDashboard/statistics', async (route) => {
  18  |       await route.fulfill({
  19  |         status: 200,
  20  |         contentType: 'application/json',
  21  |         body: JSON.stringify([
  22  |           { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
  23  |         ]),
  24  |       });
  25  |     });
  26  | 
  27  |     await page.route('**/api/ManagerDashboard/residents', async (route) => {
  28  |       await route.fulfill({
  29  |         status: 200,
  30  |         contentType: 'application/json',
  31  |         body: JSON.stringify([
  32  |           { id: 101, firstName: 'Sagar', lastName: 'Vyavhare', apartment: 'Aura Heights - Block Alpha' }
  33  |         ]),
  34  |       });
  35  |     });
  36  | 
  37  |     // 2. Go to login page
  38  |     await page.goto('/');
  39  | 
  40  |     // 3. Log in as Manager
  41  |     await page.getByRole('button', { name: '🛡️ manager' }).click();
  42  |     await page.getByPlaceholder('••••').fill('admin');
  43  |     await page.getByRole('button', { name: 'Secure Sign In' }).click();
  44  | 
  45  |     // 4. Verify redirected to manager dashboard and loading resolves
  46  |     await expect(page).toHaveURL(/.*\/manager/);
  47  |     
  48  |     // 5. Verify the mocked occupancy statistics card is displayed
  49  |     const statsTitle = page.getByRole('heading', { name: '🏢 Occupancy - Aura Heights - Block Alpha' });
  50  |     await expect(statsTitle).toBeVisible();
  51  | 
  52  |     // 6. Verify the resident directory displays the mocked resident
  53  |     const residentName = page.getByText('Sagar');
  54  |     const residentLastName = page.getByText('Vyavhare');
  55  |     const residentApt = page.getByText('Aura Heights - Block Alpha').first();
  56  |     
  57  |     await expect(residentName).toBeVisible();
  58  |     await expect(residentLastName).toBeVisible();
  59  |     await expect(residentApt).toBeVisible();
  60  |   });
  61  | 
  62  |   test('should successfully sell a flat and onboard a new resident', async ({ page }) => {
  63  |     // Mock standard endpoints
  64  |     await page.route('**/api/ManagerDashboard/apartments', async (route) => {
  65  |       await route.fulfill({
  66  |         status: 200,
  67  |         contentType: 'application/json',
  68  |         body: JSON.stringify([
  69  |           { id: 1, blockName: 'Aura Heights - Block Alpha', totalFlats: 20 }
  70  |         ]),
  71  |       });
  72  |     });
  73  | 
  74  |     await page.route('**/api/ManagerDashboard/statistics', async (route) => {
  75  |       await route.fulfill({
  76  |         status: 200,
  77  |         contentType: 'application/json',
  78  |         body: JSON.stringify([
  79  |           { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
  80  |         ]),
  81  |       });
  82  |     });
  83  | 
  84  |     await page.route('**/api/ManagerDashboard/residents', async (route) => {
  85  |       await route.fulfill({
  86  |         status: 200,
  87  |         contentType: 'application/json',
  88  |         body: JSON.stringify([]),
  89  |       });
  90  |     });
  91  | 
  92  |     // Mock POST sell-flat request
  93  |     await page.route('**/api/ManagerDashboard/sell-flat', async (route) => {
  94  |       const requestBody = route.request().postDataJSON();
  95  |       expect(requestBody.firstName).toBe('Jane');
  96  |       expect(requestBody.lastName).toBe('Doe');
  97  |       expect(requestBody.email).toBe('jane.doe@vastgrid.local');
  98  |       expect(requestBody.username).toBe('janedoe');
  99  |       expect(requestBody.password).toBe('securepass123');
  100 | 
  101 |       await route.fulfill({
  102 |         status: 200,
  103 |         contentType: 'application/json',
  104 |         body: JSON.stringify({
  105 |           message: 'Flat sold and resident registered successfully!',
  106 |           residentId: 102
  107 |         }),
  108 |       });
  109 |     });
  110 | 
  111 |     // Log in
  112 |     await page.goto('/');
  113 |     await page.getByRole('button', { name: '🛡️ manager' }).click();
  114 |     await page.getByPlaceholder('••••').fill('admin');
  115 |     await page.getByRole('button', { name: 'Secure Sign In' }).click();
> 116 |     await expect(page).toHaveURL(/.*\/manager/);
      |                        ^ Error: expect(page).toHaveURL(expected) failed
  117 | 
  118 |     // Open Sell Modal
  119 |     const sellBtn = page.getByRole('button', { name: 'Sell a Flat' });
  120 |     await expect(sellBtn).toBeVisible();
  121 |     await sellBtn.click();
  122 | 
  123 |     // Verify modal is open
  124 |     const modalHeading = page.getByRole('heading', { name: '🔑 Sell Flat & Register Resident' });
  125 |     await expect(modalHeading).toBeVisible();
  126 | 
  127 |     // Fill form
  128 |     await page.getByPlaceholder('e.g. John').fill('Jane');
  129 |     await page.getByPlaceholder('e.g. Doe').fill('Doe');
  130 |     await page.getByPlaceholder('john.doe@vastgrid.local').fill('jane.doe@vastgrid.local');
  131 |     await page.getByPlaceholder('johndoe').fill('janedoe');
  132 |     await page.getByPlaceholder('••••••••').fill('securepass123');
  133 | 
  134 |     // Submit form
  135 |     const confirmBtn = page.getByRole('button', { name: 'Confirm Sale' });
  136 |     await confirmBtn.click();
  137 | 
  138 |     // Verify success banner is displayed
  139 |     const successBanner = page.getByText('Flat sold and resident registered successfully!');
  140 |     await expect(successBanner).toBeVisible();
  141 |   });
  142 | 
  143 |   test('should handle OIDC Keycloak email/username conflict (409) gracefully', async ({ page }) => {
  144 |     // Mock standard endpoints
  145 |     await page.route('**/api/ManagerDashboard/apartments', async (route) => {
  146 |       await route.fulfill({
  147 |         status: 200,
  148 |         contentType: 'application/json',
  149 |         body: JSON.stringify([
  150 |           { id: 1, blockName: 'Aura Heights - Block Alpha', totalFlats: 20 }
  151 |         ]),
  152 |       });
  153 |     });
  154 | 
  155 |     await page.route('**/api/ManagerDashboard/statistics', async (route) => {
  156 |       await route.fulfill({
  157 |         status: 200,
  158 |         contentType: 'application/json',
  159 |         body: JSON.stringify([
  160 |           { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
  161 |         ]),
  162 |       });
  163 |     });
  164 | 
  165 |     await page.route('**/api/ManagerDashboard/residents', async (route) => {
  166 |       await route.fulfill({
  167 |         status: 200,
  168 |         contentType: 'application/json',
  169 |         body: JSON.stringify([]),
  170 |       });
  171 |     });
  172 | 
  173 |     // Mock POST sell-flat conflict (409)
  174 |     await page.route('**/api/ManagerDashboard/sell-flat', async (route) => {
  175 |       await route.fulfill({
  176 |         status: 409,
  177 |         contentType: 'application/json',
  178 |         body: JSON.stringify({
  179 |           message: 'OIDC Identity Conflict: Username or email already registered in Keycloak realm.'
  180 |         }),
  181 |       });
  182 |     });
  183 | 
  184 |     // Log in
  185 |     await page.goto('/');
  186 |     await page.getByRole('button', { name: '🛡️ manager' }).click();
  187 |     await page.getByPlaceholder('••••').fill('admin');
  188 |     await page.getByRole('button', { name: 'Secure Sign In' }).click();
  189 |     await expect(page).toHaveURL(/.*\/manager/);
  190 | 
  191 |     // Open Sell Modal and submit conflict credentials
  192 |     await page.getByRole('button', { name: 'Sell a Flat' }).click();
  193 |     await page.getByPlaceholder('e.g. John').fill('Duplicate');
  194 |     await page.getByPlaceholder('e.g. Doe').fill('User');
  195 |     await page.getByPlaceholder('john.doe@vastgrid.local').fill('duplicate@vastgrid.local');
  196 |     await page.getByPlaceholder('johndoe').fill('duplicate');
  197 |     await page.getByPlaceholder('••••••••').fill('somepassword');
  198 | 
  199 |     await page.getByRole('button', { name: 'Confirm Sale' }).click();
  200 | 
  201 |     // Verify 409 error banner is displayed
  202 |     const errorBanner = page.getByText('OIDC Identity Conflict: Username or email already registered in Keycloak realm.');
  203 |     await expect(errorBanner).toBeVisible();
  204 |   });
  205 | 
  206 |   test('should load Resident and Technician dashboards with functional elements', async ({ page }) => {
  207 |     // 1. Test Resident Dashboard
  208 |     await page.goto('/');
  209 |     await page.getByRole('button', { name: '🏠 resident' }).click();
  210 |     await page.getByPlaceholder('••••').fill('402');
  211 |     await page.getByRole('button', { name: 'Secure Sign In' }).click();
  212 |     await expect(page).toHaveURL(/.*\/resident/);
  213 | 
  214 |     // Verify Resident cards
  215 |     await expect(page.getByRole('heading', { name: '🎫 Quick Access' })).toBeVisible();
  216 |     await expect(page.getByRole('heading', { name: '🛠️ Maintenance' })).toBeVisible();
```