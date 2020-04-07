using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Models
{
    public class Pattern
    {
        [Key]
        public int PatternId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        #region Relation - Navigation Properties
        public ICollection <Pet> Pets { get; set; }
        #endregion
    }
}
