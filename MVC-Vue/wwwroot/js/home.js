(() => {
    const { createApp, reactive } = Vue;   // Vue là global variable

    // Giỏ hàng dùng Reactive
    const cartState = reactive({ items: [] });

    // ---- Widget 1: Product List ----
    const productListEl = document.querySelector("#product-list");
    if (productListEl) {
        createApp({
            setup() {
                // Lấy product DOM đã render sẵn
                const addToCart = e => {
                    const li = e.target.closest(".product");
                    if (!li) return;
                    const id = li.dataset.id;
                    const name = li.querySelector("h3").textContent;
                    cartState.items.push({ id, name });
                };
                return { cartState, addToCart };
            }
        })
            .mount("#product-list");
    }

    // ---- Widget 2: Mini Cart Icon ở header ----
    const cartIconEl = document.getElementById("mini-cart");
    if (cartIconEl) {
        createApp({
            computed: {
                count() { return cartState.items.length; }
            }
        }).mount("#mini-cart");
    }
})();