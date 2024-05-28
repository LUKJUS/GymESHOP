using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Salonas;
using System.Collections.Generic;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Marsrutas' entity.
    /// </summary>
    public class MarsrutasRepo
    {
        public static List<MarsrutasL> List()
        {
            var query = @"
                SELECT 
                    id_Marsrutas,
                    Pradine_vieta,
                    Paskirties_vieta,
                    Atstumas,
                    Trukme
                FROM 
                    Marsrutas";

            var drc = Sql.Query(query);

            var result =
                Sql.MapAll<MarsrutasL>(drc, (dre, t) =>
                {
                    t.Id = dre.From<int>("id_Marsrutas");
                    t.PradineVieta = dre.From<string>("Pradine_vieta");
                    t.PaskirtiesVieta = dre.From<string>("Paskirties_vieta");
                    t.Atstumas = dre.From<decimal>("Atstumas");
                    t.Trukme = dre.From<decimal>("Trukme");
                });

            return result;
        }

        public static MarsrutasCE Find(int id)
        {
            var query = @"
                SELECT 
                    id_Marsrutas,
                    Pradine_vieta,
                    Paskirties_vieta,
                    Atstumas,
                    Trukme
                FROM 
                    Marsrutas
                WHERE
                    id_Marsrutas=?id_Marsrutas";

            var drc =
                Sql.Query(query, args =>
                {
                    args.Add("?id_Marsrutas", id);
                });

            if (drc.Count > 0)
            {
                var result =
                    Sql.MapOne<MarsrutasCE>(drc, (dre, t) =>
                    {

                        var marsrutas = t.Marsrutas;

                        marsrutas.Id = dre.From<int>("id_Marsrutas");
                        marsrutas.PradineVieta = dre.From<string>("Pradine_vieta");
                        marsrutas.PaskirtiesVieta = dre.From<string>("Paskirties_vieta");
                        marsrutas.Atstumas = dre.From<decimal>("Atstumas");
                        marsrutas.Trukme = dre.From<decimal>("Trukme");
                    });

                return result;
            }

            return null;
        }

        public static void Insert(MarsrutasCE marsrutas)
        {
            var query = @"
                INSERT INTO Marsrutas
                (
                    id_Marsrutas,
                    Pradine_vieta,
                    Paskirties_vieta,
                    Atstumas,
                    Trukme
                )
                VALUES
                (
                    ?id_Marsrutas,
                    ?Pradine_vieta,
                    ?Paskirties_vieta,
                    ?Atstumas,
                    ?Trukme
                )";

            Sql.Insert(query, args =>
            {

                var marsrutasModel = marsrutas.Marsrutas;

                args.Add("?id_Marsrutas", marsrutasModel.Id);
                args.Add("?Pradine_vieta", marsrutasModel.PradineVieta);
                args.Add("?Paskirties_vieta", marsrutasModel.PaskirtiesVieta);
                args.Add("?Atstumas", marsrutasModel.Atstumas);
                args.Add("?Trukme", marsrutasModel.Trukme);
            });
        }

        public static void Update(MarsrutasCE marsrutas)
        {
            var query = @"
                UPDATE Marsrutas
                SET
                    Pradine_vieta = ?Pradine_vieta,
                    Paskirties_vieta = ?Paskirties_vieta,
                    Atstumas = ?Atstumas,
                    Trukme = ?Trukme
                WHERE
                    id_Marsrutas = ?id";

            Sql.Update(query, args =>
            {

                var marsrutasModel = marsrutas.Marsrutas;

                args.Add("?Pradine_vieta", marsrutasModel.PradineVieta);
                args.Add("?Paskirties_vieta", marsrutasModel.PaskirtiesVieta);
                args.Add("?Atstumas", marsrutasModel.Atstumas);
                args.Add("?Trukme", marsrutasModel.Trukme);
                args.Add("?id", marsrutasModel.Id);
            });
        }

        public static void Delete(int id)
        {
            var query = @"
                DELETE FROM Marsrutas WHERE id_Marsrutas=?id_Marsrutas";
            Sql.Delete(query, args =>
            {
                args.Add("?id_Marsrutas", id);
            });
        }
    }
}
