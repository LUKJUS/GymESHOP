namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Atsiliepimas;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Klientas;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Krovinys;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Vairuotojas;


/// <summary>
/// Database operations related to 'Uzsakymas' entity.
/// </summary>
public class UzsakymasF2Repo
{
    public static List<UzsakymasL> ListUzsakymas()
    {
        var query =
            $@"SELECT
				s.Data,
				b.NAME AS busena,
                u.NAME AS sutartis,
                s.id_Uzsakymas AS id_Uzsakymas,
				n.Vardas AS klientas,
                v.Vardas AS vairuotojas,
                a.Komentaras As atsiliepimas
			FROM
				uzsakymas s
				LEFT JOIN `klientas` n ON n.id_Klientas = s.fk_Klientasid_Klientas
				LEFT JOIN `busena` b ON b.id_Busena = s.Uzsakymo_statusas
                LEFT JOIN `vairuotojas` v ON v.id_Vairuotojas = s.fk_Vairuotojasid_Vairuotojas
                LEFT JOIN `atsiliepimas` a ON a.id_Atsiliepimas = s.fk_Atsiliepimasid_Atsiliepimas
                LEFT JOIN `sutarties_busena` u ON u.id_Sutarties_busena = s.Sutartis
			ORDER BY s.id_Uzsakymas DESC";

        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<UzsakymasL>(drc, (dre, t) =>
            {
                t.Data = dre.From<DateTime>("Data");
                t.Busena = dre.From<string>("busena");
                t.Sutartis = dre.From<string>("sutartis");
                t.UzsakymoID = dre.From<int>("id_Uzsakymas");
                t.Atsiliepimas = dre.From<string>("atsiliepimas");
                t.Klientas = dre.From<string>("klientas");
                t.Vairtuotojas = dre.From<string>("vairuotojas");
            });

        return result;
    }

