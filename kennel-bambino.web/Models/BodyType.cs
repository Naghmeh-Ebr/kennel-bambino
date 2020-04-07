using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kennel_bambino.web.Models
{
    public class BodyType
    {
        [Key]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        #region Relation - Navigation Properties
        public ICollection<Pet> Pets { get; set; }
        #endregion

    }
}