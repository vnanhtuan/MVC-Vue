# ==============================
#  STAGE 1: BUILD & PUBLISH APP
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Thiết lập thư mục làm việc trong container
WORKDIR /src

# Copy riêng file .csproj để tận dụng cache layer restore
COPY ["MVC-Vue/MVC-Vue.csproj", "MVC-Vue/"]

# Khôi phục các gói NuGet cần thiết
RUN dotnet restore "MVC-Vue/MVC-Vue.csproj"

# Copy toàn bộ source code
COPY . .

# Chuyển đến thư mục project để build
WORKDIR "/src/MVC-Vue"

# Build và publish ra thư mục /app/publish (tối ưu, không kèm host binary)
RUN dotnet publish "MVC-Vue.csproj" -c Release -o /app/publish /p:UseAppHost=false


# ============================
#  STAGE 2: RUNTIME (NHẸ HƠN)
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Thiết lập thư mục chạy app
WORKDIR /app

# Copy kết quả publish từ stage build
COPY --from=build /app/publish .

# Mở port (tùy chọn, giúp gợi ý cổng khi deploy)
EXPOSE 80
EXPOSE 443

# Lệnh khởi chạy ứng dụng
ENTRYPOINT ["dotnet", "MyProject.dll"]
