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
    public class TB_TarefaController : Controller
    {
        private DBTarefaEntities db = new DBTarefaEntities();

        // GET: TB_Tarefa
        public ActionResult Index()
        {
            var tB_Tarefa = db.TB_Tarefa.Include(t => t.Tb_Usuario);
            return View(tB_Tarefa.ToList());
        }

        // GET: TB_Tarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Tarefa tB_Tarefa = db.TB_Tarefa.Find(id);
            if (tB_Tarefa == null)
            {
                return HttpNotFound();
            }0
            return View(tB_Tarefa);
        }

        // GET: TB_Tarefa/Create
        public ActionResult Create()
        {
            ViewBag.IDUSU = new SelectList(db.Tb_Usuario, "IDUsu", "Nome");
            return View();
        }

        // POST: TB_Tarefa/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTarefa,Descricao,DataTarefa,IDUSU")] TB_Tarefa tB_Tarefa)
        {
            if (ModelState.IsValid)
            {
                db.TB_Tarefa.Add(tB_Tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSU = new SelectList(db.Tb_Usuario, "IDUsu", "Nome", tB_Tarefa.IDUSU);
            return View(tB_Tarefa);
        }

        // GET: TB_Tarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Tarefa tB_Tarefa = db.TB_Tarefa.Find(id);
            if (tB_Tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSU = new SelectList(db.Tb_Usuario, "IDUsu", "Nome", tB_Tarefa.IDUSU);
            return View(tB_Tarefa);
        }

        // POST: TB_Tarefa/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTarefa,Descricao,DataTarefa,IDUSU")] TB_Tarefa tB_Tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSU = new SelectList(db.Tb_Usuario, "IDUsu", "Nome", tB_Tarefa.IDUSU);
            return View(tB_Tarefa);
        }

        // GET: TB_Tarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Tarefa tB_Tarefa = db.TB_Tarefa.Find(id);
            if (tB_Tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tB_Tarefa);
        }

        // POST: TB_Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Tarefa tB_Tarefa = db.TB_Tarefa.Find(id);
            db.TB_Tarefa.Remove(tB_Tarefa);
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
