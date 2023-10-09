using System;
namespace app.Entity {
    public class GridLayout {

        public string[,]? Grid;

        public int RowCount {
            get; set;
        }

        public int ColumnCount {
            get; set;
        }


        public GridLayout(int rowCount, int columnCount) {

            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
        }

        public void BuildLayout() {

            Grid = new string[,] {

                    { "1", "2", "3" },
                    { "4", "5", "6" },
                    { "7", "8", "9" },
                    { "*", "0", "#" },

                };


            //for(int i = 0; i < RowCount; i++) {

            // for(int j = 0; j < ColumnCount; j++) {

            //   Grid[i, j] = Convert.ToString(Console.ReadLine());
            // }

            //}

        }
    }
}

