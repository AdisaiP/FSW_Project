using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models
{
    /// <summary>
    /// Represents a foreign fishing vessel.
    /// </summary>
    public class ForeignVessel
    {
        public int Id { get; set; }

        [Display(Name = "ชื่อเรือ")]
        public string VesselName { get; set; }

        [Display(Name = "ทะเบียนเรือ")]
        public string VesselRegistration { get; set; }

        [Display(Name = "ประเทศธงเรือ")]
        public string FlagState { get; set; }

        [Display(Name = "เลข IMO")]
        public string ImoNumber { get; set; }

        [Display(Name = "Call Sign")]
        public string CallSign { get; set; }

        [Display(Name = "ขนาดเรือ (GT)")]
        public decimal GrossTonnage { get; set; }

        [Display(Name = "เจ้าของเรือ")]
        public string Owner { get; set; }

        [Display(Name = "ผู้แทน/เอเยนต์")]
        public string Agent { get; set; }

        [Display(Name = "ท่าเรือประจำ")]
        public string HomePort { get; set; }

        [Display(Name = "ท่าเรือปลายทาง")]
        public string DestinationPort { get; set; }

        [Display(Name = "สถานะข้อมูล")]
        public string Status { get; set; } // e.g., "ร่าง", "รอตรวจสอบ", "อนุมัติ"

        public List<VesselDocument> Documents { get; set; } = new List<VesselDocument>();
    }

    /// <summary>
    /// Represents a document attached to a foreign vessel.
    /// </summary>
    public class VesselDocument
    {
        public int Id { get; set; }
        public int ForeignVesselId { get; set; }

        [Display(Name = "ประเภทเอกสาร")]
        public string DocumentType { get; set; }

        [Display(Name = "เลขที่เอกสาร")]
        public string DocumentNumber { get; set; }

        [Display(Name = "วันหมดอายุ")]
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public string FilePath { get; set; }
    }

    /// <summary>
    /// ViewModel for the ForeignVesselDatabase page.
    /// </summary>
    public class ForeignVesselDatabaseViewModel
    {
        public ForeignVessel CurrentVessel { get; set; }
        public List<ForeignVessel> SavedVessels { get; set; }

        public ForeignVesselDatabaseViewModel()
        {
            CurrentVessel = new ForeignVessel();
            SavedVessels = new List<ForeignVessel>();
        }
    }
}
