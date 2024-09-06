using System;

public class Comandos
{

	public static List<Datos> Modificacion(List<Datos> lista)
	{

		var incremento = 0;
		foreach (var palabra in lista)
		{
			color_R();
			Console.WriteLine($@"
N : {incremento}
matricula : {palabra.Matricula}
nombre : {palabra.Nombre}
apellido  : {palabra.Apellido}
calificacion 1  : {palabra.N1}
calificacion 2  : {palabra.N2}
----------------------------------------------
");
			incremento = incremento + 1;
		}



		Console.Write("ingrese el numero que usted desea modificar: ");
		int occiones = 0;
		var tttt = Console.ReadLine();
		int.TryParse(tttt, out occiones);


		while (tttt == "")
		{
			Console.Write("ingrese un valor aceptado porfavor");
			tttt = Console.ReadLine();
		}
			if (occiones < lista.Count ) { 
		var estudiante = lista[occiones];


		var t = "";
		double tt = 0.0;
		Console.Write("ingrese la nueva matricula : ");
		t = Console.ReadLine();
        if (t.Length > 0) {
			estudiante.Matricula = t;
		}


		Console.Write("ingrese el nuevo nombre : ");
		t = Console.ReadLine();

		if (t.Length > 0)
		{
			estudiante.Nombre = t;
		}

		Console.Write("ingrese el nuevo apellido : ");
		t = Console.ReadLine();
		if (t.Length > 0)
		{
			estudiante.Apellido = t;
		}

		Console.Write("ingrese la nueva nota : ");
		double.TryParse(Console.ReadLine(), out tt);
		if (t.Length > 0)
		{
			estudiante.N1 = tt;
		}

		Console.Write("ingrese la nueva segunda nota : ");
		double.TryParse(Console.ReadLine(), out tt);
		if (t.Length > 0)
		{
			estudiante.N2 = tt;
		}



		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("lo sentimos el numero que usted introdujo no cumple con el campo");
		}












		return lista;
	}











	public static List<Datos> Delete(List<Datos> lista)
	{

		var incremento = 0;
		foreach (var palabra in lista)
		{
			color_R();
			Console.WriteLine($@"
N : {incremento}
matricula : {palabra.Matricula}
nombre : {palabra.Nombre}
apellido  : {palabra.Apellido}
calificacion 1  : {palabra.N1}
calificacion 2  : {palabra.N2}
Promedio : {palabra.Promedio()}
EQ : {palabra.EQ()}
----------------------------------------------
");
			incremento = incremento + 1;
		}



		Console.Write("ingrese el numero que usted desea modificar: ");
		int occiones = 0;
		var tttt = Console.ReadLine();
		while(tttt == "")
        {
			color_R();
			
			Console.Write("no puede ingresar un valor vacio: ");
			tttt = Console.ReadLine();
        }
		int.TryParse(tttt , out occiones);

		if (occiones < lista.Count && occiones > -1 )
		{

			lista.RemoveAt(occiones);
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
			System.IO.File.WriteAllText("ALGO.json", json);




        }
        else
        {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("lo sentimos el numero que usted introdujo no cumple con el campo");
        }










		return lista;

	}


	public static void  Salida(List<Datos> lista)
	{
		Console.Clear();

		var numeros = 0;
		string celda = "";
		string html = "";


        foreach (var datos in lista)
        {
		
			celda += $@"
            <tr>
                <th scope='row'>{numeros}</th>
                <td>{datos.Matricula}</td>
                <td>{datos.Nombre}</td>
                <td>{datos.Apellido}</td>
                <td>{datos.N1}</td>
                <td>{datos.N2}</td>
                <td>{datos.Promedio()}</td>
                <td>{datos.EQ()}</td>

            </tr>
";
			numeros++;

		}

		html = $@"
<!doctype html>
<html lang='en'>

<head>
    <!-- Required meta tags -->
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'>

    <!-- Bootstrap CSS -->
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css'
        integrity='sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm' crossorigin='anonymous'>

    <title>Hello, world!</title>

    <style>
        table{{
            margin: auto;
            margin-top: 30px  ;
            border: 1px solid #9e9e9e;
        }}
    </style>
</head>

<body>



    <table class='table w-75 p-3'>
        <thead class='thead-dark w-50 p-3'>
            <tr>
                <th scope='col'>Numero</th>
                <th scope='col'>Maricula</th>
                <th scope='col'>Nombre</th>
                <th scope='col'>Apellido</th>
                <th scope='col'>Nota1</th>
                <th scope='col'>Nota2</th>
                <th scope='col'>Promedio</th>
                <th scope='col'>clasificacion</th>
            </tr>
        </thead>
        <tbody>
           {celda}
        </tbody>
    </table>
    
   
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src='https://code.jquery.com/jquery-3.2.1.slim.min.js'
        integrity='sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN'
        crossorigin='anonymous'></script>
    <script src='https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js'
        integrity='sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q'
        crossorigin='anonymous'></script>
    <script src='https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js'
        integrity='sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl'
        crossorigin='anonymous'></script>
</body>

</html> 


";


		System.IO.File.WriteAllText("index.html", html);


	

		var psi = new System.Diagnostics.ProcessStartInfo();
		psi.UseShellExecute = true;
		psi.FileName = "index.html";
		System.Diagnostics.Process.Start(psi);






	}




	public static void Acerca_de()
	{
		Console.WriteLine(@"
	  /$$$$$$   /$$     /$$                              
	 /$$__  $$ | $$    |__/                              
	| $$  \__//$$$$$$   /$$ /$$    /$$ /$$$$$$  /$$$$$$$ 
	|  $$$$$$|_  $$_/  | $$|  $$  /$$//$$__  $$| $$__  $$
	 \____  $$ | $$    | $$ \  $$/$$/| $$$$$$$$| $$  \ $$
	 /$$  \ $$ | $$ /$$| $$  \  $$$/ | $$_____/| $$  | $$
	|  $$$$$$/ |  $$$$/| $$   \  $/  |  $$$$$$$| $$  | $$
	 \______/   \___/  |__/    \_/    \_______/|__/  |__/
                                                     
	 ___   ___  ___   ___        ___    __   ___  ___ 
	(__ \ / _ \(__ \ (__ \ ___  / _ \  /. | | __)(__ )
	 / _/( (_) )/ _/  / _/(___)( (_) )(_  _)|__ \ / / 
	(____)\___/(____)(____)     \___/   (_) (___/(_/                                                       
                                             
");
		Console.WriteLine(@"

matricula : 2022-0457
nombre : Stiven 
apellido : de la rosa brito 







");







	}

	public static void sonidos(string audio)
    {
		var file = $"sonidos/{audio}";
		System.Diagnostics.Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{file}').PlaySync();");
	}

	public static void color_R()
	{

		Random r = new Random();

		int coco = r.Next(1, 9);

		if (coco == 1)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
		}
		else if (coco == 2)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}
		else if (coco == 3)
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}
		else if (coco == 4)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
		}
		else if (coco == 5)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
		}
		else if (coco == 6)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}
		else if (coco == 7)
		{
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		else if (coco == 8)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
		}

		else if (coco == 9)
		{
			Console.ForegroundColor = ConsoleColor.DarkBlue;
		}



	}


	public static void Salida_color(string entrada , string color)
	{
        //ConsoleColor.Blue;

        if(color == "rojo"){
			Console.ForegroundColor = ConsoleColor.Red;
		}

		
		Console.WriteLine(entrada);
		Console.ResetColor();

	}

}
