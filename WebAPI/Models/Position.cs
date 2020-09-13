using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        public int? ParentPositionId { get; set; }

        [ForeignKey("ParentPositionId")]
        public virtual Position ParentPosition { get; set; }

        public virtual ICollection<Position> ChildrenPosition { get; set; }
    }
}
