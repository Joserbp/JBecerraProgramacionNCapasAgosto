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

            ML.Semestre semestre = new ML.Semestre();
            alumno.Semestre = new ML.Semestre();
            Console.WriteLine("Ingese el IdSemestre");
            alumno.Semestre.IdSemestre = int.Parse(Console.ReadLine());




            //ML.Result result = BL.Alumno.Add(alumno);
            ML.Result result = BL.Alumno.AddSP(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno agregado exitosamente");
            }
            else
            {
                Console.WriteLine("Alumno no se agrego exitosamente" + result.ErrorMessage);
            }

        }
        public static void GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            if (result.Correct)
            {
                foreach (ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("El Nombre del Alumno es: " + alumno.Nombre);
                    Console.WriteLine("El Apellido paterno del Alumno es: " + alumno.ApellidoPaterno);
                    Console.WriteLine("El Apellido materno del Alumno es: " + alumno.ApellidoMaterno);
                    Console.WriteLine("Fecha de Nacimiento: " + alumno.FechaNacimiento);
                    Console.WriteLine("-----------------------");
                }

            }
            else
            {
                Console.WriteLine("No se ha podido consultar la informaíón" + result.ErrorMessage);
            }
            Console.ReadKey();
        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id de Alumno a consultar");
            int IdAlumno = int.Parse(Console.ReadLine());
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            if (result.Correct)
            {
                ML.Alumno alumno = (ML.Alumno)result.Object; //UNBOXING

                Console.WriteLine("-----------------------");
                Console.WriteLine("El Nombre del Alumno es: " + alumno.Nombre);
                Console.WriteLine("El Apellido paterno del Alumno es: " + alumno.ApellidoPaterno);
                Console.WriteLine("El Apellido materno del Alumno es: " + alumno.ApellidoMaterno);
                Console.WriteLine("Fecha de Nacimiento: " + alumno.FechaNacimiento);
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine("No se ha podido consultar la informaíón" + result.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}
