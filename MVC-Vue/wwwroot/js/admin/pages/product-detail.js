import api from '../api.js';

const response = await fetch('/components/admin/product-detail.html');
const templateHtml = await response.text();

// Hàm tạo một object product rỗng
function createNewProduct() {
    return {
        id: 0,
        name: '',
        sku: '',
        description: '',
        price: 0,
        discount: 0,
        quantity: 0,
        categoryId: null, // Mặc định category 1
        images: [] // Mảng ảnh rỗng,
    };
}

export const ProductDetailPage = {
    template: templateHtml,
    data() {
        return {
            product: null,
            loading: true,
            isEditMode: false,
            isUploading: false,
            imageInputFiles: [],
            categories: []
        };
    },
    computed: {
        title() {
            return this.isEditMode ? 'Cập nhật Sản phẩm' : 'Tạo Sản phẩm Mới';
        }
    },
    mounted() {
        // Lấy ID sản phẩm từ URL (ví dụ: /manage/products/1)
        const productId = this.$route.params.id;
        if (productId === 'new') {
            this.isEditMode = false;
            this.product = createNewProduct(); // Create object empty
            this.loading = false;
        } else {
            this.isEditMode = true;
            this.fetchProduct(productId);
        }
        this.fetchCategories();
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

        async fetchCategories() {
            this.loading = true;
            try {
                const response = await api.get('/api/admin/categories');
                this.categories = response.data;
            } catch (err) {
                console.error('Lỗi khi tải danh mục:', err);
            } finally {
                this.loading = false;
            }
        },

        // --- THÊM HÀM NÀY VÀO ---
        async handleImageUpload(files) {
            if (!files || files.length === 0) return;
            
            this.isUploading = true;
            
            for (const file of files) {
                // Tạo FormData để gửi file
                const formData = new FormData();
                formData.append('file', file);

                try {
                    // Gọi API upload ảnh
                    const response = await api.post('/api/admin/images/upload', formData, {
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    });
                    console.log('url', response.data.url);
                    // Thêm URL tạm trả về vào mảng và hiển thị thumbnail
                    //this.product.images.push();

                    this.product.images.push({ url: response.data.url, publicId: response.data.publicId });

                } catch (err) {
                    console.error('Lỗi upload ảnh:', err);
                }
            }
            
            this.isUploading = false;

            this.imageInputFiles = [];
        },

        // --- THÊM HÀM NÀY VÀO ---
        removeImage(index) {
            // Xóa ảnh khỏi mảng (cả ảnh cũ và ảnh tạm)
            this.product.images.splice(index, 1);
        },
        // Hàm lưu thay đổi
        async saveProduct() {
            const productData = {
                name: this.product.name,
                sku: this.product.sku,
                description: this.product.description,
                price: this.product.price,
                discount: this.product.discount,
                quantity: this.product.quantity,
                categoryId: this.product.categoryId,
                // Lấy danh sách URL
                images: this.product.images.map(img => ({
                    url: img.url,
                    publicId: img.publicId
                }))
            };

            try {
                if (this.isEditMode) {
                    // === CHẠY API UPDATE ===
                    await api.put(`/api/admin/products/${this.product.id}`, productData);
                } else {
                    // === CHẠY API CREATE ===
                    await api.post('/api/admin/products', productData);
                }

                // Sau khi lưu thành công, quay về trang danh sách
                this.goBack();
            } catch (err) {
                console.error('Lỗi khi lưu sản phẩm:', err);
                // (Nên hiển thị thông báo lỗi cho người dùng)
            }
        },
        // Hàm quay về trang danh sách
        goBack() {
            this.$router.push({ name: 'Products' });
        }
    }
};