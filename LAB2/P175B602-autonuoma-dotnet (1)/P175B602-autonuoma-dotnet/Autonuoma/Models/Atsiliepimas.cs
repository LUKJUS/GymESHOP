namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Atsiliepimas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Atsiliepimas
{
	[DisplayName("Komentaras")]
	public string Komentaras { get; set; }

	[DisplayName("Data")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public string Data { get; set; }

	[DisplayName("Vertinimas ")]
	public int Vertinimas { get; set; }

	[DisplayName("id_Atsiliepimas ")]
	public int id_Atsiliepimas { get; set; }

	[DisplayName("fk_Klientasid_Klientas ")]
	public int fkKlientasId { get; set; }

}

