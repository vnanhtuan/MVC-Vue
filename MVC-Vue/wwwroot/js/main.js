import { vuetify } from './plugins/vuetify.js';
import { cartState, cartCount, addToCart } from './state/cart.js';
import { router } from './router/index.js';

// Dùng reactive của Vue để theo dõi trạng thái route
const { reactive } = Vue;
const viewState = reactive({
    // Biến này theo dõi xem chúng ta có đang ở route do client quản lý không
    isClientRouteActive: false 
});

// 2. Cập nhật trạng thái viewState mỗi khi route thay đổi
router.afterEach((to) => {
    // Nếu đường dẫn là /cart, đặt là true. Nếu không, là false.
    viewState.isClientRouteActive = to.path === '/cart';
});
// 3. Xử lý tải trang lần đầu
// Nếu người dùng F5 hoặc vào thẳng /cart
viewState.isClientRouteActive = router.currentRoute.value.path === '/cart';

// 1. Định nghĩa các phương thức (methods) dùng chung
const globalMethods = {
    /**
     * Xử lý khi chọn một mục menu.
     */
    chooseMenuItem() {
        console.log("Global chooseMenuItem function");
    }
};

export async function mount(selector, pageOptions, extraComponents = {}) {
    const root = document.querySelector(selector);
    if (!root) return;

    // Tạo hàm setup mới để gộp logic toàn cục (cart) và logic của trang
    const combinedSetup = function() {
        const pageSetupResult = pageOptions.setup ? pageOptions.setup() : {};

        return {
            ...pageSetupResult,
            cartState,
            cartCount,
            addToCart,
            viewState
        };
    };

    // Gộp các methods toàn cục với methods của trang
    const combinedMethods = {
        ...globalMethods, // Các hàm dùng chung
        ...(pageOptions.methods || {}) // Các hàm riêng của trang (nếu có)
    };

    const appOptions = { 
        ...pageOptions, 
        setup: combinedSetup, 
        methods: combinedMethods 
    };
    const app = Vue.createApp(appOptions);

    // Sử dụng các plugin
    app.use(vuetify);
    app.use(router);
    
    // Mount ứng dụng
    app.mount(root);

    // --- THÊM 4 DÒNG NÀY VÀO CUỐI HÀM ---
    const loader = document.getElementById('global-loader');
    if (loader) {
        loader.classList.add('loader-hidden');
        setTimeout(() => { loader.remove(); }, 500); // Xóa sau 0.5s (khớp với transition)
    }
}




