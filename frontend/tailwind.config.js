/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        aura: {
          primary: {
            DEFAULT: '#0d9488', // Teal 600
            light: '#2dd4bf',   // Teal 400
          },
          success: '#10b981',   // Emerald 500
          emergency: '#f59e0b', // Amber 500
          danger: '#f43f5e',    // Rose 500
          surface: '#ffffff',
          background: '#f8fafc',
          border: '#e2e8f0',
          text: {
            primary: '#0f172a',
            secondary: '#475569',
          }
        }
      },
      fontFamily: {
        sans: ['Inter', 'system-ui', 'sans-serif'],
        display: ['Outfit', 'Inter', 'system-ui', 'sans-serif'],
      },
      backdropBlur: {
        xs: '2px',
      },
      boxShadow: {
        'aura-soft': '0 4px 20px -2px rgba(13, 148, 136, 0.1)',
        'aura-glow': '0 0 15px rgba(45, 212, 191, 0.3)',
      }
    },
  },
  plugins: [],
}

