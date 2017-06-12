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
	public class SchauspielerController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public SchauspielerController()
		{
			_unitOfWork = new UnitOfWork(new FilmverwaltungContext());
		}

		// GET: Schauspieler
		public ActionResult Index()
		{
			return View(_unitOfWork.Schauspieler.LoadAll());
		}

		// GET: Schauspieler/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Schauspieler schauspieler = _unitOfWork.Schauspieler.Load(id.Value);
			if (schauspieler == null)
			{
				return HttpNotFound();
			}
			return View(schauspieler);
		}

		// GET: Schauspieler/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Schauspieler/Create
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Schauspieler,Vorname,Name,VermittlungsAgentur")] Schauspieler schauspieler)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Schauspieler.Insert(schauspieler);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(schauspieler);
		}

		// GET: Schauspieler/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Schauspieler schauspieler = _unitOfWork.Schauspieler.Load(id.Value);
			if (schauspieler == null)
			{
				return HttpNotFound();
			}
			return View(schauspieler);
		}

		// POST: Schauspieler/Edit/5
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Schauspieler,Vorname,Name,VermittlungsAgentur")] Schauspieler schauspieler)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Schauspieler.Update(schauspieler);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(schauspieler);
		}

		// GET: Schauspieler/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Schauspieler schauspieler = _unitOfWork.Schauspieler.Load(id.Value);
			if (schauspieler == null)
			{
				return HttpNotFound();
			}
			return View(schauspieler);
		}

		// POST: Schauspieler/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Schauspieler schauspieler = _unitOfWork.Schauspieler.Load(id);
			_unitOfWork.Schauspieler.Delete(schauspieler);
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
