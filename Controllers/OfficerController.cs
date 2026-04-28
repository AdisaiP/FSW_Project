using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers;

public class OfficerController : Controller
{
  private readonly IWebHostEnvironment _env;

  public OfficerController(IWebHostEnvironment env)
  {
    _env = env;
  }

  // --- เอกสาร RMBS1 ---

  // 2.1 ออกเอกสารควบคุมปริมาณวัตถุดิบ (RMBS1 สถานะ PS)
  public IActionResult IndexRMBS1PS()
  {
    return View();
  }

  public IActionResult ReviewRMBS1PS()
  {
    return View();
  }

  // 2.1(11) เปลี่ยนผลการพิจารณา / ยกเลิกการออก RMBS1:PS (กรณีออกใบรับรองแล้ว)
  public IActionResult IndexChangeRMBS1PS()
  {
    return View();
  }

  public IActionResult ReviewChangeRMBS1PS()
  {
    return View();
  }

  // 2.2 พิจารณาอนุมัติ %Yield
  public IActionResult IndexApproveYield()
  {
    return View();
  }

  public IActionResult ReviewApproveYield()
  {
    return View();
  }

  // 2.3 เอกสารการควบคุมปริมาณสินค้า เอกสารที่ 1
  public IActionResult IndexQuantityControl()
  {
    return View();
  }

  public IActionResult ReviewQuantityControl()
  {
    return View();
  }

  // --- ใบรับรอง PS/NMD ---

  // 2.4 ออกใบรับรอง Processing Statement / Non-Manipulation Document
  public IActionResult IndexIssueCertificate()
  {
    return View();
  }

  // 2.5 พิจารณาการขอเปลี่ยนแปลงใบรับรอง
  public IActionResult IndexReviewChange()
  {
    return View();
  }
  public IActionResult ReviewUpdateCertificate()
  {
    return View();
  }

  // 2.6 พิจารณาออกใบรับรอง Declaration
  public IActionResult ReviewDeclaration()
  {
    return View();
  }

  // 2.6 พิจารณาออกใบรับรองทดแทนฉบับเก่า
  public IActionResult IndexReplacement()
  {
    return View();
  }
  public IActionResult ReviewReplacementDeclaration()
  {
    return View();
  }
  public IActionResult ReviewReplacementProcessing()
  {
    return View();
  }

  // 2.7 พิจารณายกเลิกใบรับรอง
  public IActionResult IndexRevoke()
  {
    return View();
  }
  // 2.7(4)+(5): พิจารณาคำขอยกเลิก + คืนน้ำหนัก/โควตา
  public IActionResult ReviewRevoke()
  {
    return View();
  }

  // 2.8 พิจารณาคืนน้ำหนักสินค้าสัตว์น้ำ
  public IActionResult IndexReturnWeight()
  {
    return View();
  }
  public IActionResult ReviewReturnWeight()
  {
    return View();
  }

  // 2.9 ค้นหาใบรับรอง Processing Statement / Non-Manipulation Document
  public IActionResult IndexSearchCertificate()
  {
    return View();
  }

  // 2.9.1 รายละเอียดใบรับรองที่ผ่านตรวจปล่อย (2.4(19))
  public IActionResult ReviewInspectedCertificate()
  {
    return View();
  }

  // 2.9.2 เสนอลงนามใบรับรอง (2.4(20)) — reuses IndexIssueCertificate view with enhanced propose workflow
  public IActionResult ProposeSign()
  {
    return View("IndexIssueCertificate");
  }

  // 2.4(26) ตรวจสอบสถานะใบรับรองออนไลน์จาก QR Code (public)
  public IActionResult VerifyCertificate(string certno = "")
  {
    ViewData["CertNo"] = certno;
    return View();
  }

  // 2.10 ค้นหาใบสำรองตนเอง
  public IActionResult IndexSearchSelfDecl()
  {
    return View();
  }

  // --- จัดการระบบ ---

  // 2.11 รายงาน Static และ Dynamic
  public IActionResult IndexReports()
  {
    return View();
  }

  // 2.12 ค้นหาข้อมูลผู้เข้าใช้งาน
  public IActionResult IndexUserData()
  {
    return View();
  }

  // 2.13(1) จัดการสิทธิ์และพื้นที่ความรับผิดชอบ
  public IActionResult IndexAccessRights()
  {
    return View();
  }

  // 2.13(2) ศูนย์แจ้งเตือนคำขอค้างดำเนินการ
  public IActionResult IndexPendingNotifications()
  {
    return View();
  }

  // 2.13 สถิติการใช้งาน
  public IActionResult IndexStatistics()
  {
    return View();
  }

  // 2.14 ลงทะเบียนผู้ใช้ในนามผู้เข้าใช้งาน
  public IActionResult IndexRegisterUser()
  {
    return View();
  }

  // 2.15 กำหนดรูปแบบการจัดทำใบรับรอง
  public IActionResult IndexCertTemplate()
  {
    return View();
  }
}
