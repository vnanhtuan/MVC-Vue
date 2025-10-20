import api from '../api.js';

// 1. Tải template HTML
const response = await fetch('/components/admin/product-list.html');
const templateHtml = await response.text();

// 2. Export một đối tượng component hoàn chỉnh
export const ProductListPage = {
    template: templateHtml,
    data() {
        return {
            products: [],
            loading: true,
            totalItems: 0,
            pageSize: 10,
            currentPage: 1,
            
            headers: [
                { title: 'STT', key: 'stt', sortable: false, width: '80px' },
                { title: 'Ảnh', key: 'imageUrl', sortable: false },
                { title: 'Tên Sản Phẩm', key: 'name' },
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
        editProduct(item) {
            console.log('Edit:', item.name);
        },
        deleteProduct(item) {
            console.log('Delete:', item.name);
        }
    }
};