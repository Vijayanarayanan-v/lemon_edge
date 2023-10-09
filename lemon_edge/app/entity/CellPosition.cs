using System;
namespace app.Entity {
    public class CellPosition {

        public CellPosition(int row, int column) {

            this.Row = row;
            this.Column = column;
        }
        public int Row {
            get; set;
        }
        public int Column {
            get; set;
        }


        public override bool Equals(object? obj) {

            if(obj is CellPosition other) {
                return Row == other.Row && Column == other.Column;
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Row, Column);
        }


    }
}

