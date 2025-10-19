// Đường dẫn import giờ là file './admin-router.js' cùng cấp
import { router } from './admin-router.js'; 
import { vuetify } from '../plugins/vuetify.js';

// 2. Định nghĩa Root Component của Admin App
// Component này sẽ chứa <router-view> cho các trang admin
const AdminApp = {
    template: `
      <router-view></router-view>
    `
};

// ... (code tạo app Vue) ...
const app = Vue.createApp(AdminApp);
app.use(vuetify);
app.use(router);
app.mount('#admin-app');