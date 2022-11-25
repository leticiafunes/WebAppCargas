using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCargas.Models
{


    /*Eager loading (carga diligente) 
    Al obtener un producto, le indicas que también deseas que te incluya los datos de la categoría. 
    Para esto debes incluir un objeto virtual de la tabla categoria en tu tabla producto. */

    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(1, 999, ErrorMessage = "Range")]
        public int Clave { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "VARCHAR(80)")]
        public string Nombre { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
