using System;
using app.Entity;
using app.CustomException;

namespace app.chess;

public class Queen : IChessPiece {

    private GridLayout? _gridLayout;
    private List<CellPosition>? validMoves;

    public Queen(GridLayout? gridLayout) {

        this._gridLayout = gridLayout;
    }

    public List<CellPosition> GetCellPosition(CellPosition currentPosition) {

        if(_gridLayout is null)
            throw new LayoutNullException($"Cannot find valid position for {nameof(Queen)},Grid shouldn't be null");


        if(ChessUtility.isCellPositionOutOfLayout(currentPosition, _gridLayout))
            throw new OutOfLayoutException($"Cell position is{currentPosition.Row}{currentPosition.Column} ");


        validMoves = new List<CellPosition>();
        //Moving (x+1,0) direction 
        for(int i = 1; i + currentPosition.Row < this._gridLayout?.RowCount; i++) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column));

        }


        //Moving (x-1,0) direction 
        for(int i = -1; i + currentPosition.Row >= 0; i--) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column));

        }



        //Moving (0,y+1) direction 
        for(int i = 1; i + currentPosition.Column < this._gridLayout?.ColumnCount; i++) {


            validMoves.Add(new CellPosition(currentPosition.Row, currentPosition.Column + i));

        }


        //Moving (0,y-1) direction 
        for(int i = -1; i + currentPosition.Column >= 0; i--) {


            validMoves.Add(new CellPosition(currentPosition.Row, currentPosition.Column + i));

        }


        //Moving (x+1,y+1) direction 
        for(int i = 1;
            (currentPosition.Row + i < _gridLayout?.RowCount && currentPosition.Column + i < _gridLayout?.ColumnCount);
            i++) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column + i));


        }


        //Moving (x-1,y-1) direction 
        for(int i = -1; (currentPosition.Row + i >= 0 && currentPosition.Column + i >= 0); i--) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column + i));


        }

        //Moving (x+1,y-1) direction 
        for(int i = 1, j = -1; (currentPosition.Row + i < _gridLayout?.RowCount && currentPosition.Column + j >= 0); i++, j--) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column + j));

        }


        //Moving (x-1,y+1) direction 
        for(int i = -1, j = 1; (currentPosition.Row + i >= 0 && currentPosition.Column + j < _gridLayout?.ColumnCount); i--, j++) {


            validMoves.Add(new CellPosition(currentPosition.Row + i, currentPosition.Column + j));

        }

        return validMoves;
    }

}

