namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// View model of 'TarpineEilute' entity.
/// </summary>
public class TarpineEilute
{
	/// <summary>
	/// ID of the record in the form. Is used when adding and removing records.
	/// </summary>
	public int InListId { get; set; }
	/// <summary>
	/// Indicates if record should not be editable.
	/// </summary>
	public bool IsReadonly { get; set; }
	public int Krovinys { get; set; }

	[DisplayName("Kiekis")]
	[Required]
	public int Kiekis { get; set; }
}
