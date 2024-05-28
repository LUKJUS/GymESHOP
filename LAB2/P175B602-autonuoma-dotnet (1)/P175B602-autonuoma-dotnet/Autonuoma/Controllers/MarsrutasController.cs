using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Salonas;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    public class MarsrutasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var marsrutai = MarsrutasRepo.List();
            return View(marsrutai);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MarsrutasCE mars)
        {
            if (ModelState.IsValid)
            {
                MarsrutasRepo.Insert(mars);
                return RedirectToAction("Index");
            }
            return View(mars);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var marsrutas = MarsrutasRepo.Find(id);
            if (marsrutas == null)
            {
                return NotFound();
            }
            return View(marsrutas);
        }

        [HttpPost]
        public ActionResult Edit(MarsrutasCE mars)
        {
            if (ModelState.IsValid)
            {
                MarsrutasRepo.Update(mars);
                return RedirectToAction("Index");
            }
            return View(mars);
        }

	[HttpGet]
	public ActionResult Delete(int id)
	{
		var marsrutas = MarsrutasRepo.Find(id);
		return View(marsrutas);
	}

	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			MarsrutasRepo.Delete(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var krovinys = MarsrutasRepo.Find(id);
			return View("Delete", krovinys);
		}
	}
    }
}
