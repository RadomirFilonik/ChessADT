namespace ChessADT.Interfaces
{
    public interface IPiece
    {
        string Name { get; set; }
        string Position { get; set; }

        string[] ComputeMoves();
    }
}