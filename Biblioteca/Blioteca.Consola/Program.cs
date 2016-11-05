using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;

namespace Blioteca.Consola 
{
    class Program 
    {
        static void Main(string[] args)
        {
            using (var context = new BibliotecaContext("BibliotecaLocal"))
            {
                var nuevoLibro = new Libro();
                nuevoLibro.Nombre = "Libro Matematicas";
                nuevoLibro.AnioPublicacion = 2002;
                context.Libros.Add(nuevoLibro);
                context.SaveChanges();


                Console.WriteLine("Hola mundo");
                Console.ReadKey();
            }
            
            
        }
    }
}
