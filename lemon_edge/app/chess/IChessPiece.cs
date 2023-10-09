using System.Collections.Generic;
using app.Entity;

namespace app.chess;

public interface IChessPiece {

    List<CellPosition> GetCellPosition(CellPosition currentPosition);

}

