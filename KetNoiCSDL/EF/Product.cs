namespace KetNoiCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Image = "/Anh/add.jpg";
        }
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long Insert(object user)
        {
            throw new NotImplementedException();
        }

        [StringLength(500)]
        public string Description { get; set; }
     
        [DisplayName("Upload Image")]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
     

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool? IncludeVAT { get; set; }

        public int? Quanlity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifieldDate { get; set; }

        [StringLength(50)]
        public string ModifieldBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }
       
    }
}
