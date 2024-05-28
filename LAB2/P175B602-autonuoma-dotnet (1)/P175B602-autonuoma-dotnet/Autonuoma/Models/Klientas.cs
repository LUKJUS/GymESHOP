namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Klientas;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Klientas
{
	[DisplayName("Vardas")]
	public string Vardas { get; set; }

	[DisplayName("Pavarde")]
	public string Pavarde { get; set; }

	[DisplayName("Adresas")]
	public string Adresas { get; set; }

	[DisplayName("Telefono_numeris")]
	public string Telefonas { get; set; }
	[DisplayName("Id")]
	public int Id { get; set; }
}

/// <summary>
/// Model of 'Klientas' entity used in lists.
/// </summary>
public class KlientasL
{
	[DisplayName("Vardas")]
	public string Vardas { get; set; }

	[DisplayName("Pavarde")]
	public string Pavarde { get; set; }

	[DisplayName("Adresas")]
	public string Adresas { get; set; }

	[DisplayName("Telefonas")]
	public string Telefonas { get; set; }
	[DisplayName("id_Klientas")]
	public int Id { get; set; }
}

/// <summary>
/// 'Klientas' in create and edit forms.
/// </summary>
public class KlientasCE
{
	/// <summary>
	/// Klientas.
	/// </summary>
	public class KlientasM
	{

		[DisplayName("Vardas")]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavarde")]
		[Required]
		public string Pavarde { get; set; }

		[DisplayName("Adresas")]
		[Required]
		public string Adresas { get; set; }

		[DisplayName("Telefonas")]
		[Required]
		public string Telefonas { get; set; }

		[DisplayName("id_Klientas")]
		[Required]
		public int Id { get; set; }
	}

	/// <summary>
	/// Klientas.
	/// </summary>
	public KlientasM Klientas { get; set; } = new KlientasM();
}

