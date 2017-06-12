﻿using System;
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
			return View(film);
		}

		// GET: Film/Create
		public ActionResult Create()
		{
			ViewBag.ProduzentId = _produzenten;
			return View();
		}

		// POST: Film/Create
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Film,Name,Genre,Laenge,ProduzentId")] Film film)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Film.Insert(film);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "Vorname", film.ProduzentId);
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
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "Vorname", film.ProduzentId);
			return View(film);
		}

		// POST: Film/Edit/5
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Film,Name,Genre,Laenge,ProduzentId")] Film film)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Film.Update(film);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ProduzentId = new SelectList(_produzenten, "ID_Produzent", "Vorname", film.ProduzentId);
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