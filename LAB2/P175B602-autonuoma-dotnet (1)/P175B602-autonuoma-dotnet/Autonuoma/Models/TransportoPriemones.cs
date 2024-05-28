namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.TransportoPriemones;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Transportas
{
	[DisplayName("Gamintojas")]
	public string Gamintojas { get; set; }

	[DisplayName("Modelis")]
	public string Modelis { get; set; }

	[DisplayName("Metai")]
	public int Metai { get; set; }

	[DisplayName("Busenos_komentaras")]
	public string Busenos_komentaras { get; set; }

	[DisplayName("Technine_bukle")]
	public string Technine_bukle { get; set; }

	[DisplayName("Radijas")]
	public bool Radijas { get; set; }

	[DisplayName("Vietu_skaicius")]
	public int Vietu_skaicius { get; set; }

	[DisplayName("Registravimo_data")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime Registravimo_data { get; set; }

	[DisplayName("id_Transporto_priemone ")]
	public int id_Transporto_priemone { get; set; }

	[DisplayName("fk_Garazasid_Garazas ")]
	public int fk_Garazasid_Garazas { get; set; }
}

