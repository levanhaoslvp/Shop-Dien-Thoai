namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTIMAGE")]
    public partial class PRODUCTIMAGE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageID { get; set; }

        public string DetailImage_1 { get; set; }

        public string DetailImage_2 { get; set; }

        public string DetailImage_3 { get; set; }

        public int? ProductID { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
