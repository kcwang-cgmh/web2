using Microsoft.AspNetCore.Mvc;
using web2.Models;

namespace web2.Controllers;

/// <summary>
/// 提供 Customer 相關的 HTTP 請求處理功能。
///
/// 目前此控制器示範如何顯示新增客戶表單，以及接收表單資料並寫入資料庫。
/// 因為控制器名稱是 CustomersController，ASP.NET Core MVC 會將它對應到
/// /Customers 路由前綴，因此 Create Action 的網址是 /Customers/Create。
/// </summary>
public class CustomersController : Controller
{
  // 由 ASP.NET Core 依賴注入容器提供 DbContext，供 Action 存取 Customers 資料表。
  private readonly MyDbContext _context;

  /// <summary>
  /// 建立 CustomersController。
  /// </summary>
  /// <param name="context">已設定 SQL Server 連線的 Entity Framework Core DbContext。</param>
  public CustomersController(MyDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public IActionResult Index()
  {
    return View(_context.Customers.ToList());
  }

  /// <summary>
  /// 顯示新增客戶表單。
  /// </summary>
  /// <remarks>
  /// 預先填入今天的日期，作為使用者開啟表單時的初始值。
  /// </remarks>
  [HttpGet]
  public IActionResult Create()
  {
    return View(new CustomerCreateViewModel { Birthdate = DateTime.Today });
  }

  /// <summary>
  /// 驗證並儲存新增客戶表單送出的資料。
  /// </summary>
  /// <param name="model">由表單繫結而來，並包含驗證規則的輸入模型。</param>
  /// <returns>
  /// 驗證失敗時重新顯示原表單；儲存成功後重新導向至新增客戶頁面。
  /// </returns>
  /// <remarks>
  /// ValidateAntiForgeryToken 可避免第三方網站偽造表單請求。
  /// 只有通過 ModelState 驗證後，才會將 ViewModel 轉換成資料庫使用的 Customer 實體。
  /// </remarks>
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(CustomerCreateViewModel model)
  {
    // ModelState 會包含資料繫結結果、Data Annotations 與自訂驗證結果。
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    // 使用明確的欄位對應，避免直接將表單輸入繫結至資料庫實體。
    var customer = new Customer
    {
      Name = model.Name,
      Birthdate = model.Birthdate!.Value,
      Photo = model.Photo
    };

    // Add 只會將實體標記為待新增；SaveChangesAsync 才會實際執行 INSERT。
    _context.Customers.Add(customer);
    await _context.SaveChangesAsync();

    // 使用 PRG（Post-Redirect-Get）流程，避免使用者重新整理頁面時重複送出表單。
    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var obj = _context.Customers.Find(id);

    if (obj is null)
    {
      return NotFound();
    }

    return View(obj);
  }

  // POST: /Customers/Edit
  [HttpPost]
  public IActionResult Edit(int id, Customer obj)
  {
    obj.CustomerID = id;
    _context.Customers.Update(obj);
    _context.SaveChanges();

    return RedirectToAction("Index");
  }

  public IActionResult Delete(int id)
  {
    var obj = _context.Customers.Find(id);
    _context.Customers.Remove(obj!);
    _context.SaveChanges();

    return RedirectToAction("Index");
  }
}