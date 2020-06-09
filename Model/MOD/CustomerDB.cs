using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Model.MOD
{
    public class CustomerDB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        public String PassWord { get; set; }
        public string RePassword { get; set; }

        public String Email { get; set; }
        public String FullName { get; set; }
        public String Phone { get; set; }
        public String Adress { get; set; }
        public DateTime Date { get; set; }
    }
}
