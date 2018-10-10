namespace SB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastPurchase { get; set; }

        public int? ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public int? UserId { get; set; }
        public UserSys User{ get; set; }

        public enum GenderEnum
        {
            Masculine = 1,
            Feminine = 2
        }
    }
}
