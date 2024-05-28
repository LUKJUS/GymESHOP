namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.SutBusena;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class SutBusena
{
	[DisplayName("id Sutarties Busena")]
	public int id { get; set; }

	[DisplayName("name")]
	public string name { get; set; }
}

