import api from '../api.js';

const response = await fetch('/components/admin/category-list.html');
const templateHtml = await response.text();

export const CategoryListPage = {
    template: templateHtml,
    data() {
        return {
            loading: true,
            categories: [],
            dialog: false,
            dialogDelete: false,
            headers: [
                { title: 'ID', key: 'id' },
                { title: 'Tên danh mục', key: 'name' },
                { title: 'Đường dẫn (Slug)', key: 'slug' },
                { title: 'Actions', key: 'actions', sortable: false }
            ],
            editedIndex: -1,
            editedItem: {
                id: 0,
                name: '',
                slug: ''
            },
            defaultItem: {
                id: 0,
                name: '',
                slug: ''
            }
        };
    },
    computed: {
        formTitle() {
            return this.editedIndex === -1 ? 'Tạo mới Danh mục' : 'Sửa Danh mục';
        }
    },
    mounted() {
        this.fetchCategories();
    },
    methods: {
        async fetchCategories() {
            this.loading = true;
            try {
                const response = await api.get('/api/admin/categories');
                this.categories = response.data;
            } catch (err) {
                console.error(err);
            } finally {
                this.loading = false;
            }
        },

        openNewDialog() {
            this.editedItem = Object.assign({}, this.defaultItem);
            this.editedIndex = -1;
            this.dialog = true;
        },

        openEditDialog(item) {
            this.editedIndex = this.categories.indexOf(item);
            this.editedItem = Object.assign({}, item);
            this.dialog = true;
        },

        openDeleteDialog(item) {
            this.editedItem = Object.assign({}, item);
            this.dialogDelete = true;
        },

        closeDialog() {
            this.dialog = false;
        },

        closeDeleteDialog() {
            this.dialogDelete = false;
        },

        async save() {
            try {
                if (this.editedIndex > -1) {
                    // Update
                    await api.put(`/api/admin/category/${this.editedItem.id}`, { name: this.editedItem.name });
                } else {
                    // Create
                    await api.post('/api/admin/category', { name: this.editedItem.name });
                }
                this.fetchCategories(); // Tải lại dữ liệu
            } catch (err) {
                console.error(err);
            }
            this.closeDialog();
        },

        async deleteItemConfirm() {
            try {
                await api.delete(`/api/admin/category/${this.editedItem.id}`);
                this.fetchCategories(); // Tải lại dữ liệu
            } catch (err) {
                console.error(err);
            }
            this.closeDeleteDialog();
        }
    }
};