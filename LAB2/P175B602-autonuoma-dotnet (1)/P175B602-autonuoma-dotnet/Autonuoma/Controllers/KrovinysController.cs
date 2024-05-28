
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Krovinys;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

public class KrovinysController : Controller
{
	[HttpGet]
	public ActionResult Index()
	{
		var krovinys = KrovinysRepo.ListKrovinys();
		return View(krovinys);
	}

	[HttpGet]
	public ActionResult Create()
	{
		var krovinys = new KrovinysCE();
		PopulateSelections(krovinys);
		return View(krovinys);
	}

	[HttpPost]
	public ActionResult Create(KrovinysCE ss)
	{

		if (ModelState.IsValid)
		{
			KrovinysRepo.InsertKrovinys(ss);
			return RedirectToAction("Index");
		}
		PopulateSelections(ss);
		return View(ss);
	}

	[HttpGet]
	public ActionResult Edit(int id)
	{
		var krovinys = KrovinysRepo.FindKrovinysCE(id);
		if (krovinys == null)
		{
			return NotFound();
		}
		PopulateSelections(krovinys);
		return View(krovinys);
	}

	[HttpPost]
	public ActionResult Edit(KrovinysCE ss)
	{
		if (ModelState.IsValid)
		{
			KrovinysRepo.UpdateKrovinys(ss);
			return RedirectToAction("Index");
		}
		PopulateSelections(ss);
		return View(ss);
	}

	[HttpGet]
	public ActionResult Delete(int id)
	{
		var krovinys = KrovinysRepo.FindKrovinysCE(id);
		if (krovinys == null)
		{
			return NotFound();
		}
		return View(krovinys);
	}

	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try
		{
			KrovinysRepo.DeleteKrovinys(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch (MySql.Data.MySqlClient.MySqlException)
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var krovinys = KrovinysRepo.FindKrovinysCE(id);
			PopulateSelections(krovinys);
			return View("Delete", krovinys);
		}
	}
	public void PopulateSelections(KrovinysCE krov)
	{
		//load entities for the select lists
		var busenas = KrovinysRepo.ListBusenos();
		var sutartis = KrovinysRepo.ListSutartis();
		//var uzsakymas = KrovinysRepo.ListUzsakymas();
		var transportoPriemones = KrovinysRepo.ListTransport();
		var marsrutas = KrovinysRepo.ListMarsrutas();

		//build select lists
		krov.List.TransportoPriemone =
			transportoPriemones.Select(it =>
			{
				return
					new SelectListItem()
					{
						Value = Convert.ToString(it.id_Transporto_priemone),
						Text = it.Gamintojas
					};
			})
			.ToList();
		krov.List.PristatymoBusena =
			busenas.Select(it =>
			{
				return
					new SelectListItem()
					{
						Value = Convert.ToString(it.Id),
						Text = it.Busena
					};
			})
			.ToList();
		krov.List.MarsrutoList =
			marsrutas.Select(it =>
			{
				return
					new SelectListItem()
					{
						Value = Convert.ToString(it.Id),
						Text = it.Pradine_vieta
					};
			})
			.ToList();
		krov.List.Sutartis =
			sutartis.Select(it =>
			{
				return
					new SelectListItem()
					{
						Value = Convert.ToString(it.id),
						Text = it.name
					};
			})
			.ToList();
	}
}