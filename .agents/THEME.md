# 🎨 VastGrid Premium Theme: Aura Light

This document defines the official design language, color palettes, and visual constraints for the VastGrid (AuraHome) ecosystem. All UI components must strictly adhere to these specifications.

---

## 🌈 Color Palette (Tailwind HSL / Hex)

| Role | Color Name | Hex Code | Purpose |
| :--- | :--- | :--- | :--- |
| **Primary (Base)** | Teal 600 | `#0d9488` | Main brand color, primary actions. |
| **Primary (Light)** | Teal 400 | `#2dd4bf` | Highlights and gradients. |
| **Success** | Emerald 500 | `#10b981` | Validation, confirmed states. |
| **Emergency** | Amber 500 | `#f59e0b` | Alerts, hazards, critical actions. |
| **Danger** | Rose 500 | `#f43f5e` | Deletions, errors, stops. |
| **Surface** | White | `#ffffff` | Card backgrounds, modal surfaces. |
| **Background** | Slate 50 | `#f8fafc` | Global page background. |
| **Border** | Slate 200 | `#e2e8f0` | Dividers, subtle outlines. |
| **Text Primary** | Slate 900 | `#0f172a` | Main headings, dark text. |
| **Text Secondary**| Slate 600 | `#475569` | Body text, labels, descriptors. |

---

## 💎 Visual Principles

### 1. Glassmorphism & Depth
*   **Surface Polish**: Use `bg-white/70 backdrop-blur-md` for all floating elements (cards, headers, sidebars).
*   **Shadows**: Use soft, colored shadows for primary elements (e.g., `shadow-teal-500/10`). Avoid harsh black shadows.
*   **Borders**: Use semi-transparent borders: `border border-white/20` or `border border-slate-200/50`.

### 2. Typography
*   **Font Family**: `Outfit` (Primary) and `Inter` (Secondary).
*   **Scale**: Use Tailwind's standard scales (`text-sm`, `text-base`, `text-xl`, etc.) but ensure line-height is always `relaxed` (1.625) for body text.

### 3. Responsiveness (Mobile First)
*   **Grid System**: Use a 12-column grid.
*   **Breakpoints**:
    *   `Mobile`: Default (Stack everything, 16px padding).
    *   `Tablet (md)`: 768px (2 columns, 24px padding).
    *   `Desktop (lg)`: 1024px (3-4 columns, 32px padding).
    *   `Wide (xl)`: 1280px+ (Max container width `1440px`).

---

## ⚡ Interaction Standards
*   **Transitions**: All hover states must use `transition-all duration-300 ease-in-out`.
*   **Active States**: Slight scale down on click (`active:scale-[0.98]`).
*   **Hover States**: Slight scale up and shadow intensity increase (`hover:scale-[1.02] hover:shadow-xl`).
