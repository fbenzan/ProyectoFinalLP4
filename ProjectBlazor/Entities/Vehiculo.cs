using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ProjectBlazor.Entities;

[Table("Vehiculos")]
public class Vehiculo
{
	[Key]
	public int VehiculoId { get; set; }
	public string Marca { get; set; } = "";
	public string? Modelo { get; set; }
	public string? Matricula { get; set; }
	public string? NumeroPlaca { get; set; }
	public string? Tipo { get; set; }
	public string? Estatus { get; set; }
	[Column(TypeName = "decimal(18,6)")]
	public decimal Precio { get; set; } = 0;


	public static Vehiculo Create(string marca, string? modelo, string? matricula, string? numeroPlaca, string? tipo, string? estatus, decimal precio = 0)
		=> new()
		{
			Marca = marca,
			Modelo = modelo,
			Matricula = matricula,
			NumeroPlaca = numeroPlaca,
			Tipo = tipo,
			Estatus = estatus,
			Precio = precio
		};
	public bool Update(string marca, string? modelo, string? matricula, string? numeroPlaca, string? tipo, string? estatus, decimal precio = 0)
	{
		var save = false;
		if (Marca != marca)
		{
			Marca = marca;
			save = true;
		}
		if (Modelo != modelo)
		{
			Modelo = modelo;
			save = true;
		}
		if (Matricula != matricula)
		{
			Matricula = matricula;
			save = true;
		}
		if (NumeroPlaca != numeroPlaca)
		{
			NumeroPlaca = numeroPlaca;
			save = true;
		}
		if (Tipo != tipo)
		{
			Tipo = tipo;
			save = true;
		}
		if (Estatus != estatus)
		{
			Estatus = Estatus;
			save = true;
		}
		if (Precio != precio)
		{
			Precio = precio;
			save = true;
		}
		return save;

	}

}	
	
