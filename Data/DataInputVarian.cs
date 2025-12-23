using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication2.Data
{
    public class DataInputVarian
    {
        [Key]
        public int ID_DataInputVarian { get; set; }

        [Column(TypeName = "varchar(128)")]
        public double Num1 { get; set; }

        [Column(TypeName = "varchar(128)")]
        public double Num2 { get; set; }

        [Column(TypeName = "varchar(128)")]
        public Operation operation { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string? Result { get; set; }
    }
}
   