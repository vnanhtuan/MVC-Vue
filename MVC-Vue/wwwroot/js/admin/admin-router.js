// 1. IMPORT CÁC COMPONENT TRANG (đã có đủ logic)
import { LoginPage } from './pages/login.js';
import { DashboardPage } from './pages/dashboard-layout.js';
import { DashboardContentPage } from './pages/dashboard-content.js';
import { ProductListPage } from './pages/product-list.js';
import { ProductDetailPage } from './pages/product-detail.js';

// 2. ĐỊNH NGHĨA ROUTES (Sạch sẽ)
const routes = [
    { 
        path: '/manage/login', 
        name: 'Login',
        component: LoginPage 
    },
    { 
        path: '/manage',
        component: DashboardPage, // Layout cha (có menu)
        children: [ 
            {
                path: '', // /manage
                name: 'Dashboard',
                component: DashboardContentPage 
            },
            { 
                path: 'products', // /manage/products
                name: 'Products',
                component: ProductListPage // Component trang sản phẩm
            },
            {
                // :id là một tham số động
                path: 'products/:id', 
                name: 'ProductDetail',
                component: ProductDetailPage
            }
        ]
    },
];

// 3. TẠO ROUTER
export const router = window.VueRouter.createRouter({
    history: window.VueRouter.createWebHistory(),
    routes,
    scrollBehavior: () => ({ top: 0 })
});

// 4. ĐỊNH NGHĨA BẢO VỆ (Navigation Guard)
// Đây là logic *thuộc về* router, nên để ở đây là hợp lý
router.beforeEach((to, from, next) => {
    const isAuthenticated = localStorage.getItem('admin-token');

    if (to.name === 'Login') {
        if (isAuthenticated) {
            next({ name: 'Dashboard' });
        } else {
            next();
        }
    } else {
        if (isAuthenticated) {
            next();
        } else {
            next({ name: 'Login' });
        }
    }
});