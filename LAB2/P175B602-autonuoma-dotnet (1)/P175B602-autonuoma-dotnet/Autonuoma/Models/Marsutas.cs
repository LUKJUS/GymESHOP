namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Salonas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'MarsrutasM' entity used in lists.
/// </summary>
public class Marsrutas
{
	[DisplayName("id_Marsrutas")]
	public int Id { get; set; }

	[DisplayName("Pradine_vieta")]
	public string Pradine_vieta { get; set; }

	[DisplayName("Paskirties_vieta")]
	public string PaskirtiesVieta { get; set; }

	[DisplayName("Atstumas")]
	public decimal Atstumas { get; set; }

	[DisplayName("Trukmė")]
	public decimal Trukme { get; set; }


}
/// <summary>
/// 'Klientas' in create and edit forms.
/// </summary>
public class MarsrutasL
{

	[DisplayName("id_Marsrutas")]
	public int Id { get; set; }

	[DisplayName("Pradine_vieta")]
	public string PradineVieta { get; set; }

	[DisplayName("Paskirties_vieta")]
	public string PaskirtiesVieta { get; set; }

	[DisplayName("Atstumas")]
	public decimal Atstumas { get; set; }

	[DisplayName("Trukme")]
	public decimal Trukme { get; set; }


}
/// <summary>
/// 'Marsrutas' in create and edit forms.
/// </summary>
public class MarsrutasCE
{
	public class MarsrutasM
	{

		[DisplayName("id_Marsrutas")]
		[Required]
		public int Id { get; set; }

		[DisplayName("Pradine_vieta")]
		[Required]
		public string PradineVieta { get; set; }

		[DisplayName("Paskirties_vieta")]
		[Required]
		public string PaskirtiesVieta { get; set; }

		[DisplayName("Atstumas")]
		[Required]
		public decimal Atstumas { get; set; }

		[DisplayName("Trukme")]
		[Required]
		public decimal Trukme { get; set; }
	}


	/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	/// <summary>
	/// </summary>
	public MarsrutasM Marsrutas { get; set; } = new MarsrutasM();

}
