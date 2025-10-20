import api from '../api.js';

const response = await fetch('/components/admin/login.html');
const templateHtml = await response.text();

export const LoginPage = {
    template: templateHtml,
    data() {
        return {
            email: '',
            password: '',
            error: null
        };
    },
    methods: {
        async handleLogin() {
            this.error = null;
            try {
                const response = await api.post('/api/admin/auth/login', {
                    email: this.email,
                    password: this.password
                });
                localStorage.setItem('admin-token', response.data.token);
                this.$router.push({ name: 'Dashboard' });
            } catch (err) {
                this.error = 'Đăng nhập thất bại.';
            }
        }
    }
};