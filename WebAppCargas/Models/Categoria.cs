using System.Collections.Generic;

namespace WebAppCargas.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        


        // Lazy Loading : Para obtener los productos de la categoría con el Id 1,
        // en nuestra clase Categoria agregamos una objeto que guardará la lista de Productos
       public virtual ICollection<Producto> Productos { get; set; }


        /*Internamente se crea una clase llamada Proxy, la cual sería similar a lo siguiente:
          public override Icollection<Producto> Productos
          {
          get
          {
            if (_productos == null) 
              _productos = context.CargarProductos();
          
          return productos;
           }
         }*/
    }
}
