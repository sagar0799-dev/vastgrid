import { test, expect } from '@playwright/test';

test.describe('VastGrid Dashboard Operations & Mock API Integrations', () => {

  test('should load manager dashboard, display mocked stats and resident directory', async ({ page }) => {
    // 1. Setup API interception mocks before navigation
    await page.route('**/api/ManagerDashboard/apartments', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { id: 1, blockName: 'Aura Heights - Block Alpha', totalFlats: 20 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/statistics', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/residents', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { id: 101, firstName: 'Sagar', lastName: 'Vyavhare', apartment: 'Aura Heights - Block Alpha' }
        ]),
      });
    });

    // 2. Go to login page
    await page.goto('/');

    // 3. Log in as Manager
    await page.getByRole('button', { name: '🛡️ manager' }).click();
    await page.getByPlaceholder('••••').fill('admin');
    await page.getByRole('button', { name: 'Secure Sign In' }).click();

    // 4. Verify redirected to manager dashboard and loading resolves
    await expect(page).toHaveURL(/.*\/manager/);
    
    // 5. Verify the mocked occupancy statistics card is displayed
    const statsTitle = page.getByRole('heading', { name: '🏢 Occupancy - Aura Heights - Block Alpha' });
    await expect(statsTitle).toBeVisible();

    // 6. Verify the resident directory displays the mocked resident
    const residentName = page.getByText('Sagar');
    const residentLastName = page.getByText('Vyavhare');
    const residentApt = page.getByText('Aura Heights - Block Alpha').first();
    
    await expect(residentName).toBeVisible();
    await expect(residentLastName).toBeVisible();
    await expect(residentApt).toBeVisible();
  });

  test('should successfully sell a flat and onboard a new resident', async ({ page }) => {
    // Mock standard endpoints
    await page.route('**/api/ManagerDashboard/apartments', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { id: 1, blockName: 'Aura Heights - Block Alpha', totalFlats: 20 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/statistics', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/residents', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([]),
      });
    });

    // Mock POST sell-flat request
    await page.route('**/api/ManagerDashboard/sell-flat', async (route) => {
      const requestBody = route.request().postDataJSON();
      expect(requestBody.firstName).toBe('Jane');
      expect(requestBody.lastName).toBe('Doe');
      expect(requestBody.email).toBe('jane.doe@vastgrid.local');
      expect(requestBody.username).toBe('janedoe');
      expect(requestBody.password).toBe('securepass123');

      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify({
          message: 'Flat sold and resident registered successfully!',
          residentId: 102
        }),
      });
    });

    // Log in
    await page.goto('/');
    await page.getByRole('button', { name: '🛡️ manager' }).click();
    await page.getByPlaceholder('••••').fill('admin');
    await page.getByRole('button', { name: 'Secure Sign In' }).click();
    await expect(page).toHaveURL(/.*\/manager/);

    // Open Sell Modal
    const sellBtn = page.getByRole('button', { name: 'Sell a Flat' });
    await expect(sellBtn).toBeVisible();
    await sellBtn.click();

    // Verify modal is open
    const modalHeading = page.getByRole('heading', { name: '🔑 Sell Flat & Register Resident' });
    await expect(modalHeading).toBeVisible();

    // Fill form
    await page.getByPlaceholder('e.g. John').fill('Jane');
    await page.getByPlaceholder('e.g. Doe').fill('Doe');
    await page.getByPlaceholder('john.doe@vastgrid.local').fill('jane.doe@vastgrid.local');
    await page.getByPlaceholder('johndoe').fill('janedoe');
    await page.getByPlaceholder('••••••••').fill('securepass123');

    // Submit form
    const confirmBtn = page.getByRole('button', { name: 'Confirm Sale' });
    await confirmBtn.click();

    // Verify success banner is displayed
    const successBanner = page.getByText('Flat sold and resident registered successfully!');
    await expect(successBanner).toBeVisible();
  });

  test('should handle OIDC Keycloak email/username conflict (409) gracefully', async ({ page }) => {
    // Mock standard endpoints
    await page.route('**/api/ManagerDashboard/apartments', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { id: 1, blockName: 'Aura Heights - Block Alpha', totalFlats: 20 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/statistics', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([
          { blockName: 'Aura Heights - Block Alpha', sold: 12, unsold: 8 }
        ]),
      });
    });

    await page.route('**/api/ManagerDashboard/residents', async (route) => {
      await route.fulfill({
        status: 200,
        contentType: 'application/json',
        body: JSON.stringify([]),
      });
    });

    // Mock POST sell-flat conflict (409)
    await page.route('**/api/ManagerDashboard/sell-flat', async (route) => {
      await route.fulfill({
        status: 409,
        contentType: 'application/json',
        body: JSON.stringify({
          message: 'OIDC Identity Conflict: Username or email already registered in Keycloak realm.'
        }),
      });
    });

    // Log in
    await page.goto('/');
    await page.getByRole('button', { name: '🛡️ manager' }).click();
    await page.getByPlaceholder('••••').fill('admin');
    await page.getByRole('button', { name: 'Secure Sign In' }).click();
    await expect(page).toHaveURL(/.*\/manager/);

    // Open Sell Modal and submit conflict credentials
    await page.getByRole('button', { name: 'Sell a Flat' }).click();
    await page.getByPlaceholder('e.g. John').fill('Duplicate');
    await page.getByPlaceholder('e.g. Doe').fill('User');
    await page.getByPlaceholder('john.doe@vastgrid.local').fill('duplicate@vastgrid.local');
    await page.getByPlaceholder('johndoe').fill('duplicate');
    await page.getByPlaceholder('••••••••').fill('somepassword');

    await page.getByRole('button', { name: 'Confirm Sale' }).click();

    // Verify 409 error banner is displayed
    const errorBanner = page.getByText('OIDC Identity Conflict: Username or email already registered in Keycloak realm.');
    await expect(errorBanner).toBeVisible();
  });

  test('should load Resident and Technician dashboards with functional elements', async ({ page }) => {
    // 1. Test Resident Dashboard
    await page.goto('/');
    await page.getByRole('button', { name: '🏠 resident' }).click();
    await page.getByPlaceholder('••••').fill('402');
    await page.getByRole('button', { name: 'Secure Sign In' }).click();
    await expect(page).toHaveURL(/.*\/resident/);

    // Verify Resident cards
    await expect(page.getByRole('heading', { name: '🎫 Quick Access' })).toBeVisible();
    await expect(page.getByRole('heading', { name: '🛠️ Maintenance' })).toBeVisible();
    await expect(page.getByRole('heading', { name: '📊 AuraAI Telemetry' })).toBeVisible();

    // Logout
    await page.getByRole('button', { name: 'Logout' }).click();

    // 2. Test Technician Dashboard
    await page.getByRole('button', { name: '🔧 technician' }).click();
    await page.getByPlaceholder('••••').fill('tech');
    await page.getByRole('button', { name: 'Secure Sign In' }).click();
    await expect(page).toHaveURL(/.*\/technician/);

    // Verify Technician jobs
    await expect(page.getByText('Job #A12-Leak')).toBeVisible();
    await expect(page.getByText('Job #B04-HVAC')).toBeVisible();
  });
});
