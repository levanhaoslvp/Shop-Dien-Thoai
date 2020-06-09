namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTDETAIL")]
    public partial class PRODUCTDETAIL
    {
        [Key]
        public int DetailID { get; set; }

        public int? ProductID { get; set; }

        public int? OptionID { get; set; }

        public virtual OPTION OPTION { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
