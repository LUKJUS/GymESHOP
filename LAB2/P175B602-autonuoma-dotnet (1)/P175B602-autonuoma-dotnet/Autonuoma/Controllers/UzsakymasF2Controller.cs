namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.UzsakymasF2;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Vairuotojas;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Krovinys;


/// <summary>
/// Controller for working with 'Sutartis' entity. Implementation of F2 version.
/// </summary>
public class UzsakymasF2Controller : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(UzsakymasF2Repo.ListUzsakymas());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in a browser.
	/// </summary>
	/// <returns>Entity creation form.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var uzsCE = new UzsakymasCE();
		uzsCE.Uzsakymas.Data = DateTime.Now;
		PopulateLists(uzsCE);

		return View(uzsCE);
	}


	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="uzsCE">Entity view model filled with latest data.</param>
	/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, UzsakymasCE uzsCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if (add != null)
		{
			//add entry for the new record
			var up =
				new UzsakymasCE.UzsakytasKrovinysM
				{
					InListId =
						uzsCE.UzsakytasKrovinys.Count > 0 ?
						uzsCE.UzsakytasKrovinys.Max(it => it.InListId) + 1 :
						0,

					Krovinys = null,
					Kiekis = 0
				};
			uzsCE.UzsakytasKrovinys.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(uzsCE);
			return View(uzsCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if (remove != null)
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			uzsCE.UzsakytasKrovinys =
				uzsCE
					.UzsakytasKrovinys
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(uzsCE);
			return View(uzsCE);
		}

		//save of the form data was requested?
		if (save != null)
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for (var i = 0; i < uzsCE.UzsakytasKrovinys.Count - 1; i++)
			{
				var refUp = uzsCE.UzsakytasKrovinys[i];

				for (var j = i + 1; j < uzsCE.UzsakytasKrovinys.Count; j++)
				{
					var testUp = uzsCE.UzsakytasKrovinys[j];

					if (testUp.Krovinys == refUp.Krovinys)
						ModelState.AddModelError($"UzsakytasKrovinys[{j}].Krovinys", "Duplicate of another added service.");
				}
			}

			//form field validation passed?
			if (ModelState.IsValid)
			{
				//create new 'Sutartis'
				uzsCE.Uzsakymas.UzsakymoID = UzsakymasF2Repo.InsertUzsakymas(uzsCE);

				//create new 'UzsakytosPaslaugos' records
				foreach (var upVm in uzsCE.UzsakytasKrovinys)
					UzsakymasF2Repo.InsertUzsakytasKrovinys(uzsCE.Uzsakymas.UzsakymoID, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(uzsCE);
				return View(uzsCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var uzsCE = UzsakymasF2Repo.FindUzsakymasCE(id);

		uzsCE.UzsakytasKrovinys = UzsakymasF2Repo.ListUzsakytasKrovinys(id);
		PopulateLists(uzsCE);

		return View(uzsCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="uzsCE">Entity view model filled with latest data.</param>
	/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, UzsakymasCE uzsCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if (add != null)
		{
			//add entry for the new record
			var up =
				new UzsakymasCE.UzsakytasKrovinysM
				{
					InListId =
						uzsCE.UzsakytasKrovinys.Count > 0 ?
						uzsCE.UzsakytasKrovinys.Max(it => it.InListId) + 1 :
						0,

					Krovinys = null,
					Kiekis = 0
				};
			uzsCE.UzsakytasKrovinys.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(uzsCE);
			return View(uzsCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if (remove != null)
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			uzsCE.UzsakytasKrovinys =
				uzsCE
					.UzsakytasKrovinys
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(uzsCE);
			return View(uzsCE);
		}

		//save of the form data was requested?
		if (save != null)
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for (var i = 0; i < uzsCE.UzsakytasKrovinys.Count - 1; i++)
			{
				var refUp = uzsCE.UzsakytasKrovinys[i];

				for (var j = i + 1; j < uzsCE.UzsakytasKrovinys.Count; j++)
				{
					var testUp = uzsCE.UzsakytasKrovinys[j];

					if (testUp.Krovinys == refUp.Krovinys)
						ModelState.AddModelError($"UzsakytasKrovinys[{j}].Krovinys", "Duplicate of another added service.");
				}
			}

			//form field validation passed?
			if (ModelState.IsValid)
			{
				//update 'Sutartis'
				UzsakymasF2Repo.UpdateUzsakymas(uzsCE);

				//delete all old 'UzsakytosPaslaugos' records
				UzsakymasF2Repo.DeleteUzsakytasKrovinysForSutartis(uzsCE.Uzsakymas.UzsakymoID);

				//create new 'UzsakytosPaslaugos' records
				foreach (var upVm in uzsCE.UzsakytasKrovinys)
					UzsakymasF2Repo.InsertUzsakytasKrovinys(uzsCE.Uzsakymas.UzsakymoID, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(uzsCE);
				return View(uzsCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when deletion form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var sutCE = UzsakymasF2Repo.FindUzsakymasCE(id);
		return View(sutCE);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//load 'Sutartis'
		var uzsCE = UzsakymasF2Repo.FindUzsakymasCE(id);

		//'Sutartis' is in the state where deletion is permitted?
		if (true)
		{
			//delete the entity
			UzsakymasF2Repo.DeleteUzsakytasKrovinysForSutartis(id);
			UzsakymasF2Repo.DeleteUzsakymas(id);

			//redired to list form
			return RedirectToAction("Index");
		}
		//'Sutartis' is in state where deletion is not permitted
		else
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;
			return View("Delete", uzsCE);
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="uzsCE">'Sutartis' view model to append to.</param>
	private void PopulateLists(UzsakymasCE uzsCE)
	{

		//load entities for the select lists
		var kroviniai = KrovinysRepo.ListKrovinys();
		var busenos = UzsakymasF2Repo.ListBusena();
		var klientai = KlientasRepo.List();
		var atsiliepimai = UzsakymasF2Repo.ListAtsiliepimas();
		var vairuotojai = UzsakymasF2Repo.ListVairuotojas();
		var sutartiesbusenos = UzsakymasF2Repo.ListSutartiesBusena();

		//build select lists
		uzsCE.Lists.Krovinys =
			kroviniai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = it.Miestas
						};
				})
				.ToList();

		uzsCE.Lists.Busena =
			busenos
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = it.Pavadinimas
						};
				})
				.ToList();

		uzsCE.Lists.Klientas =
			klientai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = it.Vardas
						};
				})
				.ToList();

		uzsCE.Lists.Atsiliepimas =
			atsiliepimai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.id_Atsiliepimas),
							Text = it.Komentaras
						};
				})
				.ToList();
		uzsCE.Lists.Vairuotojas =
			vairuotojai
			.Select(it =>
			{
				return
					new SelectListItem
					{
						Value = Convert.ToString(it.id_Vairuotojas),
						Text = it.Vardas
					};
			})
				.ToList();
		uzsCE.Lists.Sutarties_busena =
			sutartiesbusenos
			.Select(it =>
			{
				return
					new SelectListItem
					{
						Value = Convert.ToString(it.Id),
						Text = it.Pavadinimas
					};
			})
				.ToList();

		//build select list for 'UzsakytosPaslaugos'
		{
			//initialize the destination list
			uzsCE.Lists.Krovinys = new List<SelectListItem>();

			//load 'Paslaugos' to use for item groups
			var krovinysList = KrovinysRepo.ListKrovinys();

			//create select list items from 'PaslauguKainos' related to each 'Paslaugos'
			foreach (var krovinys in krovinysList)
			{
				//load related 'PaslauguKaina' entities
				var kiekiai = TarpineEiluteRepo.LoadForPaslauga(krovinys.Id);

				//build list items for the group
				foreach (var kiekis in kiekiai)
				{
					var sle =
						new SelectListItem
						{
							Value =
								//we use JSON here to make serialization/deserializaton of composite key more convenient
								JsonConvert.SerializeObject(new
								{
									Krovinys = krovinys.Id
								}),
							Text = $"{krovinys.Miestas}",
						};
					uzsCE.Lists.Krovinys.Add(sle);
				}
			}
		}
	}
}
