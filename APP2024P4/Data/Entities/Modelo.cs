using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APP2024P4.Data.Entities
{
    [Table("Modelos")]
    public class Modelo
    {
        [Key]
        public int Id { get; set; }
        public string NombreM { get; set; } = null!;
        public int MarcaId { get; set; }

        public static Modelo Create(string nombreM)
            => new()
            {
                NombreM = nombreM
            };
        public bool Update(string nombreM)
        {
            var save = false;
            if (NombreM != nombreM)
            {
                NombreM = nombreM; save = true;
            }
            return save;
        }
        [ForeignKey(nameof(MarcaId))]
        public virtual Marca? Marca { get; set; }
    }
}
