namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Klientas;
public class KlientasRepo
{
	public static List<KlientasL> List()
	{
		var query =
			$@"SELECT 
                    a.Vardas,
                    a.Pavarde,
                    a.Adresas,
                    a.Telefono_numeris AS Telefonas,
                    a.id_Klientas AS id
                FROM 
                    klientas a";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<KlientasL>(drc, (dre, t) =>
			{
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("Pavarde");
				t.Adresas = dre.From<string>("adresas");
				t.Telefonas = dre.From<string>("Telefonas");
				t.Id = dre.From<int>("id");
			});

		return result;
	}

	public static KlientasCE Find(int id)
	{
		var query = $@"SELECT * FROM `klientas` WHERE id_Klientas=?id_Klientas";

		var drc =
			Sql.Query(query, args =>
			{
				args.Add("?id_Klientas", id);
			});

		if (drc.Count > 0)
		{
			var result =
				Sql.MapOne<KlientasCE>(drc, (dre, t) =>
				{

					var client = t.Klientas;

					client.Vardas = dre.From<string>("vardas");
					client.Pavarde = dre.From<string>("Pavarde");
					client.Adresas = dre.From<string>("adresas");
					client.Telefonas = dre.From<string>("Telefono_numeris");
					client.Id = dre.From<int>("id_Klientas");
				});

			return result;
		}

		return null;
	}

	public static void Insert(KlientasCE klientas)
	{
		var query =
			$@"INSERT INTO `klientas`
            (
                `vardas`,
                `Pavarde`,
                `adresas`,
                `Telefono_numeris`
            )
            VALUES(
                ?vardas,
                ?pavarde,
                ?adresas,
                ?tel
            )";

		Sql.Insert(query, args =>
		{

			var client = klientas.Klientas;

			args.Add("?vardas", client.Vardas);
			args.Add("?pavarde", client.Pavarde);
			args.Add("?adresas", client.Adresas);
			args.Add("?tel", client.Telefonas);
		});
	}

	public static void Update(KlientasCE klientas)
	{
		var query =
			$@"UPDATE `klientas`
            SET
                `vardas` = ?vardas,
                `pavarde` = ?pavarde,
                `adresas` = ?adresas,
                `Telefono_numeris` = ?tel
            WHERE
                id_Klientas=?id";

		Sql.Update(query, args =>
		{

			var client = klientas.Klientas;

			args.Add("?vardas", client.Vardas);
			args.Add("?pavarde", client.Pavarde);
			args.Add("?adresas", client.Adresas);
			args.Add("?tel", client.Telefonas);
			args.Add("?id", client.Id);
		});
	}

	public static void Delete(int id)
	{
		var query = $@"DELETE FROM `klientas` WHERE id_Klientas=?id_Klientas";
		Sql.Delete(query, args =>
		{
			args.Add("?id_Klientas", id);
		});
	}
}
