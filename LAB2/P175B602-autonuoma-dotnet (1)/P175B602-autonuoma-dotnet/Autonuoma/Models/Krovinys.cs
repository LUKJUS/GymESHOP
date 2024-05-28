namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Krovinys;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity used in lists.
/// </summary>
public class Krovinys
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Miestas")]
    public string Miestas { get; set; }

    [DisplayName("Svoris")]
    public double Svoris { get; set; }

    [DisplayName("Pristatymo Būsena")]
    public int PristatymoBusena { get; set; }

    [DisplayName("Marsrutas")]
    public int fkMarsrutas { get; set; }

    [DisplayName("Transporto priemone")]
    public int fkTransportoPriemone { get; set; }


}
/// <summary>
/// 'Klientas' in create and edit forms.
/// </summary>
public class KrovinysL
{
        [DisplayName("Miestas")]
        public string Miestas { get; set; }

        [DisplayName("Svoris")]
        public decimal Svoris { get; set; }

        [DisplayName("Pristatymo Būsena")]
        public string PristatymoBusena { get; set; }

        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Marsrutas")]
        public string fkMarsrutas { get; set; }

        [DisplayName("Transporto priemone")]
        public string fkTransportoPriemone { get; set; }

}

public class KrovinysCE
{
    public class KrovinysM
    {
        [DisplayName("Miestas")]
        [Required]
        public string Miestas { get; set; }

        [DisplayName("Svoris")]
        [Required]
        public decimal Svoris { get; set; }

        [DisplayName("Pristatymo Būsena")]
        [Required]
        public int PristatymoBusena { get; set; }

        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Marsrutas")]
        
        public int fkMarsrutas { get; set; }

        [DisplayName("Transporto priemone")]
        public int fkTransportoPriemone { get; set; }
    }

    /// <summary>
    /// Select lists for making drop downs for choosing values of entity fields.
    /// </summary>
    public class ListsM
    {
        public IList<SelectListItem> PristatymoBusena { get; set; }
        public IList<SelectListItem> TransportoPriemone { get; set; }
        public IList<SelectListItem> MarsrutoList { get; set; }
        public IList<SelectListItem> Sutartis { get; set; }
    }

    /// <summary>
    /// Lists for drop down controls.
    /// </summary>
    public ListsM List { get; set; } = new ListsM();

    /// <summary>
    /// 
    /// </summary>
    public KrovinysM Krovinys { get; set; } = new KrovinysM();

}
public class PristatymoBusena
{
    public int Id { get; set; }
    public string Busena { get; set; }
}

