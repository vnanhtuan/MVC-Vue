const { reactive, computed, inject } = Vue;

/* Tạo store global */
export function createStore() {
    const state = reactive({
        products: [],      // seed từ Razor
        cart: []           // [{id, qty}]
    });

    /* actions */
    function setProducts(list) { state.products = list; }
    function addToCart(prod) {
        const item = state.cart.find(i => i.id === prod.id);
        item ? item.qty++ : state.cart.push({ ...prod, qty: 1 });
    }

    /* getters */
    const cartCount = computed(() =>
        state.cart.reduce((s, i) => s + i.qty, 0));

    return { state, setProducts, addToCart, cartCount };
}

/* helper lấy store ở component */
export function useStore() {
    return inject('store');
}