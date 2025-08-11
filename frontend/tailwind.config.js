/** @type {import("tailwindcss").Config} */
module.exports = {
    darkMode: ["class"],
    safelist: ["dark"],

    content: [
        "./pages/**/*.{ts,tsx,vue}",
        "./components/**/*.{ts,tsx,vue}",
        "./app/**/*.{ts,tsx,vue}",
        "./src/**/*.{ts,tsx,vue}",
    ],

    theme: {
        container: {
            center: true,
            padding: "2rem",
            screens: {
                "2xl": "1400px",
            },
        },
        fontSize: {
            "3xs": "0.6rem",
            "2xs": "0.65rem",
            xs: "0.75rem",
            sm: "0.8rem",
            base: "1rem",
            xl: "1.25rem",
            "2xl": "1.563rem",
            "3xl": "1.953rem",
            "4xl": "2.441rem",
            "5xl": "3.052rem",
        },
        extend: {
            backgroundImage: {
                smarthome1: "url('/public/smart-home-3395993_1280.jpg')",
                smarthome2: "url('/public/smart-home-5575122_1280.jpg')",
            },
            colors: {
                trashPapier: "#2e12cc",
                trashBio: "#734d29",
                trashGelb: "#eaed1c",
                trashRest: "#000000",
                border: "hsl(var(--border))",
                input: "hsl(var(--input))",
                ring: "hsl(var(--ring))",
                background: "hsl(var(--background))",
                backgroundColor: "hsl(var(--background-color))",
                color__default: "hsl(var(--background-cards))",
                backgroundHeader: "hsl(var(--background-header))",
                foreground: "hsl(var(--foreground))",
                primary: {
                    DEFAULT: "hsl(var(--primary))",
                    foreground: "hsl(var(--primary-foreground))",
                },
                secondary: {
                    DEFAULT: "hsl(var(--secondary))",
                    foreground: "hsl(var(--secondary-foreground))",
                },
                destructive: {
                    DEFAULT: "hsl(var(--destructive))",
                    foreground: "hsl(var(--destructive-foreground))",
                },
                muted: {
                    DEFAULT: "hsl(var(--muted))",
                    foreground: "hsl(var(--muted-foreground))",
                },
                accent: {
                    DEFAULT: "hsl(var(--accent))",
                    foreground: "hsl(var(--accent-foreground))",
                },
                popover: {
                    DEFAULT: "hsl(var(--popover))",
                    foreground: "hsl(var(--popover-foreground))",
                },
                card: {
                    DEFAULT: "hsl(var(--card))",
                    foreground: "hsl(var(--card-foreground))",
                },
            },
            borderRadius: {
                xl: "calc(var(--radius) + 4px)",
                lg: "var(--radius)",
                md: "calc(var(--radius) - 2px)",
                sm: "calc(var(--radius) - 4px)",
            },
            keyframes: {
                "accordion-down": {
                    from: {height: 0},
                    to: {height: "var(--radix-accordion-content-height)"},
                },
                "accordion-up": {
                    from: {height: "var(--radix-accordion-content-height)"},
                    to: {height: 0},
                },
                "collapsible-down": {
                    from: {height: 0},
                    to: {height: "var(--radix-collapsible-content-height)"},
                },
                "collapsible-up": {
                    from: {height: "var(--radix-collapsible-content-height)"},
                    to: {height: 0},
                },
            },
        },
    },
    plugins: [],
};
