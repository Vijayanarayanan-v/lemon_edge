using System;
using app.chess;
using app.CustomException;
using app.Entity;

namespace lemon_edge_test.Chess {

    [TestClass]
    public class KingPiece {


        CellpositionComparer cellComparer = new CellpositionComparer();
        GridLayout gridLayout = new GridLayout(4, 3);

        [TestMethod]
        [ExpectedException(typeof(OutOfLayoutException))]
        public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

            King king = new King(gridLayout);
            king.GetCellPosition(new CellPosition(-1, -1));

        }


        [TestMethod]
        [ExpectedException(typeof(LayoutNullException))]
        public void Passing_NullGrid_Throws_LayoutNullException() {

            King king = new King(null);
            king.GetCellPosition(new CellPosition(0, 0));

        }

        [TestMethod]
        public void Passing_BorderValue_Expect_Right_Down_Diagonal() {

            King king = new King(gridLayout);
            var testValues = new List<CellPosition>();
            testValues.Add(new CellPosition(0, 1));
            testValues.Add(new CellPosition(1, 0));
            testValues.Add(new CellPosition(1, 1));

            var validMoves = king.GetCellPosition(new CellPosition(0, 0));
            Assert.AreEqual(testValues.Count, validMoves.Count);

            validMoves.Sort(cellComparer);
            testValues.Sort(cellComparer);
            CollectionAssert.AreEqual(testValues, validMoves);

        }

        [TestMethod]
        public void Passing_BorderValue_Expect_Left_Up_Diagonal() {

            King king = new King(gridLayout);
            var testValues = new List<CellPosition>();
            testValues.Add(new CellPosition(3, 1));
            testValues.Add(new CellPosition(2, 2));
            testValues.Add(new CellPosition(2, 1));

            var validMoves = king.GetCellPosition(new CellPosition(gridLayout.RowCount - 1, gridLayout.ColumnCount - 1));
            Assert.AreEqual(testValues.Count, validMoves.Count);

            validMoves.Sort(cellComparer);
            testValues.Sort(cellComparer);
            CollectionAssert.AreEqual(testValues, validMoves);

        }

        [TestMethod]
        public void Passing_BorderValue_Expect_Left_Down_Diagonal() {


            King king = new King(gridLayout);
            var testValues = new List<CellPosition>();
            testValues.Add(new CellPosition(0, 1));
            testValues.Add(new CellPosition(1, 2));
            testValues.Add(new CellPosition(1, 1));

            var validMoves = king.GetCellPosition(new CellPosition(0, gridLayout.ColumnCount - 1));
            Assert.AreEqual(testValues.Count, validMoves.Count);

            validMoves.Sort(cellComparer);
            testValues.Sort(cellComparer);
            CollectionAssert.AreEqual(testValues, validMoves);

        }

        [TestMethod]
        public void Passing_BorderValue_Expect_Right_Up_Diagonal() {


            King king = new King(gridLayout);
            var testValues = new List<CellPosition>();
            testValues.Add(new CellPosition(3, 1));
            testValues.Add(new CellPosition(2, 0));
            testValues.Add(new CellPosition(2, 1));

            var validMoves = king.GetCellPosition(new CellPosition(gridLayout.RowCount - 1, 0));
            Assert.AreEqual(testValues.Count, validMoves.Count);

            validMoves.Sort(cellComparer);
            testValues.Sort(cellComparer);
            CollectionAssert.AreEqual(testValues, validMoves);

        }

        [TestMethod]
        public void Passing_CenterValue_Expect_Eight_Direction() {


            King king = new King(gridLayout);
            var testValues = new List<CellPosition>();
            testValues.Add(new CellPosition(1, 0));
            testValues.Add(new CellPosition(1, 1));
            testValues.Add(new CellPosition(1, 2));
            testValues.Add(new CellPosition(2, 2));
            testValues.Add(new CellPosition(3, 2));
            testValues.Add(new CellPosition(3, 1));
            testValues.Add(new CellPosition(3, 0));
            testValues.Add(new CellPosition(2, 0));

            var validMoves = king.GetCellPosition(new CellPosition(gridLayout.RowCount / 2, gridLayout.ColumnCount / 2));
            Assert.AreEqual(testValues.Count, validMoves.Count);

            validMoves.Sort(cellComparer);
            testValues.Sort(cellComparer);
            CollectionAssert.AreEqual(testValues, validMoves);

        }


    }
}

