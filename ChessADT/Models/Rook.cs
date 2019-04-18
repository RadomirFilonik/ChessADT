using ChessADT.Interfaces;
using System.Collections.Generic;

namespace ChessADT.Models
{
    public class Rook : IPiece
    {
        public Rook()
        {
            Position = "A1";
        }

        public string Position { get; set; }
        
        public string[] ComputeMoves()
        {
            List<string> result = new List<string>();
            string actualPosition = Position;

            char yaxis = actualPosition[0];
            char xaxis = actualPosition[1];

            for (int i = 'A'; i <= 'H'; i++)
            {
                if (yaxis == i)
                {
                    for (int j = '1'; j <= '8'; j++)
                    {
                        string pos = "";
                        pos += (char)i;

                        if (xaxis != j)
                        {
                            pos += j - 48;
                            result.Add(pos);
                        }
                    }
                }
                else
                {
                    string pos = "";
                    pos += (char)i + xaxis.ToString();
                    result.Add(pos);
                }
            }
            
            return result.ToArray();
        }
    }
}