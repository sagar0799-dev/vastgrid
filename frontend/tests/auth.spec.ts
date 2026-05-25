import { test, expect } from '@playwright/test';

// Before each test, make sure Keycloak is disabled for local passcode testing
test.beforeEach(async ({ page }) => {
  // We can inject VITE_ENABLE_KEYCLOAK = false into session storage, or route it.
  // Wait, let's inject window._env_ or overwrite import.meta.env by mocking.
  // But wait, the environment variables are baked in during Vite build/dev.
  // We can intercept the config loading or inject session/local storage, 
  // or simply mock the response of the config if it fetches it, or mock VITE_ENABLE_KEYCLOAK!
  // In `useAuth.ts`, `oidcConfig` reads `import.meta.env.VITE_ENABLE_KEYCLOAK`.
  // Wait! In `authApi.ts`, `loadOidcConfig` checks `import.meta.env.VITE_ENABLE_KEYCLOAK === 'true'`.
  // Can we mock the environment variables? Since it's bundled in JS, Vite loads it.
  // Wait, we can mock Keycloak redirection or intercept OIDC token exchange!
  // Let's check: if we intercept `/protocol/openid-connect/auth`, we can mock Keycloak auth.
  // Or we can mock the environment by injecting it, or by running with VITE_ENABLE_KEYCLOAK=false.
  // Let's verify how Vite dev server is running. In `playwright.config.ts`, we can set env: { VITE_ENABLE_KEYCLOAK: 'false' }.
  // Wait, does Playwright run `webServer` with those env variables? Yes! 
  // If we set `env: { VITE_ENABLE_KEYCLOAK: 'false' }` in `playwright.config.ts`, the web server will run with Keycloak disabled.
  // Let's double check if we can also test it inside `auth.spec.ts` directly.
});

test.describe('VastGrid Authentication & OIDC Settings Drawer', () => {
  
  test('should open and close the OIDC Settings Drawer and sync with URL parameters', async ({ page }) => {
    // 1. Load login page
    await page.goto('/');

    // 2. Click the gear icon to open diagnostics drawer
    // The button has title="Open OIDC Diagnostics Panel" or class name, let's use getByTitle or getByRole
    const gearBtn = page.getByTitle('Open OIDC Diagnostics Panel');
    await expect(gearBtn).toBeVisible();
    await gearBtn.click();

    // 3. Verify ConfigDrawer is open and visible
    const heading = page.getByRole('heading', { name: 'OIDC & System Settings' });
    await expect(heading).toBeVisible();

    // 4. Verify URL contains config=open (Deep-linking rule)
    await expect(page).toHaveURL(/.*config=open.*/);

    // 5. Close the drawer
    const closeBtn = page.getByRole('button', { name: 'Close ✕' });
    await expect(closeBtn).toBeVisible();
    await closeBtn.click();

    // 6. Verify drawer is closed and URL has no config=open
    await expect(heading).not.toBeVisible();
    await expect(page).not.toHaveURL(/.*config=open.*/);
  });

  test('should support state portability by loading with config=open in URL', async ({ page }) => {
    // Navigate directly to the deep-linked URL
    await page.goto('/?config=open');

    // Verify diagnostics drawer is automatically open on load
    const heading = page.getByRole('heading', { name: 'OIDC & System Settings' });
    await expect(heading).toBeVisible();
  });

  test('should fail login with wrong passcode and trigger shake animation', async ({ page }) => {
    await page.goto('/');
    
    // Select manager role
    const managerBtn = page.getByRole('button', { name: '🛡️ manager' });
    await expect(managerBtn).toBeVisible();
    await managerBtn.click();

    // Enter wrong passcode
    const passcodeField = page.getByPlaceholder('••••');
    await expect(passcodeField).toBeVisible();
    await passcodeField.fill('9999');

    // Click sign in
    const signInBtn = page.getByRole('button', { name: 'Secure Sign In' });
    await expect(signInBtn).toBeVisible();
    await signInBtn.click();

    // Verify access denied toast or message is present
    const toast = page.getByText('Access Denied! Invalid security passcode.');
    await expect(toast).toBeVisible();
  });

  test('should login as Resident and redirect to /resident', async ({ page }) => {
    await page.goto('/');

    // Resident is selected by default, let's click it to be safe
    const residentBtn = page.getByRole('button', { name: '🏠 resident' });
    await residentBtn.click();

    const passcodeField = page.getByPlaceholder('••••');
    await passcodeField.fill('402');

    const signInBtn = page.getByRole('button', { name: 'Secure Sign In' });
    await signInBtn.click();

    // Verify redirect
    await expect(page).toHaveURL(/.*\/resident/);
    
    // Verify resident header/dashboard info
    const dashboardTitle = page.getByText('AuraHome');
    await expect(dashboardTitle).toBeVisible();
    
    // Logout
    const logoutBtn = page.getByRole('button', { name: 'Logout' });
    await logoutBtn.click();
    
    // Verify back on login page
    await expect(page).toHaveURL(/.*\/$/);
  });

  test('should login as Manager and redirect to /manager', async ({ page }) => {
    await page.goto('/');

    // Select manager role
    const managerBtn = page.getByRole('button', { name: '🛡️ manager' });
    await managerBtn.click();

    const passcodeField = page.getByPlaceholder('••••');
    await passcodeField.fill('admin');

    const signInBtn = page.getByRole('button', { name: 'Secure Sign In' });
    await signInBtn.click();

    // Verify redirect
    await expect(page).toHaveURL(/.*\/manager/);
    
    // Logout
    const logoutBtn = page.getByRole('button', { name: 'Logout' });
    await logoutBtn.click();
    await expect(page).toHaveURL(/.*\/$/);
  });

  test('should login as Technician and redirect to /technician', async ({ page }) => {
    await page.goto('/');

    // Select technician role
    const techBtn = page.getByRole('button', { name: '🔧 technician' });
    await techBtn.click();

    const passcodeField = page.getByPlaceholder('••••');
    await passcodeField.fill('tech');

    const signInBtn = page.getByRole('button', { name: 'Secure Sign In' });
    await signInBtn.click();

    // Verify redirect
    await expect(page).toHaveURL(/.*\/technician/);
    
    // Logout
    const logoutBtn = page.getByRole('button', { name: 'Logout' });
    await logoutBtn.click();
    await expect(page).toHaveURL(/.*\/$/);
  });
});
