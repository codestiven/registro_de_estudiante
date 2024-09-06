using System;

public class Datos
{
	public string Matricula { get; set; } = "";
	public string Nombre { get; set; } = "";
	public string Apellido { get; set; } = "";
	public double N1 { get; set; }

	public double N2 { get; set; }

	public double Promedio() {

		

		return (this.N1 + this.N2) / 2; 
	
	}
	public String EQ()
	{
		var Promedio = this.Promedio();

		
		var calificacion = "F";

		if (Promedio >= 90) 
		{
			calificacion = "A";
		}
		else if (Promedio <= 90 && Promedio >= 80) {
			calificacion = "B";
		}
		else if (Promedio <= 80 && Promedio >= 75) {
			calificacion = "C";
		}
		else if (Promedio < 75) {
			calificacion = "F";
		}

		return calificacion;

	}

}
