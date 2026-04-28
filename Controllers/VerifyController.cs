using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
    /// <summary>
    /// TOR 1.7(29): หน้า verify สาธารณะ — ไม่ต้อง login
    /// แสดงสถานะใบรับรองจากเลขที่ใบรับรอง (เข้าถึงผ่าน QR Code)
    /// </summary>
    public class VerifyController : Controller
    {
        // GET /Verify/{certNo}
        [HttpGet("/Verify/{certNo?}")]
        public IActionResult Index(string certNo)
        {
            ViewData["CertNo"] = certNo ?? "";
            return View();
        }
    }
}
