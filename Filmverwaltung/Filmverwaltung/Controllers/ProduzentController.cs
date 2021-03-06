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
	public class ProduzentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProduzentController()
		{
			_unitOfWork = new UnitOfWork(new FilmverwaltungContext());
		}

		// GET: Produzent
		public ActionResult Index()
		{
			return View(_unitOfWork.Produzent.LoadAll());
		}

		// GET: Produzent/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Produzent produzent = _unitOfWork.Produzent.Load(id.Value);
			if (produzent == null)
			{
				return HttpNotFound();
			}
			return View(produzent);
		}

		// GET: Produzent/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Produzent/Create
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Produzent,Vorname,Nachname,Firma")] Produzent produzent)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Produzent.Insert(produzent);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(produzent);
		}

		// GET: Produzent/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Produzent produzent = _unitOfWork.Produzent.Load(id.Value);
			if (produzent == null)
			{
				return HttpNotFound();
			}
			return View(produzent);
		}

		// POST: Produzent/Edit/5
		// Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
		// finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Produzent,Vorname,Nachname,Firma")] Produzent produzent)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Produzent.Update(produzent);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(produzent);
		}

		// GET: Produzent/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Produzent produzent = _unitOfWork.Produzent.Load(id.Value);
			if (produzent == null)
			{
				return HttpNotFound();
			}
			return View(produzent);
		}

		// POST: Produzent/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Produzent produzent = _unitOfWork.Produzent.Load(id);
			_unitOfWork.Produzent.Delete(produzent);
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
