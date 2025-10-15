
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

async function mount(selector, options, extraComponents = {}) {
    const root = document.querySelector(selector);
    if (!root) return;

    // Merge setup function with cartCount
    const originalSetup = options.setup;
    options.setup = function() {
        // Calculate cart count using computed
        const cartCount = computed(() => {
            return cartState.items.reduce((total, item) => total + item.quantity, 0);
        });

        // Merge with original setup if it exists
        return {
            cartCount,
            ...(originalSetup?.() || {})
        };
    };

    const app = Vue.createApp(options);
    app.use(vuetify);

    
    // đăng ký thêm trước khi mount
    for (const [name, comp] of Object.entries(extraComponents)) {
        app.component(name, comp);
    }

    try {
        // Load cart component before mounting
        const cartComponent = await loadComponent('/components/cart.html');
        if (cartComponent) {
            app.component('cart-component', cartComponent);
            console.log('Cart component registered successfully');
        }

        // Mount app after component is loaded
        app.mount(root);
        return app;
    } catch (error) {
        console.error('Failed to initialize app:', error);
    }

    
}
window.mount = mount;

const { reactive, watch, computed } = Vue;

const cartState = reactive({
    items: JSON.parse(localStorage.getItem("cart") || "[]"),
});

function addToCart(product) {
    const existingItem = cartState.items.find(item => item.id === product.id);
    
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cartState.items.push({
            id: product.id,
            name: product.name,
            price: product.price,
            quantity: 1
        });
    }
    
    // Save to localStorage
    localStorage.setItem("cart", JSON.stringify(cartState.items));
    
    // Update cookie
    document.cookie = `cart=${JSON.stringify(cartState.items)}; path=/; max-age=86400`;
}

watch(
    () => cartState.items,
    (val) => localStorage.setItem("cart", JSON.stringify(val)),
    { deep: true }
);

//mount("#product-list", {
//    data() {
//        return {
//            drawer: false
//            }
//    },
//    setup() {
//        function addToCart(e) {
//            const btn = e.target.closest(".add-to-cart");
//            if (!btn) return;

//            const card = btn.closest(".product");
//            const id = +card.dataset.id;
//            const name = card.querySelector(".name")?.textContent?.trim() || "Sản phẩm";
//            const price = +card.querySelector(".price")?.dataset.value || 0;

//            const found = cartState.items.find((it) => it.id === id);
//            found ? found.qty++ : cartState.items.push({ id, name, price, qty: 1 });
//        }
//        return { addToCart };
//    },
//});

//mount("#menu-list", {
//    data() {
//        return {
//            drawer: false,
//        }
//    },
//    setup() {
//        // ...existing setup code if any...
//    },
//    methods: {
//        showCart() {
//            if (this.$refs.cartComp) {
//                this.$refs.cartComp.dialog = true;
//                console.log('Cart dialog opened');
//            } else {
//                console.error('Cart component not found');
//            }
//        },
//        chooseMenuItem() {
//            // Handle menu item selection
//        }
//    }
//});

async function loadComponent(url) {
    const response = await fetch(url);
    const html = await response.text();
    return {
        template: html,
        data() {
            return {
                dialog: false,
                cartItems: cartState.items
            }
        },
        methods: {
            removeItem(item) {
                const index = this.cartItems.indexOf(item);
                if (index > -1) {
                    this.cartItems.splice(index, 1);
                    localStorage.setItem("cart", JSON.stringify(this.cartItems));
                }
            },
            checkout() {
                // Implement checkout logic
                console.log('Checkout');
            }
        }
    }
}


