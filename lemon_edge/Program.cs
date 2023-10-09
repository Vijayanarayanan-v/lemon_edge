using app;
using app.Entity;
using app.chess;
namespace lemon_edge;



class Program {
    static void Main(string[] args) {
        Console.WriteLine("Started");

        //

        GridLayout gridLayout = new GridLayout(4, 3);
        gridLayout.BuildLayout();


        List<IChessPiece> chessPieces = new List<IChessPiece>();

        chessPieces.Add(new Rook(gridLayout));
        chessPieces.Add(new Bishop(gridLayout));
        chessPieces.Add(new King(gridLayout));
        chessPieces.Add(new Knight(gridLayout));
        chessPieces.Add(new Pawn(gridLayout));
        chessPieces.Add(new Queen(gridLayout));





        Appcontroller appcontroller = new Appcontroller(chessPieces, gridLayout);
        appcontroller.Process();

        Console.WriteLine("End");
        Console.WriteLine("Press enter to close");
        Console.ReadLine();
    }
}

