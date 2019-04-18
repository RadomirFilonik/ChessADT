using ChessADT.Models;
using System.Web.Mvc;

namespace ChessADT.Controllers
{
    public class ChessBoardController : Controller
    {
        private static Rook rook = new Rook();
        private static King king = new King();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rook()
        {
            return View(rook);
        }

        public ActionResult King()
        {
            return View(king);
        }

        [HttpPost]
        public JsonResult RookMove( string fieldId )
        {
            rook.Position = fieldId;
            return Json(rook.ComputeMoves());
        }

        [HttpPost]
        public JsonResult ValidRookMove(string fieldId)
        {
            foreach (var move in rook.ComputeMoves())
            {
                if (move == fieldId)
                {
                    return Json(new { allowMove = true });
                }
            }
            return Json(new { allowMove = false });
        }

        [HttpPost]
        public JsonResult KingMove(string fieldId)
        {
            king.Position = fieldId;
            return Json(king.ComputeMoves());
        }

        [HttpPost]
        public JsonResult ValidKingMove(string fieldId)
        {
            foreach (var move in king.ComputeMoves())
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