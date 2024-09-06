// See https://aka.ms/new-console-template for more information

bool validador = true;

List<Datos> lista = new List<Datos>();

int aumento = 0;

if (System.IO.File.Exists("ALGO.json")) {
    var archivo = System.IO.File.ReadAllText("ALGO.json");

    try
    {
        lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Datos>>(archivo);
    }
    catch (Exception)
    {
        Comandos.Salida_color("hubo problemas a leer el archivo json", "rojo");
    }




}

Console.WriteLine(@"
                 _     _                   _                  _             _ _             _            
  _ __ ___  __ _(_)___| |_ _ __ ___     __| | ___    ___  ___| |_ _   _  __| (_) __ _ _ __ | |_ ___  ___ 
 | '__/ _ \/ _` | / __| __| '__/ _ \   / _` |/ _ \  / _ \/ __| __| | | |/ _` | |/ _` | '_ \| __/ _ \/ __|
 | | |  __/ (_| | \__ \ |_| | | (_) | | (_| |  __/ |  __/\__ \ |_| |_| | (_| | | (_| | | | | ||  __/\__ \
 |_|  \___|\__, |_|___/\__|_|  \___/   \__,_|\___|  \___||___/\__|\__,_|\__,_|_|\__,_|_| |_|\__\___||___/
           |___/                                                                                                                       
");
Comandos.sonidos("saludos.wav");
Thread.Sleep(5000);

while (validador == true)
{
    Console.Clear();

    Comandos.color_R();
    Console.WriteLine(@"
                 _     _                   _                  _             _ _             _            
  _ __ ___  __ _(_)___| |_ _ __ ___     __| | ___    ___  ___| |_ _   _  __| (_) __ _ _ __ | |_ ___  ___ 
 | '__/ _ \/ _` | / __| __| '__/ _ \   / _` |/ _ \  / _ \/ __| __| | | |/ _` | |/ _` | '_ \| __/ _ \/ __|
 | | |  __/ (_| | \__ \ |_| | | (_) | | (_| |  __/ |  __/\__ \ |_| |_| | (_| | | (_| | | | | ||  __/\__ \
 |_|  \___|\__, |_|___/\__|_|  \___/   \__,_|\___|  \___||___/\__|\__,_|\__,_|_|\__,_|_| |_|\__\___||___/
           |___/                                                                                                                       
");
    Comandos.color_R();

    Console.Write(@"

    opciones

    1 - Agregar estudiante
    2 - Listado de estudiante
    3 - Modificar estudiante
    4 - Eliminar estudiante
    5 - Exportar todos los estudiantes
    6 - Acerca de
    7 - salir/guardar

");

    Console.Write(@"   
    ingrese la opcion deseada : ");
    string entrada = Console.ReadLine()??"";


    switch (entrada)
    {
        case "1":
            Console.Clear();
            Comandos.color_R();
            Console.WriteLine(@"





");
            
            if (aumento < 1)
            {
                Comandos.sonidos("nuevo.wav");
                Thread.Sleep(5000);
            }
            Comandos.color_R();
            Console.Write(@"   

       .--.                   .---.
   .---|__|           .-.     |~~~|
.--|===|--|_          |_|     |~~~|--.
|  |===|  |'\     .---!~|  .--|   |--|
|%%|   |  |.'\    |===| |--|%%|   |  |
|%%|   |  |\.'\   |   | |__|  |   |  |
|  |   |  | \  \  |===| |==|  |   |  |
|  |   |__|  \.'\ |   |_|__|  |~~~|__|
|  |===|--|   \.'\|===|~|--|%%|~~~|--|
^--^---'--^    `-'`---^-^--^--^---'--'


"); Comandos.color_R();
            var estudiantes = new Datos();
            Console.Write("    ingrese una nueva matricula : ");
            estudiantes.Matricula = Console.ReadLine() ?? "";
            Console.Write("    ingrese el nombre : ");
            estudiantes.Nombre = Console.ReadLine() ?? "";
            Console.Write("    ingrese el apellido : ");
            estudiantes.Apellido = Console.ReadLine() ?? "";
            // notas -----------------
            Console.Write("    ingrese la primera calificacion ");

            double num1 = 0.0;
            while(!double.TryParse(Console.ReadLine(), out num1) || num1 > 100.0 || num1 < 0.0)
            {
                Console.Write("  lo sentimos ingrese un numero valido : ");
                Comandos.color_R();
            }

            estudiantes.N1 = num1;

            // notas -----------------
            Console.Write("    ingrese la segunda calificacion : ");
            Comandos.color_R();

            double num2 = 0.0;
            while (!double.TryParse(Console.ReadLine(), out num2) || num2 > 100.0 || num2 < 0.0)
            {
                Console.Write("   ingrese un numero valido : ");
            }

            estudiantes.N2 = num2;


            lista.Add(estudiantes);


            break;


        case "2":
            if (aumento < 1)
            {
                Comandos.sonidos("mostrar.wav");
                Thread.Sleep(2000);
            }
            Console.Clear();
            Comandos.color_R();

            foreach (var palabra in lista)
            {
                Comandos.color_R();
                Console.WriteLine($@"
matricula : {palabra.Matricula}
nombre : {palabra.Nombre}
apellido  : {palabra.Apellido}
calificacion 1  : {palabra.N1}
calificacion 2  : {palabra.N2}
Promedio : {palabra.Promedio()}
EQ : {palabra.EQ()}
----------------------------------------------
");
            }
            Comandos.color_R();
            Console.ReadKey();
            break;





        case "3":
            Console.Clear();


            if (aumento < 1)
            {
                Comandos.sonidos("modificar.wav");
                Thread.Sleep(2000);
            }
            Comandos.color_R();

            lista = Comandos.Modificacion(lista);

            Comandos.color_R();
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();
            if (aumento < 1)
            {
                Comandos.sonidos("modificar.wav");
                Thread.Sleep(2000);
            }
            Comandos.color_R();
            lista = Comandos.Delete(lista);

            Console.ReadKey();
            break;
        case "5":
            Console.Clear();
            if (aumento < 1)
            {
                Comandos.sonidos("expotando.wav");
                Thread.Sleep(4000);
            }
            Comandos.color_R();
            Comandos.Salida(lista);
            Console.ReadKey();
            break;
        case "6":
            Console.Clear();
            var aumentoto = 0;
            if (aumentoto < 1)
            {
                Comandos.sonidos("yo.wav");
                Comandos.color_R();
            }
            Comandos.Acerca_de();
            Thread.Sleep(11000);
            Console.WriteLine("presiones cualquier tecla para salir");
           
            Console.ReadKey();
            break;
        case "7":
            Console.Clear();
            Comandos.sonidos("salir.wav");

            if (aumento < 1)
            {
                Thread.Sleep(5000);
                Comandos.color_R();
            }
            Console.Write("desea salir 's' salir 'n' no salir :" );
            var nombre = Console.ReadLine();


            if (nombre == "s" || nombre == "S" || nombre == "SI" || nombre == "si")
            { 
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
            System.IO.File.WriteAllText("ALGO.json", json);

            Console.WriteLine(" gualdado con exito" );
                Console.ReadKey();

            validador = false;
            }else if (nombre == "n" || nombre == "N" || nombre == "NO" || nombre == "no")
            {
                Console.WriteLine("se seguira editando");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("lo sentimos , usted no escribio lo solicitado");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            break;
        default:
            Console.Clear();
            Console.WriteLine("escriba una de las occiones porfaaaaaaa");
            Console.ReadKey();
            break;
    }




    aumento++;
}

