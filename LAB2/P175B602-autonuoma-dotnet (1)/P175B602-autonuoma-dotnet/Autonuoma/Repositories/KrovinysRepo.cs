namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.Krovinys;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Salonas;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.TransportoPriemones;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SutBusena;

public class KrovinysRepo
{
    public static List<KrovinysL> ListKrovinys()
    {
        var query =
            $@"SELECT
                    a.Miestas,
                    a.Svoris,
                    a.id_Krovinys,
                    b.name AS busena,
                    m.Pradine_vieta AS marsrutas,
                    t.Gamintojas AS transportas
                FROM
                    krovinys a
                    LEFT JOIN `busena` b ON b.id_Busena = a.Pristatymo_busena
                    LEFT JOIN `marsrutas` m ON m.id_Marsrutas = a.fk_Marsrutasid_Marsrutas
                    LEFT JOIN `transporto_priemone` t ON t.id_Transporto_priemone = a.fk_Transporto_priemoneid_Transporto_priemone
                ORDER BY a.id_Krovinys ASC";

        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<KrovinysL>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Krovinys");
                t.Miestas = dre.From<string>("Miestas");
                t.Svoris = dre.From<decimal>("Svoris");
                t.PristatymoBusena = dre.From<string>("busena");
                t.fkMarsrutas = dre.From<string>("marsrutas");
                t.fkTransportoPriemone = dre.From<string>("transportas");
            });

        return result;
    }

    public static KrovinysCE FindKrovinysCE(int id)
    {
        var query = $@"SELECT * FROM `krovinys` WHERE id_Krovinys=?id_Krovinys";

        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?id_Krovinys", id);
            });

        var result =
            Sql.MapOne<KrovinysCE>(drc, (dre, t) =>
            {
                var krovinys = t.Krovinys;

                krovinys.Id = dre.From<int>("id_Krovinys");
                krovinys.Miestas = dre.From<string>("Miestas");
                krovinys.Svoris = dre.From<decimal>("Svoris");
                krovinys.PristatymoBusena = dre.From<int>("Pristatymo_busena");
                krovinys.fkMarsrutas = dre.From<int>("fk_Marsrutasid_Marsrutas");
                krovinys.fkTransportoPriemone = dre.From<int>("fk_Transporto_priemoneid_Transporto_priemone");
            });

        return result;
    }

    public static void InsertKrovinys(KrovinysCE krovinysCE)
    {
    var query =
        $@"INSERT INTO `krovinys`
            (
                `Miestas`,
                `Svoris`,
                `Pristatymo_busena`,
                `fk_Marsrutasid_Marsrutas`,
                `fk_Transporto_priemoneid_Transporto_priemone`
            )
            VALUES (
                ?Miestas,
                ?Svoris,
                ?Pristatymo_busena,
                ?fk_Marsrutasid_Marsrutas,
                ?fk_Transporto_priemoneid_Transporto_priemone
            )";

    Sql.Insert(query, args =>
    {
        var krovinys = krovinysCE.Krovinys;

        args.Add("?Miestas", krovinys.Miestas);
        args.Add("?Svoris", krovinys.Svoris);
        args.Add("?Pristatymo_busena", krovinys.PristatymoBusena);
        args.Add("?fk_Marsrutasid_Marsrutas", krovinys.fkMarsrutas);
        args.Add("?fk_Transporto_priemoneid_Transporto_priemone", krovinys.fkTransportoPriemone);
    });
    }

    public static void UpdateKrovinys(KrovinysCE krovinysCE)
    {
        var query =
            $@"UPDATE `krovinys`
                SET
                    `Miestas` = ?Miestas,
                    `Svoris` = ?Svoris,
                    `Pristatymo_busena` = ?Pristatymo_busena,
                    `fk_Marsrutasid_Marsrutas` = ?fk_Marsrutasid_Marsrutas,
                    `fk_Transporto_priemoneid_Transporto_priemone` = ?fk_Transporto_priemoneid_Transporto_priemone
                WHERE
                    `id_Krovinys` = ?id_Krovinys";

        Sql.Update(query, args =>
        {
            var krovinys = krovinysCE.Krovinys;

            args.Add("?Miestas", krovinys.Miestas);
            args.Add("?Svoris", krovinys.Svoris);
            args.Add("?Pristatymo_busena", krovinys.PristatymoBusena);
            args.Add("?fk_Marsrutasid_Marsrutas", krovinys.fkMarsrutas);
            args.Add("?fk_Transporto_priemoneid_Transporto_priemone", krovinys.fkTransportoPriemone);
            args.Add("?id_Krovinys", krovinys.Id);
        });
    }

    public static void DeleteKrovinys(int id)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}krovinys` WHERE id_Krovinys=?id_Krovinys";
        Sql.Delete(query, args =>
        {
            args.Add("?id_Krovinys", id);
        });
    }
    public static List<PristatymoBusena> ListBusenos()
    {
        var query = $@"SELECT * FROM `busena` ORDER BY id_Busena ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<PristatymoBusena>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Busena");
                t.Busena = dre.From<string>("name");
            });

        return result;
    }
        public static List<SutBusena> ListSutartis()
    {
        var query = $@"SELECT * FROM `sutarties_busena` ORDER BY id_Sutarties_busena ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<SutBusena>(drc, (dre, t) =>
            {
                t.id = dre.From<int>("id_Sutarties_busena");
                t.name = dre.From<string>("name");
            });

        return result;
    }
    public static List<Marsrutas> ListMarsrutas()
    {
        var query = $@"SELECT * FROM `marsrutas` ORDER BY id_Marsrutas ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Marsrutas>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id_Marsrutas");
                t.Pradine_vieta = dre.From<string>("Pradine_vieta");
            });

        return result;
    }
    public static List<Transportas> ListTransport()
    {
        var query = $@"SELECT * FROM `transporto_priemone` ORDER BY id_Transporto_priemone ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Transportas>(drc, (dre, t) =>
            {
                t.id_Transporto_priemone = dre.From<int>("id_Transporto_priemone");
                t.Gamintojas = dre.From<string>("Gamintojas");
            });

        return result;
    }
}


