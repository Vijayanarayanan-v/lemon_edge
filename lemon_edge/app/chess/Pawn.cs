using System;
using app.Entity;
using app.CustomException;

namespace app.chess;

public class Pawn : IChessPiece {

    private GridLayout? _gridLayout;
    private List<CellPosition>? validMoves;
    private int[] xvector = { 1, 2 };

    public Pawn(GridLayout? gridLayout) {

        this._gridLayout = gridLayout;
    }


    public List<CellPosition> GetCellPosition(CellPosition currentPosition) {

        if(_gridLayout is null)
            throw new LayoutNullException($"Cannot find valid position for {nameof(Pawn)},Grid shouldn't be null");



        if(ChessUtility.isCellPositionOutOfLayout(currentPosition, _gridLayout))
            throw new OutOfLayoutException($"Cell position is{currentPosition.Row}{currentPosition.Column} ");


        validMoves = new List<CellPosition>();


        for(int i = 0; i < xvector.Length; i++) {

            CellPosition newCellPosition = new CellPosition(currentPosition.Row + xvector[i], currentPosition.Column);

            if(!ChessUtility.isCellPositionOutOfLayout(newCellPosition, _gridLayout)) {

                validMoves.Add(newCellPosition);

            }
        }

        return validMoves;
    }


}

