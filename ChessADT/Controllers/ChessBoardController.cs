using ChessADT.Interfaces;
using ChessADT.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ChessADT.Controllers
{
    public class ChessBoardController : Controller
    {
        private static List<IPiece> piecesRepo = new List<IPiece>() { new Rook(), new King()};

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rook()
        {
            var rook = piecesRepo.Find(x => x.Name == "Rook");
            return View(rook);
        }

        public ActionResult King()
        {
            var king = piecesRepo.Find(x => x.Name == "King");
            return View(king);
        }

        [HttpPost]
        public JsonResult Move(string fieldId, string pieceName)
        {
            var piece = piecesRepo.Find(x => x.Name == pieceName);
            piece.Position = fieldId;
            return Json(piece.ComputeMoves());
        }

        [HttpPost]
        public JsonResult ValidMove(string fieldId, string pieceName)
        {
            var piece = piecesRepo.Find(x => x.Name == pieceName);
            foreach (var move in piece.ComputeMoves())
            {
                if (move == fieldId)
                {
                    return Json(new { allowMove = true });
                }
            }
            return Json(new { allowMove = false });
        }
    }
}