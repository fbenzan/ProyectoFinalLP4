using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APP2024P4.Data.Entities
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string NombreMc { get; set; } = null!;


        public static Marca Create(string nombreMc)
            => new()
            {
                NombreMc = nombreMc
            };
        public bool Update(string nombreMc)
        {
            var save = false;
            if (NombreMc != nombreMc)
            {
                NombreMc = nombreMc; save = true;
            }
            return save;
        }
    }
}
