using ChessADT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessADT.Models
{
    public class King : IPiece
    {
        public King()
        {
            Name = "King";
            Position = "A2";
        }
        public string Name { get; set; }
        public string Position { get; set; }

        public string[] ComputeMoves()
        {
            List<string> result = new List<string>();
            string actualPosition = Position;

            char yaxis = actualPosition[0];
            char xaxis = actualPosition[1];

            if ((yaxis + 1) <= 'H')
            {
                char y = (char)(yaxis + 1);
                char x;
                string res;

                if ((xaxis - 1) >= 49)
                {
                    x = (char)(xaxis - 1);
                    res = y + "" + x;
                    result.Add(res);
                }

                x = (char)(xaxis);
                res = y + "" + x;
                result.Add(res);

                if ((xaxis + 1)<= 56)
                {
                    x = (char)(xaxis + 1);
                    res = y + "" + x;
                    result.Add(res);
                }
            }

            if ((xaxis - 1) >= 49)
            {
                char x = (char)(xaxis - 1);
                string res = yaxis + "" + x;
                result.Add(res);
            }
            if ((xaxis + 1) <= 56)
            {
                char x = (char)(xaxis + 1);
                string res = yaxis + "" + x;
                result.Add(res);
            }

            if ((yaxis - 1) >= 'A')
            {
                char y = (char)(yaxis - 1);
                char x;
                string res;

                if ((xaxis - 1) >= 49)
                {
                    x = (char)(xaxis - 1);
                    res = y + "" + x;
                    result.Add(res);
                }

                x = (char)(xaxis);
                res = y + "" + x;
                result.Add(res);

                if ((xaxis + 1) <= 56)
                {
                    x = (char)(xaxis + 1);
                    res = y + "" + x;
                    result.Add(res);
                }
            }
            
            return result.ToArray();
        }
    }
}