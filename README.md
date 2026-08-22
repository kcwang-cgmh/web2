## 安裝 EntityFramework 相關套件

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

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

## 委派（Delegate） 與 Lambda 運算式（Lambda expression)

```csharp
DateTime CallMe1(int x, int y, string name)
{
    return x + y > 0 ? DateTime.Now : DateTime.MinValue;
}

DateTime CallMe2(int x, int y, string name)
{
    return x + y <= 0 ? DateTime.Now : DateTime.MinValue;
}

void Test(Func<int, int, string, DateTime> obj)
{
    
}

Test(
    delegate(int x, int y, string name)
    {
        return x + y > 0 ? DateTime.Now : DateTime.MinValue;
    }
);

Test(
    (x, y, name) =>
    {
        return x + y > 0 ? DateTime.Now : DateTime.MinValue;
    }
);


Test(
    (x, y, name) => x + y > 0 ? DateTime.Now : DateTime.MinValue
);

```



## Prompts

- `請幫我將連線字串放到設定檔`
- `幫我加入一個路由 /Customers/Create 與檢視，用來新增 Customer 資料`
