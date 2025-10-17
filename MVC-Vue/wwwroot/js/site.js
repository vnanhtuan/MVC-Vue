import { vuetify } from './plugins/vuetify.js';
import { cartState, cartCount, addToCart } from './state/cart.js';
import { loadComponent } from './utils/loaders.js';

// 1. Định nghĩa các phương thức (methods) dùng chung
const globalMethods = {
    /**
     * Mở dialog giỏ hàng.
     * Hàm này giả định component giỏ hàng có ref="cartComp"
     */
    showCart() {
        // 'this' ở đây sẽ trỏ tới instance của Vue
        if (this.$refs.cartComp) {
            this.$refs.cartComp.dialog = true;
            console.log('Global showCart dialog opened');
        } else {
            console.error('Cart component not found. Make sure <cart-component ref="cartComp"></cart-component> exists.');
        }
    },
    
    /**
     * Xử lý khi chọn một mục menu.
     */
    chooseMenuItem() {
        console.log("Global chooseMenuItem function");
    }
};

async function mount(selector, pageOptions, extraComponents = {}) {
    const root = document.querySelector(selector);
    if (!root) return;

    // Tạo hàm setup mới để gộp logic toàn cục (cart) và logic của trang
    const combinedSetup = function() {
        const pageSetupResult = pageOptions.setup ? pageOptions.setup() : {};

        return {
            ...pageSetupResult,
            cartState,
            cartCount,
            addToCart
        };
    };

    // Gộp các methods toàn cục với methods của trang
    const combinedMethods = {
        ...globalMethods, // Các hàm dùng chung
        ...(pageOptions.methods || {}) // Các hàm riêng của trang (nếu có)
    };

    const appOptions = { ...pageOptions, setup: combinedSetup, methods: combinedMethods };
    const app = Vue.createApp(appOptions);

    // Sử dụng các plugin
    app.use(vuetify);

    // Đăng ký các component toàn cục cần thiết
    const cartDialogComponent = await loadComponent('/components/cart.html'); // Đảm bảo đúng đường dẫn
    if (cartDialogComponent) {
        app.component('cart-component', cartDialogComponent);
    }
    
    // Mount ứng dụng
    app.mount(root);
}
window.mount = mount;




