## 安裝 ef cli
dotnet tool install --global dotnet-ef

## migration 指令
dotnet ef migrations add <自訂的 migration 名稱>

⚠️ migration 名稱不能重複

## 建立資料庫內容
dotnet ef database update

## SQL資料庫認證
Server=localhost,1433;Database=MyDb;User Id=sa;Password=pass@word1234;TrustServerCertificate=True;

⚠️ 密碼可能有 pass@word1234 或 pass@wowrd1234 兩種，記得改成你本機正確的版本

## Windows 身分驗證
Server=localhost,1433;Database=MyDb;Integrated Security=True;TrustServerCertificate=True;
