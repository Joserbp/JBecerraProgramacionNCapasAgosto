using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno(); //Instancia de alumno acceder a las propiedades

            Console.WriteLine("Ingese el Nombre");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Ingese el Apellido Paterno");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingese el Apellido Materno");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingese el FechaNacimiento");
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingese el sexo");
            alumno.Sexo = Console.ReadLine();

            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno agregado exitosamente");
            }
            else {
                Console.WriteLine("Alumno no se agrego exitosamente" + result.ErrorMessage);
            }
        
        }
    }
}
