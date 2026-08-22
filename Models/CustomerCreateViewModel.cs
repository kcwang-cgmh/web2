using System.ComponentModel.DataAnnotations;

namespace web2.Models;

/// <summary>
/// 「新增客戶」表單專用的輸入模型（ViewModel）。
///
/// ViewModel 與 Customer 資料庫實體分開，讓表單只接受此頁面需要的欄位，
/// 也能在不影響資料庫模型的情況下定義表單專用的驗證規則。
/// </summary>
public class CustomerCreateViewModel : IValidatableObject
{
  /// <summary>
  /// 客戶姓名。必填，最多 100 個字元。
  /// </summary>
  [Required(ErrorMessage = "請輸入姓名。")]
  [StringLength(100, ErrorMessage = "姓名不可超過 100 個字元。")]
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// 客戶出生日期。使用可為 null 的型別，讓 Required 驗證能辨識空白輸入。
  /// </summary>
  [Required(ErrorMessage = "請輸入出生日期。")]
  [DataType(DataType.Date)]
  public DateTime? Birthdate { get; set; }

  /// <summary>
  /// 客戶照片網址，可省略，最多 2048 個字元。
  /// </summary>
  [Url(ErrorMessage = "請輸入有效的照片網址。")]
  [StringLength(2048, ErrorMessage = "照片網址不可超過 2048 個字元。")]
  public string? Photo { get; set; }

  /// <summary>
  /// 執行無法只靠單一屬性標註完成的跨欄位或條件式驗證。
  /// </summary>
  /// <param name="validationContext">目前驗證作業的內容。此範例不需要使用它。</param>
  /// <returns>驗證失敗時回傳對應欄位的錯誤；驗證成功時不回傳任何結果。</returns>
  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  {
    // 出生日期不應晚於今天；此規則會在伺服器端再次執行，不能只依賴瀏覽器驗證。
    if (Birthdate > DateTime.Today)
    {
      yield return new ValidationResult(
          "出生日期不可晚於今天。",
          new[] { nameof(Birthdate) });
    }
  }
}