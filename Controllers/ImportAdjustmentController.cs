using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using System.Security.Claims;

namespace AspnetCoreMvcFull.Controllers;

public class ImportAdjustmentController : Controller
{
  private readonly IWebHostEnvironment _env;
  private const string FactoryOperatorTypeThai = "โรงงาน";

  public ImportAdjustmentController(IWebHostEnvironment env)
  {
    _env = env;
  }

  private static bool IsFactoryOperatorType(string? operatorType)
  {
    if (string.IsNullOrWhiteSpace(operatorType))
    {
      return false;
    }

    var normalized = operatorType.Trim().ToLowerInvariant();
    return normalized == FactoryOperatorTypeThai || normalized == "factory";
  }

  private string ResolveOperatorType()
  {
    var fromClaims =
      User.FindFirst("OperatorType")?.Value
      ?? User.FindFirst("operator_type")?.Value
      ?? User.FindFirst(ClaimTypes.Role)?.Value;

    var fromQuery = Request.Query["operatorType"].ToString();

    return !string.IsNullOrWhiteSpace(fromClaims)
      ? fromClaims
      : (!string.IsNullOrWhiteSpace(fromQuery) ? fromQuery : FactoryOperatorTypeThai);
  }

  private string ResolveOperatorName()
  {
    var fromClaims =
      User.FindFirst("CompanyName")?.Value
      ?? User.FindFirst("company_name")?.Value
      ?? User.FindFirst("OperatorName")?.Value
      ?? User.Identity?.Name;

    var fromQuery = Request.Query["operatorName"].ToString();

    return !string.IsNullOrWhiteSpace(fromClaims)
      ? fromClaims
      : (!string.IsNullOrWhiteSpace(fromQuery) ? fromQuery : "Alpha Office Automation Co., Ltd.");
  }

  private void SetNoPsOperatorInfo(string operatorType, string operatorName)
  {
    ViewData["NoPsOperatorType"] = operatorType;
    ViewData["NoPsOperatorName"] = operatorName;
  }

  private IActionResult RenderNoPsAccessDenied()
  {
    ViewData["DeniedTitle"] = "คุณไม่มีสิทธิ์เข้าถึงหน้านี้";
    ViewData["DeniedMessage"] = "คุณไม่มีสิทธิ์เข้าถึงหน้านี้ เนื่องจากสถานะผู้ประกอบการไม่ใช่ โรงงาน";
    ViewData["BackUrl"] = Url.Action("Index", "Dashboards") ?? "/";
    return View("OperatorAccessDenied");
  }

  private void SetChangePsOperatorInfo(string operatorType, string operatorName)
  {
    ViewData["ChangePsOperatorType"] = operatorType;
    ViewData["ChangePsOperatorName"] = operatorName;
  }

  private IActionResult RenderChangePsAccessDenied()
  {
    ViewData["DeniedTitle"] = "คุณไม่มีสิทธิ์ขอเปลี่ยนสถานะ RMBS1 เป็น PS";
    ViewData["DeniedMessage"] = "หน้านี้สำหรับสถานประกอบการประเภทโรงงานเท่านั้น";
    ViewData["BackUrl"] = Url.Action("Index", "Dashboards") ?? "/";
    return View("OperatorAccessDenied");
  }

  public IActionResult IndexIMD()
  {
    return View();
  }

  public IActionResult CreateIMD()
  {
    return View();
  }

  public IActionResult IndexPurchase()
  {
    return View();
  }

  public IActionResult CreatePurchase()
  {
    return View();
  }

  public IActionResult IndexPost()
  {
    return View();
  }

  public IActionResult CreatePost()
  {
    return View();
  }

  public IActionResult IndexChangeCCSCC()
  {
    return View();
  }

  public IActionResult CreateChangeCCSCC()
  {
    return View();
  }

  public IActionResult IndexChangeRMBS1()
  {
    var operatorType = ResolveOperatorType();
    var operatorName = ResolveOperatorName();

    if (!IsFactoryOperatorType(operatorType))
    {
      return RenderChangePsAccessDenied();
    }

    SetChangePsOperatorInfo(operatorType, operatorName);
    return View();
  }

  public IActionResult CreateChangeRMBS1()
  {
    var operatorType = ResolveOperatorType();
    var operatorName = ResolveOperatorName();

    if (!IsFactoryOperatorType(operatorType))
    {
      return RenderChangePsAccessDenied();
    }

    SetChangePsOperatorInfo(operatorType, operatorName);
    return View();
  }

  public IActionResult IndexAdjustRMBS1PS()
  {
    return View();
  }

  public IActionResult CreateAdjustRMBS1PS()
  {
    return View();
  }

  public IActionResult IndexAdjustRMBS1NoPS()
  {
    var operatorType = ResolveOperatorType();
    var operatorName = ResolveOperatorName();

    if (!IsFactoryOperatorType(operatorType))
    {
      return RenderNoPsAccessDenied();
    }

    SetNoPsOperatorInfo(operatorType, operatorName);
    return View();
  }

  public IActionResult CreateAdjustRMBS1NoPS(string? mode)
  {
    var operatorType = ResolveOperatorType();
    var operatorName = ResolveOperatorName();

    if (!IsFactoryOperatorType(operatorType))
    {
      return RenderNoPsAccessDenied();
    }

    SetNoPsOperatorInfo(operatorType, operatorName);

    var normalizedMode = (mode ?? "view").Trim().ToLowerInvariant();
    if (normalizedMode != "view" && normalizedMode != "edit" && normalizedMode != "create")
    {
      normalizedMode = "view";
    }

    ViewData["NoPsFormMode"] = normalizedMode;
    return View();
  }

  // ── 1.5) คำขอพิจารณาอนุมัติ %Yield ──
  public IActionResult IndexYield()
  {
    return View();
  }

  public IActionResult CreateYield()
  {
    return View();
  }

  // ── 1.6) เอกสาร P1 — Product Balance Stock No.1 ──
  public IActionResult IndexP1()
  {
    return View();
  }

}
