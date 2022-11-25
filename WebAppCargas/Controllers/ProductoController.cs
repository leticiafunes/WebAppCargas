using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppCargas.Context;
using WebAppCargas.Models;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAppCargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public ProductoController(ApplicationDbContext context)
        {
            this.context = context;
        }



        [HttpGet("/eagerloading")]
        public IEnumerable<Producto> GetEagerLoading()
        {
            // EAGER LOADING - Todos los Productos con sus categorias incluidas!

            var productos = context.Productos.Include(p => p.Categoria).ToList();
            // .FirstOrDefaultAsync (p=> p.Id == id)    cuando quiero sólo por id

            

            return productos;

        }



        [HttpGet("/explicitloading")]
        public IEnumerable<Producto> GetExplicitLoading()
        {
            // EXPLICIT LOADING 
            // Aquí indicas que deseas cargar la información de las tablas relacionadas.
            // La diferencia es que con la primera forma se realiza con una sola query con un join y
            // en esta forma se hacen varias consultas a la base de datos.
            // Dependiendo de que tan complejo es la información que necesitas obtener
            // a veces es mejor realizar mas llamadas a la base de datos que una sola query muy compleja. 
            // Por ejemplo deseamos obtener todos los productos de la categoría con el Id 1.
            // Primero obtenemos la categoría con el Id 1.
            // El método Find lo que hace es que busca un registro por medio de su llave primaria, en este caso el Id.
            // El query generado es un select a la tabla categoría donde el id es 1


            var categoria = context.Categorias.Find(1);

            //Luego obtenemos todos los productos de esa categoría

            var productos =  context.Productos.Where(p => p.Categoria.CategoriaId == categoria.CategoriaId).ToList();

            //También podríamos filtrar la información de los productos por ejemplo que su nombre empiece con A,
            //para esto utilizamos StartWith

            var productos2 = context.Productos.Where(p => p.Categoria.CategoriaId == categoria.CategoriaId ).ToList();

            //Ver por que LINQ no reconoce &&  p.Nombre.StartsWith('A')

            return productos;

        }






        [HttpGet("/lazyloading")]
        //public IEnumerable<Categoria> GetLazyLoading()
             public IEnumerable<Producto> GetLazyLoading()
        {
            /*
                De esta manera puedes consultar los productos de la categoría con solo acceder a la propiedad Productos de tu objeto Categoria
              
            */

            var categoria = context.Categorias.Find (1);
            var productos = categoria.Productos;


        


            return productos;


        }











    }
}
