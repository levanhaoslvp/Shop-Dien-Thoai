namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OPTION")]
    public partial class OPTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPTION()
        {
            ORDERDETAILs = new HashSet<ORDERDETAIL>();
            PRODUCTDETAILs = new HashSet<PRODUCTDETAIL>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OptionID { get; set; }

        [StringLength(255)]
        public string OptionName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTDETAIL> PRODUCTDETAILs { get; set; }
    }
}
