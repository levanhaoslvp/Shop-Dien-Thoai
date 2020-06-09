using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    public class OptionModel
    {
        public int optionid { get; set; }
        public string optionname { get; set; }
       
    }
}