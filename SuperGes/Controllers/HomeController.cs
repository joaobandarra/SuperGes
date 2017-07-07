using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperGes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SobreMim()
        {
            ViewBag.Message = "Sobre mim: ";

            return View();
        }

        public ActionResult OndeEstamos()
        {
            ViewBag.Message = "Onde Estamos: ";

            return View();
        }
        public ActionResult Talho()
        {
            ViewBag.Message = "Carnes: ";

            return View();
        }
        public ActionResult Peixaria()
        {
            ViewBag.Message = "Peixes: ";

            return View();
        }
        public ActionResult Legumes()
        {
            ViewBag.Message = "Legumes: ";

            return View();
        }
        public ActionResult Fruta()
        {
            ViewBag.Message = "Frutas: ";

            return View();
        }
        public ActionResult FeiGrao()
        {
            ViewBag.Message = "Feijão e Grão: ";

            return View();
        }
        public ActionResult Conservas()
        {
            ViewBag.Message = "Conservas: ";

            return View();
        }
        public ActionResult Snacks()
        {
            ViewBag.Message = "Snacks: ";

            return View();
        }
        public ActionResult Cereais()
        {
            ViewBag.Message = "Cereais: ";

            return View();
        }
        public ActionResult Leite()
        {
            ViewBag.Message = "Leites: ";

            return View();
        }
        public ActionResult Games()
        {
            ViewBag.Message = "Jogos de Vídeo: ";

            return View();
        }
        public ActionResult Brinquedos()
        {
            ViewBag.Message = "Brinquedos: ";

            return View();
        }

    }
}