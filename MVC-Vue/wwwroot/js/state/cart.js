const { reactive, watch, computed } = Vue;

export const cartState = reactive({
    items: JSON.parse(localStorage.getItem("cart") || "[]"),
});

export function addToCart(product) {
    console.log("Adding to cart:", product);

    // Lấy số lượng từ đối tượng sản phẩm
    const quantityToAdd = product.quantity || 1;

    // Tìm một sản phẩm *giống hệt* (cùng ID, màu, và size)
    const existingItem = cartState.items.find(item => 
        item.id === product.id &&
        item.color === product.color &&
        item.size === product.size
    );

    if (existingItem) {
        existingItem.quantity += quantityToAdd;
    } else {
        cartState.items.push({
            id: product.id,
            name: product.name,
            price: product.price,
            color: product.color,
            size: product.size,
            image: product.image,
            quantity: quantityToAdd // Sử dụng số lượng đã truyền vào
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