namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;



/// <summary>
/// Database operations related to 'PaslaugosKaina' entity.
/// </summary>
public class TarpineEiluteRepo
{
	public static List<TarpineEilute> LoadForPaslauga(int id)
	{
		var query =
			$@"SELECT
				b.id_Krovinys as krovinys
			FROM
				`tarpine_eilute` as pk
				LEFT JOIN `krovinys` as b ON b.id_Krovinys = pk.fk_Krovinysid_Krovinys 
			WHERE fk_Krovinysid_Krovinys = ?id
			GROUP BY
				pk.fk_Krovinysid_Krovinys 
			ORDER BY pk.fk_Krovinysid_Krovinys DESC";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result = 
			Sql.MapAll<TarpineEilute>(drc, (dre, t) => {
				t.Krovinys = dre.From<int>("krovinys");
			});

		for( int i = 0; i < result.Count; i++ )
			result[i].InListId = i;

		return result;
	}
}