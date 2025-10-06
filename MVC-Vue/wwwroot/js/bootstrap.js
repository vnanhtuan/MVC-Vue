// wwwroot/js/bootstrap.js  (NON‑module, để chắc chắn chạy sớm)
const store = {
    state: { products: [], cart: [] },
    setProducts(list) { store.state.products = list; },
    addToCart(p) {
        const i = store.state.cart.find(x => x.id === p.id);
        i ? i.qty++ : store.state.cart.push({ ...p, qty: 1 });
    },
    get cartCount() { return store.state.cart.reduce((s, i) => s + i.qty, 0); }
};

// Hàm global —> có ngay sau script tải xong
window.productList = function (seed) {
    if (!store.state.products.length) store.setProducts(seed);
    const fmt = v => typeof v === 'number' ? v.toLocaleString('vi-VN') + ' ₫' : '—';
    return {
        products: Vue.reactive(store.state).products,
        cartCount: Vue.computed(() => store.cartCount),
        add: store.addToCart,
        formatPrice: fmt
    };
};

// mount chậm 1 tick (nextTick) để chắc chắc DOM #app đã parse
window.addEventListener('DOMContentLoaded', () => {
    Vue.createApp({}).mount('#app');
});