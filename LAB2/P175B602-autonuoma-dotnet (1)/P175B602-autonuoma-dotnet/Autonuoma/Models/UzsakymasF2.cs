namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
/// <summary>
/// 'Uzsakymas' in list form.
/// </summary>
/// 
public class UzsakymasL
{
    [DisplayName("Data")]
    [DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Data { get; set; }

    [DisplayName("Užsakymo statusas")]
    public string Busena { get; set; }

    [DisplayName("Sutartis")]
    public string Sutartis { get; set; }

    [DisplayName("Uzsakymo ID")]
    public int UzsakymoID { get; set; }

    [DisplayName("Vairtuotojas")]
    public string Vairtuotojas { get; set; }

    [DisplayName("Atsiliepimas")]
    public string Atsiliepimas { get; set; }


    [DisplayName("Klientas")]
    public string Klientas { get; set; }

}


/// <summary>
/// 'Uzsakymas' in create and edit forms.
/// </summary>
public class UzsakymasCE
{
    /// <summary>
    /// Entity data.
    /// </summary>
    public class UzsakymasM
    {

        [DisplayName("Data")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Data { get; set; }

        [DisplayName("Užsakymo statusas")]
        [Required]
        public int FkBusena { get; set; }

        [DisplayName("Sutartis")]
        [Required]
        public string Sutartis { get; set; }
        [Required]
        [DisplayName("Uzsakymo ID")]
        public int UzsakymoID { get; set; }

        [DisplayName("Vairtuotojas")]
        [Required]
        public int FkVairtuotojas { get; set; }

        [DisplayName("Atsiliepimas")]
        [Required]
        public int FkAtsiliepimas { get; set; }


        [DisplayName("Klientas")]
        [Required]
        public int FkKlientas { get; set; }

    }

    /// <summary>
    /// Representation of 'UzsakytasKrovinys' entity in 'Uzsakymas' edit form.
    /// </summary>
    public class UzsakytasKrovinysM
    {
        /// <summary>
        /// ID of the record in the form. Is used when adding and removing records.
        /// </summary>
        public int InListId { get; set; }

        [DisplayName("Krovinys")]
        [Required]
        public string Krovinys { get; set; }

        [DisplayName("Kiekis")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Kiekis { get; set; }
    }

    /// <summary>
    /// Select lists for making drop downs for choosing values of entity fields.
    /// </summary>
    public class ListsM
    {
        public IList<SelectListItem> Busena { get; set; }
        public IList<SelectListItem> Sutarties_busena { get; set; }
        public IList<SelectListItem> Vairuotojas { get; set; }
        public IList<SelectListItem> Atsiliepimas { get; set; }
        public IList<SelectListItem> Klientas { get; set; }
        public IList<SelectListItem> Krovinys {get;set;}
    }


    /// <summary>
    /// Uzsakymas.
    /// </summary>
    public UzsakymasM Uzsakymas { get; set; } = new UzsakymasM();

    /// <summary>
    /// Related 'UzsakytaPaslauga' records.
    /// </summary>
    public IList<UzsakytasKrovinysM> UzsakytasKrovinys { get; set; } = new List<UzsakytasKrovinysM>();

    /// <summary>
    /// Lists for drop down controls.
    /// </summary>
    public ListsM Lists { get; set; } = new ListsM();
}


/// <summary>
/// 'UzsakymoBusena' enumerator in lists.
/// /// </summary>
public class Busena
{
    public int Id { get; set; }
    public string Pavadinimas { get; set; }
}
public class SutartiesBusena
{
    public int Id { get; set; }

    public string Pavadinimas { get; set; }
}