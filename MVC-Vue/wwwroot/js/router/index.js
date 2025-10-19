// Import hàm loadComponent từ file utils
import { loadComponent } from '../utils/loaders.js';

// 1. Load component trang giỏ hàng
const CartPageComponent = await loadComponent('/components/cart.html');

// 2. Component rỗng cho các trang được render từ server
// Đây là một "mẹo" để Vue Router không hiển thị gì cả
// khi chúng ta ở các trang do server render (như / hoặc /product)
const ServerRenderedComponent = { template: '<div></div>' };

// 3. Định nghĩa các routes
const routes = [
    { 
        path: '/cart', 
        component: CartPageComponent 
    },
    { 
        // Route "catch-all" này sẽ khớp với MỌI đường dẫn khác
        // Nó sẽ hiển thị component rỗng, để nội dung từ server được giữ nguyên
        path: '/:pathMatch(.*)*', 
        component: ServerRenderedComponent 
    },
];

// 4. Tạo và export router instance
export const router = VueRouter.createRouter({
    history: VueRouter.createWebHistory(),
    routes,

    //Tự động cuộn lên đầu trang mỗi khi chuyển route.
    scrollBehavior(to, from, savedPosition) {
        // Luôn cuộn về đầu trang
        return { top: 0 };
    }
});