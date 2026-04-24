using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
// เปลี่ยนตรงนี้
using AspnetCoreMvcFull.Models;           // เปลี่ยนตรงนี้
namespace AspnetCoreMvcFull.Controllers
{
    public class VesselChangeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ChangeRequestIndexViewModel();

            // จำลองข้อมูล (Mock Data) สำหรับแสดงในตารางตามรูปภาพ
            model.RequestItems = new List<ChangeRequestItemModel>
            {
                new ChangeRequestItemModel {
                    Id = "1", DocumentNo = "10501204016000002", DocumentName = "แบบรายงานผลการตรวจเรือ (เรือตั้งแต่ 10 แต่ไม่เกิน 100 ตันกรอส)",
                    EntrepreneurDetails = "Alpha Office Automation Co., Ltd. (สาขา 00002) (เลขประจำตัวผู้เสียภาษี: 0105522020392)",
                    Subject = "ขอเปลี่ยนแปลงข้อมูลผังเรือ (ขอแก้ไขข้อมูลผังเรือ)", TransactionDate = new DateTime(2017, 1, 10)
                },
                new ChangeRequestItemModel {
                    Id = "2", DocumentNo = "10501203516000030", DocumentName = "แบบรายงานผลการตรวจเรือ (เรือตั้งแต่ 100 ตันกรอส)",
                    EntrepreneurDetails = "Alpha Office Automation Co., Ltd. (สาขา 00002) (เลขประจำตัวผู้เสียภาษี: 0105522020392)",
                    Subject = "ขอเปลี่ยนแปลงข้อมูลผังเรือ (ขอแก้ไขข้อมูลผังเรือ)", TransactionDate = new DateTime(2017, 1, 13)
                },
                new ChangeRequestItemModel {
                    Id = "3", DocumentNo = "10501203516000032", DocumentName = "แบบรายงานผลการตรวจเรือ (เรือตั้งแต่ 10 ตันกรอส)",
                    EntrepreneurDetails = "Alpha Office Automation Co., Ltd. (สาขา 00002)",
                    Subject = "ขอเปลี่ยนแปลงข้อมูลผังเรือ (ขอแก้ไขข้อมูลผังเรือ)", TransactionDate = new DateTime(2017, 1, 20)
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(ChangeRequestIndexViewModel model)
        {
            // TODO: เขียนโค้ดสำหรับค้นหาข้อมูลจาก Database ตามเงื่อนไขที่ส่งมาจากฟอร์ม

            // ส่งข้อมูลกลับไปแสดงผลที่หน้าเดิม
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult TrackStatus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateLayoutChange()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestRefund()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForeignVesselPortEntry()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ImportAquaPlan()
        {
            return View("~/Views/AquaticImportCargo/ImportAquaPlan.cshtml");
        }

        [HttpGet]
        public IActionResult CreateTallySheet(string documentNo)
        {

            return View("~/Views/AquaticImportCargo/CreateTallySheet.cshtml");
        }

        [HttpGet]
        public IActionResult CargoRecord(string documentNo)
        {
            return View("~/Views/AquaticImportCargo/CargoRecord.cshtml");
        }

        [HttpGet]
        public IActionResult CreateCargoRecord(string documentNo)
        {
            return View("~/Views/AquaticImportCargo/CreateCargoRecord.cshtml");
        }

       [HttpGet]
        public IActionResult ForeignVesselDatabase(string documentNo )
        {
        
            return View();
        }
    }
}