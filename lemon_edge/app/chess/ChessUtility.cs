using System;
using app.Entity;

namespace app.chess;

public class ChessUtility {

    public static bool isCellPositionOutOfLayout(CellPosition currentPosition, GridLayout gridLayout) {

        if(currentPosition.Row < 0 || currentPosition.Column < 0 ||
        currentPosition.Row >= gridLayout?.RowCount || currentPosition.Column >= gridLayout?.ColumnCount)
            return true;
        return false;
    }


}

