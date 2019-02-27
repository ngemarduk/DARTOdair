using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DARTOdairMVC.Models;
using DinheiroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DARTOdairMVC.Controllers
{
    public class DinheiroController : Controller
    {
        // GET: Dinheiro
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Dinheiro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DinheiroModel dinheiro)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DinheirCalculaService objDinheiroCalcula = new DinheirCalculaService();

                    var retorno = objDinheiroCalcula.DinheiroCalcula(dinheiro.valorTotal, dinheiro.valorPago);

                    ViewData["Retorno"] = retorno;
                    return View();

                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
       
    }
}