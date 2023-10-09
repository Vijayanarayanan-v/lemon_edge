using System;

using app.Entity;
namespace lemon_edge_test.Chess;

public class CellpositionComparer : IComparer<CellPosition> {
    public int Compare(CellPosition x, CellPosition y) {
        if(x.Row == y.Row) {

            return x.Column.CompareTo(y.Column);
        }


        return x.Row.CompareTo(y.Row);

    }
}

