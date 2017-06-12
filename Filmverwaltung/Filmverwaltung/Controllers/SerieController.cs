using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Filmverwaltung.Business.Domain;
using Filmverwaltung.Models;

namespace Filmverwaltung.Controllers
{
	public class SerieController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly List<Produzent> _produzenten;

		public SerieController()
		{
			_unitOfWork = new UnitOfWork(new FilmverwaltungContext());
			_produzenten = new List<Produzent>(_unitOfWork.Produzent.LoadAll());
		}

		// GET: Serie
		public ActionResult Index()
		{
			return View(_unitOfWork.Serie.LoadAll());
		}

		// GET: Serie/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Serie serie = _unitOfWork.Serie.Load(id.Value);
			if (serie == null)
			{
				return HttpNotFound();
			}
			return View(serie);
		}

		// GET: Serie/Create
		public ActionResult Create()
		{
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName");
			return View();
		}

		// POST: Serie/Create
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Serie,Name,Genre,AnzStaffeln,AnzEpisoden,ProduzentId")] Serie serie)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Serie.Insert(serie);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", serie.ProduzentId);
			return View(serie);
		}

		// GET: Serie/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Serie serie = _unitOfWork.Serie.Load(id.Value);
			if (serie == null)
			{
				return HttpNotFound();
			}
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", serie.ProduzentId);
			return View(serie);
		}

		// POST: Serie/Edit/5
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Serie,Name,Genre,AnzStaffeln,AnzEpisoden,ProduzentId")] Serie serie)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Serie.Update(serie);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "FullName", serie.ProduzentId);
			return View(serie);
		}

		// GET: Serie/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Serie serie = _unitOfWork.Serie.Load(id.Value);
			if (serie == null)
			{
				return HttpNotFound();
			}
			return View(serie);
		}

		// POST: Serie/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Serie serie = _unitOfWork.Serie.Load(id);
			_unitOfWork.Serie.Delete(serie);
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
