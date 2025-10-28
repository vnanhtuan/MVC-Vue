import api from '../api.js';

// 1. Tải template HTML
const response = await fetch('/components/admin/product-list.html');
const templateHtml = await response.text();

// 2. Export một đối tượng component hoàn chỉnh
export const ProductListPage = {
    template: templateHtml,
    components: { // <-- 2. ĐĂNG KÝ EDIT DRAWER LÀ COMPONENT CON
         
    },
    data() {
        return {
            products: [],
            loading: true,
            totalItems: 0,
            pageSize: 10,
            currentPage: 1,

            // --- THÊM CÁC BIẾN QUẢN LÝ EDIT DRAWER ---
            isDrawerOpen: false,
            editingProductId: null,
            
            headers: [
                { title: 'STT', key: 'stt', sortable: false, width: '50px' },
                { title: 'SKU', key: 'sku', sortable: false, width: '100px' },
                { title: 'Ảnh', key: 'imageUrl', sortable: false },
                { title: 'Tên Sản Phẩm', key: 'name' },
                { title: 'Mô tả', key: 'description', sortable: false, width: '250px' },
                { title: 'Danh mục', key: 'categoryName' },
                { title: 'Số Lượng', key: 'quantity' },
                { title: 'Kích Cỡ', key: 'sizes', sortable: false },
                { title: 'Giảm giá', key: 'discount' },
                { title: 'Actions', key: 'actions', sortable: false },
            ],
        };
    },
    methods: {
        async fetchProducts({ page, itemsPerPage, sortBy }) {
            this.loading = true;
            this.currentPage = page; 
            this.pageSize = itemsPerPage;
            
            try {
                const response = await api.get('/api/admin/products', {
                    params: {
                        pageNumber: page,
                        pageSize: itemsPerPage
                    }
                });
                
                this.products = response.data.items;
                this.totalItems = response.data.totalItems;
            } catch (err) {
                console.error('Lỗi khi tải sản phẩm:', err);
            } finally {
                this.loading = false;
            }
        },
        createProduct() {
            this.$router.push({ name: 'ProductDetail', params: { id: 'new' } });
        },
        editProduct(item) {
            // Dùng router để điều hướng sang trang chi tiết
            // và truyền ID vào params
            this.$router.push({ name: 'ProductDetail', params: { id: item.id } });
        },
        deleteProduct(item) {
            console.log('Delete:', item.name);
        },
        // THÊM HÀM NÀY VÀO
        truncateText(text, length) {
            if (!text) {
                return '';
            }
            if (text.length <= length) {
                return text;
            }
            // Cắt chuỗi và thêm "..."
            return text.substring(0, length) + '...';
        },

        
    }
};