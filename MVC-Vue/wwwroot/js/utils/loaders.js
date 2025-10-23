import { cartState } from '../state/cart.js';

export async function loadComponent(url) {
    const response = await fetch(url);
    const html = await response.text(); 
    return {
        template: html,
        data() {
            return {
                // Cung cấp cartItems cho template của component
                get cartItems() {
                    return cartState.items;
                }
            }
        },
        computed: {
            calculateDiscountedPriceFn() {
                return (item) => {
                    if (item && item.discount > 0) {
                        // Giả sử discount là float (ví dụ 10 cho 10%)
                        // Cần ép kiểu sang decimal nếu price là decimal
                        const discountMultiplier = 1 - (item.discount / 100); 
                        // Cẩn thận kiểu dữ liệu khi nhân
                        return item.price * discountMultiplier; 
                    }
                    return item ? item.price : 0;
                };
            },
            subtotal() {
                if (!this.cartItems || this.cartItems.length === 0) return 0;
                
                return this.cartItems.reduce((acc, item) => {
                    // Lấy giá đã giảm của item
                    const finalPrice = this.calculateDiscountedPriceFn(item);
                    // Cộng dồn giá cuối * số lượng
                    return acc + (finalPrice * item.quantity);
                }, 0);
            },
            totalSavings() {
                if (!this.cartItems || this.cartItems.length === 0) return 0;

                return this.cartItems.reduce((acc, item) => {
                    if (item.discount > 0) {
                        const originalPrice = item.price;
                        const discountedPrice = this.calculateDiscountedPriceFn(item);
                        const savingsPerItem = (originalPrice - discountedPrice) * item.quantity;
                        return acc + savingsPerItem;
                    }
                    return acc;
                }, 0);
            },
            shipping() {
                // Ví dụ logic: Đơn hàng trên 500,000đ được miễn phí ship
                if (this.subtotal >= 500000) {
                    return 0;
                }
                // Mặc định là 30,000đ
                return 30000;
            },
            tax() {
                // Tính 10% của subtotal
                return this.subtotal * 0.1;
            },
            total() {
                // Tổng = Tạm tính + Vận chuyển + Thuế
                return this.subtotal + this.shipping + this.tax;
            },
        },
        methods: {
            
            removeItem(item) {
                const index = cartState.items.indexOf(item);
                if (index > -1) {
                    cartState.items.splice(index, 1);
                }
            },
            checkout() {
                console.log('Checkout');
            },
            goBack() {
                // 'this.$router' có sẵn vì component này
                // được render bởi <router-view>
                this.$router.go(-1);
            },
            calculateDiscountedPrice(item){
                return this.calculateDiscountedPriceFn(item);
            },
        }
    }
}