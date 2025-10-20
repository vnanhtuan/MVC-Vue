const response = await fetch('/components/admin/dashboard-layout.html');
const templateHtml = await response.text();

export const DashboardPage = {
    template: templateHtml,
    methods: {
        handleLogout() {
            localStorage.removeItem('admin-token');
            this.$router.push({ name: 'Login' });
        }
    }
};