const { reactive, watch, computed } = Vue;

export const cartState = reactive({
    items: JSON.parse(localStorage.getItem("cart") || "[]"),
});

export function addToCart(product) {
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
}

watch(
    () => cartState.items,
    (val) => localStorage.setItem("cart", JSON.stringify(val)),
    { deep: true }
);

// Export cartCount để các component khác có thể dùng
export const cartCount = computed(() => {
    return cartState.items.reduce((total, item) => total + item.quantity, 0);
});