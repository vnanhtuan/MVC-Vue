// 1. Tạo một instance Axios
const api = axios.create({
    baseURL: '/' // URL gốc cho mọi API call
});

// 2. TẠO MỘT "REQUEST INTERCEPTOR" (BỘ ĐÁNH CHẶN REQUEST)
// Đoạn code này sẽ chạy TRƯỚC KHI bất kỳ request nào được gửi đi
api.interceptors.request.use(
    (config) => {
        // 3. Lấy token từ localStorage
        const token = localStorage.getItem('admin-token');
        
        // 4. Nếu token tồn tại, gán nó vào header
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        
        return config; // Gửi request đi với header mới
    }, 
    (error) => {
        // Xử lý lỗi
        return Promise.reject(error);
    }
);

// 5. Export instance đã được cấu hình
export default api;