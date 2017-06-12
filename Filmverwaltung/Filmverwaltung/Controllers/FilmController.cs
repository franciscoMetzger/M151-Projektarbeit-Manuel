using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmverwaltung.Business.Domain;
using Filmverwaltung.Models;

namespace Filmverwaltung.Controllers
{
	public class FilmController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly List<Produzent> _produzenten;

		public FilmController()
		{
			_unitOfWork = new UnitOfWork(new FilmverwaltungContext());
			_produzenten = new List<Produzent>(_unitOfWork.Produzent.LoadAll());
		}

		// GET: Film
		public ActionResult Index()
		{
			var film = _unitOfWork.Film.LoadAll();
			return View(film.ToList());
		}

		// GET: Film/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Film film = _unitOfWork.Film.Load(id.Value);
			if (film == null)
			{
				return HttpNotFound();
			}

			ViewBag.FilmSchauspieler = film.FilmSchauspieler.Select(x => x.Schauspieler).ToList();

			return View(film);
		}

		// GET: Film/Create
		public ActionResult Create()
		{
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName");
			ViewBag.Schauspieler = _unitOfWork.Schauspieler.LoadAll().ToList();

			return View();
		}

		// POST: Film/Create
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public ActionResult Create(Film film)
		{
			if (ModelState.IsValid)
			{
				foreach (var schauspieler in film.Schauspieler)
				{
					film.FilmSchauspieler.Add(new FilmSchauspieler { FilmId = film.ID_Film, SchauspielerId = schauspieler });
				}

				_unitOfWork.Film.Insert(film);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", film.ProduzentId);
			return View(film);
		}

		// GET: Film/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Film film = _unitOfWork.Film.Load(id.Value);
			if (film == null)
			{
				return HttpNotFound();
			}

			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", film.ProduzentId);
			ViewBag.Schauspieler = _unitOfWork.Schauspieler.LoadAll().ToList();

			return View(film);
		}

		// POST: Film/Edit/5
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public ActionResult Edit(Film film)
		{
			if (ModelState.IsValid)
			{
				foreach (var id in film.Schauspieler)
				{
					var existing = film.FilmSchauspieler.FirstOrDefault(x => x.SchauspielerId == id);
					if (existing != null)
					{
						_unitOfWork.FilmSchauspieler.Delete(existing);
						film.FilmSchauspieler.Remove(existing);
					}
					else
					{
						var newItem = new FilmSchauspieler { FilmId = film.ID_Film, SchauspielerId = id };
						_unitOfWork.FilmSchauspieler.Insert(newItem);
						film.FilmSchauspieler.Add(newItem);
					}
				}

				_unitOfWork.Film.Update(film);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", film.ProduzentId);
			return View(film);
		}

		// GET: Film/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Film film = _unitOfWork.Film.Load(id.Value);
			if (film == null)
			{
				return HttpNotFound();
			}
			return View(film);
		}

		// POST: Film/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Film film = _unitOfWork.Film.Load(id);
			_unitOfWork.Film.Delete(film);
			_unitOfWork.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_unitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