    public static UzsakymasCE FindUzsakymasCE(int nr)
    {
        var query = $@"SELECT * FROM `uzsakymas` WHERE id_Uzsakymas=?id_Uzsakymas";
        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?id_Uzsakymas", nr);
            });

        var result =
            Sql.MapOne<UzsakymasCE>(drc, (dre, t) =>
            {
                //make a shortcut
                var uzsakymas = t.Uzsakymas;

                uzsakymas.Data = dre.From<DateTime>("Data");
                uzsakymas.FkBusena = dre.From<int>("Uzsakymo_statusas");
                uzsakymas.Sutartis = dre.From<string>("Sutartis");
                uzsakymas.UzsakymoID = dre.From<int>("id_Uzsakymas");
                uzsakymas.FkAtsiliepimas = dre.From<int>("fk_Atsiliepimasid_Atsiliepimas");
                uzsakymas.FkKlientas = dre.From<int>("fk_Klientasid_Klientas");
                uzsakymas.FkVairtuotojas = dre.From<int>("fk_Vairuotojasid_Vairuotojas");
            });

        return result;
    }

    public static int InsertUzsakymas(UzsakymasCE uzsCE)
    {
        var query =
            $@"INSERT INTO `uzsakymas`
			(
				`Data`,
				`Uzsakymo_statusas`,
				`Sutartis`,
				`fk_Atsiliepimasid_Atsiliepimas`,
				`fk_Klientasid_Klientas`,
				`fk_Vairuotojasid_Vairuotojas`
			)
			VALUES(
				?Data,
				?Uzsakymo_statusas,
				?Sutartis,
				?fk_Atsiliepimasid_Atsiliepimas,
				?fk_Klientasid_Klientas,
				?fk_Vairuotojasid_Vairuotojas
			)";

        var nr =
            Sql.Insert(query, args =>
            {
                //make a shortcut
                var uzsakymas = uzsCE.Uzsakymas;

                args.Add("?Data", uzsakymas.Data);
                args.Add("?Uzsakymo_statusas", uzsakymas.FkBusena);
                args.Add("?Sutartis", uzsakymas.Sutartis);
                args.Add("?fk_Atsiliepimasid_Atsiliepimas", uzsakymas.FkAtsiliepimas);
                args.Add("?fk_Klientasid_Klientas", uzsakymas.FkKlientas);
                args.Add("?fk_Vairuotojasid_Vairuotojas", uzsakymas.FkVairtuotojas);
            });

        return (int)nr;
    }

    public static void UpdateUzsakymas(UzsakymasCE uzsCE)
    {
        var query =
            $@"UPDATE `uzsakymas`
			SET
				`Data` = ?Data,
				`Uzsakymo_statusas` = ?Uzsakymo_statusas,
				`Sutartis` = ?Sutartis,
				`fk_Atsiliepimasid_Atsiliepimas` = ?atsiliepimas,
				`fk_Klientasid_Klientas` = ?klientas,
				`fk_Vairuotojasid_Vairuotojas` = ?vairuotojas
			WHERE id_Uzsakymas=?id_Uzsakymas";

        Sql.Update(query, args =>
        {
            //make a shortcut
            var uzsakymas = uzsCE.Uzsakymas;

            args.Add("?Data", uzsakymas.Data);
            args.Add("?Uzsakymo_statusas", uzsakymas.FkBusena);
            args.Add("?Sutartis", uzsakymas.Sutartis);
            args.Add("?atsiliepimas", uzsakymas.FkAtsiliepimas);
            args.Add("?klientas", uzsakymas.FkKlientas);
            args.Add("?vairuotojas", uzsakymas.FkVairtuotojas);

            args.Add("?id_Uzsakymas", uzsakymas.UzsakymoID);
        });
    }

    public static void DeleteUzsakymas(int nr)
    {
        var query = $@"DELETE FROM `uzsakymas` where id_Uzsakymas=?id_Uzsakymas";
        Sql.Delete(query, args =>
        {
            args.Add("?id_Uzsakymas", nr);
        });
    }

    public static List<Busena> ListBusena()
    {
        var query = $@"SELECT * FROM `busena` ORDER BY id_Busena ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Busena>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Busena");
                t.Pavadinimas = dre.From<string>("name");
            });

        return result;
    }
    public static List<SutartiesBusena> ListSutartiesBusena()
    {
        var query = $@"SELECT * FROM `sutarties_busena` ORDER BY id_Sutarties_busena ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<SutartiesBusena>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Sutarties_busena");
                t.Pavadinimas = dre.From<string>("name");
            });

        return result;
    }
        public static List<Krovinys> ListKrovinys()
    {
        var query = $@"SELECT * FROM `krovinys` ORDER BY id_Krovinys ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Krovinys>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Krovinys");
                t.Miestas = dre.From<string>("Miestas");
            });

        return result;
    }
    public static List<Vairtuotojas> ListVairuotojas()
    {
        var query = $@"SELECT * FROM `vairuotojas` ORDER BY id_Vairuotojas ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Vairtuotojas>(drc, (dre, t) =>
            {
                t.id_Vairuotojas = dre.From<int>("id_Vairuotojas");
                t.Vardas = dre.From<string>("Vardas");
            });

        return result;
    }
        public static List<Atsiliepimas> ListAtsiliepimas()
    {
        var query = $@"SELECT * FROM `atsiliepimas` ORDER BY id_Atsiliepimas ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Atsiliepimas>(drc, (dre, t) =>
            {
                t.id_Atsiliepimas = dre.From<int>("id_Atsiliepimas");
                t.Komentaras = dre.From<string>("Komentaras");
            });

        return result;
    }
        public static List<Klientas> ListKlientas()
    {
        var query = $@"SELECT * FROM `klientas` ORDER BY id_Klientas ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Klientas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Klientas");
                t.Vardas = dre.From<string>("Vardas");
            });

        return result;
    }

    public static List<UzsakymasCE.UzsakytasKrovinysM> ListUzsakytasKrovinys(int sutartisId)
    {
        var query =
            $@"SELECT *
			FROM 
				`tarpine_eilute`
			WHERE 
				fk_Uzsakymasid_Uzsakymas = ?sutartisId
			ORDER BY 
				id_Tarpine_eilute ASC";

        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?sutartisId", sutartisId); // Correct parameter name
            });

        var result =
            Sql.MapAll<UzsakymasCE.UzsakytasKrovinysM>(drc, (dre, t) =>
            {
                t.Krovinys =
                    // Serialize composite key for convenience
                    JsonConvert.SerializeObject(new
                    {
                        Krovinys = dre.From<int>("fk_Krovinysid_Krovinys")
                    });
                t.Kiekis = dre.From<int>("kiekis");
            });

        for (int i = 0; i < result.Count; i++)
            result[i].InListId = i;

        return result;
    }

    public static void InsertUzsakytasKrovinys(int sutartisId, UzsakymasCE.UzsakytasKrovinysM krov)
    {
        //deserialize 'Paslauga' foreign keys from 'UzsakytaPaslauga' view model key
        var fks =
            JsonConvert.DeserializeAnonymousType(
                krov.Krovinys,
                new
                {
                    Krovinys = 1,
                    Kiekis = 0
                });

        var query =
            $@"INSERT INTO `tarpine_eilute`
				(
					fk_Uzsakymasid_Uzsakymas,
					fk_Krovinysid_Krovinys,
					kiekis
				)
				VALUES(
					?fk_Uzsakymasid_Uzsakymas,
					?fk_Krovinysid_Krovinys,
					?kiekis
				)";

        Sql.Insert(query, args =>
        {
            args.Add("?fk_Uzsakymasid_Uzsakymas", sutartisId);
            args.Add("?fk_Krovinysid_Krovinys", fks.Krovinys);
            args.Add("?kiekis", krov.Kiekis);
        });
    }

    public static void DeleteUzsakytasKrovinysForSutartis(int uzsakymas)
    {
        var query =
            $@"DELETE FROM a
			USING `tarpine_eilute` as a
			WHERE a.fk_Uzsakymasid_Uzsakymas=?fkid";

        Sql.Delete(query, args =>
        {
            args.Add("?fkid", uzsakymas);
        });
    }
}