
const vuetify = Vuetify.createVuetify({
    theme: {
        defaultTheme: "light",
        themes: {
            light: {
                colors: {
                    primary: "#0d9488",
                    secondary: "#ffb300",
                },
            },
        },
    },
    defaults: { global: { ripple: true } },
    icons: { defaultSet: "mdi" },
});

function mount(selector, options, extraComponents = {}) {
    const root = document.querySelector(selector);
    if (!root) return;
    const app = Vue.createApp(options);
    app.use(vuetify);

    // đăng ký thêm trước khi mount
    for (const [name, comp] of Object.entries(extraComponents)) {
        app.component(name, comp);
    }

    app.mount(root);
    return app;
}
window.mount = mount;

const { reactive, watch, computed } = Vue;

const cartState = reactive({
    items: JSON.parse(localStorage.getItem("cart") || "[]"),
});

watch(
    () => cartState.items,
    (val) => localStorage.setItem("cart", JSON.stringify(val)),
    { deep: true }
);

mount("#product-list", {
    setup() {
        function addToCart(e) {
            const btn = e.target.closest(".add-to-cart");
            if (!btn) return;

            const card = btn.closest(".product");
            const id = +card.dataset.id;
            const name = card.querySelector(".name")?.textContent?.trim() || "Sản phẩm";
            const price = +card.querySelector(".price")?.dataset.value || 0;

            const found = cartState.items.find((it) => it.id === id);
            found ? found.qty++ : cartState.items.push({ id, name, price, qty: 1 });
        }
        return { addToCart };
    },
});


