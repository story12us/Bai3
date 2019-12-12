# Bài số 3 của thầy Cường
1. Tải DB : 
    git clone https://github.com/TechMaster/AutoRestorePostgresql.git
2. Tạo DB  Postgresql và restore dữ liệu:
    - cd AutoRestorePostgresql
    - sh ./restore.sh
    - Kết quả nếu ok sẽ thấy được 5 records show lên màn hình.
    - docker ps --> Thấy có image postgres:latest là ok
2. Tải men_spa về:
    git clone --single-branch --branch 04_men_spa_form https://github.com/TechMaster/aspnetcore.git
    - Ở branch này thầy Cường đã thêm các phần kết nối với DB Postgresql nên các bạn ko cần sửa gì nữa.
3. Tạo docker chạy asp core và add dự án men_spa vào
    a. cd aspnetcore/men_spa
    b. tạo file Dockerfile --> Sử dụng Visual Studio Code hoặc lệnh vi Dockerfile

***
```shell
COPY *.csproj ./
RUN dotnet restore "./men_spa.csproj"

COPY . ./
RUN dotnet build "men_spa.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "men_spa.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 5001

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "men_spa.dll"]
```
***

## Build docker
    docker build --target build -t menspa .
## Run docker
    docker run -d -p 8080:80 -it menspa ls /app
## Mở trình duyệt gõ 
    http://localhost:8080

### Note
Để tạo docker nhỏ hơn, ta có thể bỏ qua các thư mục bin\ obj\ bằng cách tạo file .dockerignore