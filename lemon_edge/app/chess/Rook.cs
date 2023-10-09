using System;
using app.Entity;
using app.CustomException;

namespace app.chess;

public class Rook : IChessPiece {


    private GridLayout? _gridLayout;
    private List<CellPosition>? validMoves;

    public Rook(GridLayout? gridLayout) {

        this._gridLayout = gridLayout;
    }



    public List<CellPosition> GetCellPosition(CellPosition currentPosition) {

        if(_gridLayout is null)
            throw new LayoutNullException($"Cannot find valid position for {nameof(Rook)},Grid shouldn't be null");

        if(ChessUtility.isCellPositionOutOfLayout(currentPosition, _gridLayout))
            throw new OutOfLayoutException($"Cell position is{currentPosition.Row}{currentPosition.Column} ");


        validMoves = new List<CellPosition>();



        for(int i = 1; i + currentPosition.Row < this._gridLayout?.RowCount; i++) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column));

        }



        for(int i = -1; i + currentPosition.Row >= 0; i--) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column));

        }



        for(int i = 1; i + currentPosition.Column < this._gridLayout?.ColumnCount; i++) {


            validMoves.Add(new CellPosition(currentPosition.Row, currentPosition.Column + i));

        }


        for(int i = -1; i + currentPosition.Column >= 0; i--) {


            validMoves.Add(new CellPosition(currentPosition.Row, currentPosition.Column + i));

        }
        return validMoves;
    }


}







