using ChessADT.Interfaces;
using ChessADT.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ChessADT.Controllers
{
    public class ChessBoardController : Controller
    {
        private static Rook rook = new Rook();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rook()
        {
            return View(rook);
        }

        [HttpPost]
        public JsonResult RookMove( string fieldId )
        {
            rook.Position = fieldId;

            return Json(rook.ComputeMoves());
        }

    }
}