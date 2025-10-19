// Đường dẫn tiện ích loaders.js giờ phải lùi ra 1 cấp
import { loadComponent } from '../utils/loaders.js'; 

// Sửa lại đường dẫn load component
const LoginPageTemplate = await loadComponent('/components/admin/login-page.html');
const DashboardPageTemplate = await loadComponent('/components/admin/dashboard-page.html')

const LoginPage = {
    ...LoginPageTemplate, // Spread the template and generic data/methods
    data() {
        return {
            email: '',
            password: ''
        };
    },
    methods: {
        handleLogin() {
            // --- LOGIC ĐĂNG NHẬP Ở ĐÂY ---
            console.log('Attempting to log in with:', this.email, this.password);
            
            // Giả lập đăng nhập thành công
            if (this.email === 'admin@test.com' && this.password === '123456') {
                console.log('Login successful!');
                // Lưu token vào localStorage
                localStorage.setItem('admin-token', 'your-secret-jwt-token');
                // Chuyển hướng đến trang dashboard
                this.$router.push({ name: 'Dashboard' }); 
            } else {
                alert('Sai email hoặc mật khẩu!');
            }
        }
    }
};

const DashboardPage = {
    ...DashboardPageTemplate,
    methods: {
        handleLogout() {
            // --- LOGIC ĐĂNG XUẤT Ở ĐÂY ---
            console.log('Logging out...');
            // Xóa token
            localStorage.removeItem('admin-token');
            // Chuyển hướng về trang login
            this.$router.push({ name: 'Login' });
        }
    }
};

// Định nghĩa các route cho trang admin
const routes = [
    { 
        path: '/manage/login', 
        name: 'Login',
        component: LoginPage 
    },
    { 
        path: '/manage', // URL gốc của admin
        name: 'Dashboard',
        component: DashboardPage 
    },
    // Ví dụ các route con
    // { path: '/manage/products', component: ProductManagePage },
    // { path: '/manage/orders', component: OrderManagePage },
];

export const router = window.VueRouter.createRouter({
    history: window.VueRouter.createWebHistory(),
    routes,
    scrollBehavior() {
      return { top: 0 } // Luôn cuộn lên đầu khi chuyển trang
    }
});

// --- PHẦN QUAN TRỌNG NHẤT: NAVIGATION GUARD ---
router.beforeEach((to, from, next) => {
    // 1. Kiểm tra xem người dùng đã đăng nhập chưa
    // (ví dụ: kiểm tra token trong localStorage)
    const isAuthenticated = localStorage.getItem('admin-token');

    // 2. Nếu người dùng đang cố vào trang login
    if (to.name === 'Login') {
        if (isAuthenticated) {
            // Nếu đã login, đá về trang Dashboard
            next({ name: 'Dashboard' });
        } else {
            // Nếu chưa login, cho phép vào trang login
            next();
        }
    } 
    // 3. Nếu người dùng đang cố vào trang khác (như Dashboard)
    else {
        if (isAuthenticated) {
            // Nếu đã login, cho phép vào
            next();
        } else {
            // Nếu chưa login, đá về trang Login
            next({ name: 'Login' });
        }
    }
});