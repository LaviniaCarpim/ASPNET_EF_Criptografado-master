using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using BCrypt.Net;

namespace WebApplication1.Controllers
{
    public class PessoaController : Controller
    {
        private LP2Entities db = new LP2Entities();

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(db.Pessoa.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null) return HttpNotFound();
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,CPF,DataNascimento,Telefone,Email,Senha")] Pessoa pessoa)
        {
            if (string.IsNullOrWhiteSpace(pessoa.Senha))
            {
                ModelState.AddModelError("Senha", "A senha é obrigatória.");
            }

            if (ModelState.IsValid)
            {
                pessoa.Senha = BCrypt.Net.BCrypt.HashPassword(pessoa.Senha);
                db.Pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null) return HttpNotFound();
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CPF,DataNascimento,Telefone,Email,Senha")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var pessoaExistente = db.Pessoa.AsNoTracking().FirstOrDefault(p => p.Id == pessoa.Id);
                if (string.IsNullOrEmpty(pessoa.Senha) && pessoaExistente != null)
                {
                    pessoa.Senha = pessoaExistente.Senha;
                }
                else
                {
                    pessoa.Senha = BCrypt.Net.BCrypt.HashPassword(pessoa.Senha);
                }
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null) return HttpNotFound();
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoa.Find(id);
            db.Pessoa.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}