namespace SB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classification")]
    public partial class Classification
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
