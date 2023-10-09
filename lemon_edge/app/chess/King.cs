using System;
using app.Entity;
using app.CustomException;

namespace app.chess;

public class King : IChessPiece {

    private GridLayout? _gridLayout;
    private List<CellPosition>? validMoves;

    int[] rowVector = { 0, 0, -1, 1, 1, -1, -1, 1 };
    int[] columnVector = { 1, -1, 0, 0, 1, -1, 1, -1 };


    public King(GridLayout? gridLayout) {

        this._gridLayout = gridLayout;
    }

    public List<CellPosition> GetCellPosition(CellPosition currentPosition) {


        if(_gridLayout is null)
            throw new LayoutNullException($"Cannot find valid position for {nameof(King)},Grid shouldn't be null");


        if(ChessUtility.isCellPositionOutOfLayout(currentPosition, _gridLayout))
            throw new OutOfLayoutException($"Cell position is{currentPosition.Row}{currentPosition.Column} ");



        validMoves = new List<CellPosition>();


        //King can move in eight Direction

        for(int i = 0; i < 8; i++) {


            var newCellPostion = new CellPosition(rowVector[i] + currentPosition.Row,
                                                  columnVector[i] + currentPosition.Column);

            if(!ChessUtility.isCellPositionOutOfLayout(newCellPostion, _gridLayout))

                validMoves.Add(newCellPostion);



        }

        return validMoves;

    }



}



