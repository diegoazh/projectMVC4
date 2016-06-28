using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegundoParcialProgramacion.Models;

namespace SegundoParcialProgramacion.Controllers
{
    public class IndexController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            comentarioDataContext db = new comentarioDataContext();
            var comentarios = 
                from coment in db.Comentarios
                orderby coment.fecha descending
                select coment;
            ViewBag.comentarios = comentarios;

            return View(ViewBag.comentarios);
        }

        [HttpPost]
        public ActionResult Index(string nombre, string comentario)
        {
            comentarioDataContext db = new comentarioDataContext();
            Comentario c = new Comentario();
            if(nombre.Length > 4)
                c.nombre = nombre;
            if(comentario.Length != 0)
                c.comentario1 = comentario;

            c.fecha = DateTime.Today;
            db.Comentarios.InsertOnSubmit(c);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

    }
}
