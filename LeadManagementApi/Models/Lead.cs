using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementApi.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public int Phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Suburb { get; set; }
        [Column(TypeName = "dateTime2")]
        public DateTime Date { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Status { get; set; } 

    }
}
