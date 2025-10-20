import api from '../api.js';

const response = await fetch('/components/admin/product-detail.html');
const templateHtml = await response.text();

export const ProductDetailPage = {
    template: templateHtml,
    data() {
        return {
            product: null,
            loading: true,
        };
    },
    // mounted(): Chạy khi component được tải
    mounted() {
        // Lấy ID sản phẩm từ URL (ví dụ: /manage/products/1)
        const productId = this.$route.params.id;
        if (productId) {
            this.fetchProduct(productId);
        }
    },
    methods: {
        // Hàm lấy dữ liệu từ API
        async fetchProduct(id) {
            this.loading = true;
            try {
                const response = await api.get(`/api/admin/products/${id}`);
                this.product = response.data;
            } catch (err) {
                console.error('Lỗi khi tải chi tiết sản phẩm:', err);
                // Có thể thêm logic điều hướng về trang 404
            } finally {
                this.loading = false;
            }
        },
        // Hàm lưu thay đổi
        async saveProduct() {
            if (!this.product) return;
            try {
                // Gọi API PUT để cập nhật
                await api.put(`/api/admin/products/${this.product.id}`, this.product);
                // Sau khi lưu thành công, quay về trang danh sách
                this.goBack();
            } catch (err) {
                console.error('Lỗi khi lưu sản phẩm:', err);
            }
        },
        // Hàm quay về trang danh sách
        goBack() {
            this.$router.push({ name: 'Products' });
        }
    }
};