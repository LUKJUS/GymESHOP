namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Vairuotojas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Vairtuotojas
{
	[DisplayName("Vardas")]
	public string Vardas { get; set; }

	[DisplayName("Pavarde")]
	public string Pavarde { get; set; }

	[DisplayName("Amzius")]
	public int Amzius { get; set; }

	[DisplayName("Telefono_numeris")]
	public string Telefono_numeris { get; set; }

	[DisplayName("patirtis")]
	public string patirtis { get; set; }

	[DisplayName("id_Vairuotojas ")]
	public int id_Vairuotojas  { get; set; }
}

