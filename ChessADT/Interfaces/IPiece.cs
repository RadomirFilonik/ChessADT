namespace ChessADT.Interfaces
{
    public interface IPiece
    {
        string Position { get; set; }

        string[] ComputeMoves();
    }
}