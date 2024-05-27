namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MVC.Models;
using MySql.Data.MySqlClient;



/// <summary>
/// Database operations related to 'Sponsor' entity.
/// </summary>
public class PapildaiRepo
{
	public static List<Product> List()
	{
		var query = $@"SELECT * FROM `products`";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Product>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Name = dre.From<string>("Name");
				t.Type = dre.From<string>("Type");
				t.Price = dre.From<double>("Price");
				t.Img = dre.From<string>("Img");
				t.Description = dre.From<string>("Description");

			});

		return result;
	}

	
}