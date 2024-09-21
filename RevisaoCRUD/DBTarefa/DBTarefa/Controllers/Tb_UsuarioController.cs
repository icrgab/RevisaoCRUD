using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBTarefa.Models;

namespace DBTarefa.Controllers
{
    public class Tb_UsuarioController : Controller
    {
        private DBTarefaEntities db = new DBTarefaEntities();

        // GET: Tb_Usuario
        public ActionResult Index()
        {
            return View(db.Tb_Usuario.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login([Bind] (Include = "IDUsu, Nome, Senha")] TB_Usuario tB_Usuario)
        {
            TB_Usuario usuario = db.TB_Usuario.Where(x => x.Nome == tB_Usuario.Nome &&
               x.Senha == tB_Usuario.Senha.FirstOrDefault());
        if(usuario==null)
            return redirectToAction("Login", "TB_Usuario");
        else
        {
            return  redirectToAction("Index", "Home");
    }
            }


        // GET: Tb_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Usuario tb_Usuario = db.Tb_Usuario.Find(id);
            if (tb_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_Usuario);
        }

        // GET: Tb_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tb_Usuario/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUsu,Nome,Senha")] Tb_Usuario tb_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Usuario.Add(tb_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Usuario);
        }

        // GET: Tb_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Usuario tb_Usuario = db.Tb_Usuario.Find(id);
            if (tb_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_Usuario);
        }

        // POST: Tb_Usuario/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUsu,Nome,Senha")] Tb_Usuario tb_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Usuario);
        }

        // GET: Tb_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Usuario tb_Usuario = db.Tb_Usuario.Find(id);
            if (tb_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_Usuario);
        }

        // POST: Tb_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Usuario tb_Usuario = db.Tb_Usuario.Find(id);
            db.Tb_Usuario.Remove(tb_Usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
