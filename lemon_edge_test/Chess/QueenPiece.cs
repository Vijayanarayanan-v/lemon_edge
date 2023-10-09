using System;
using app.chess;
using app.CustomException;
using app.Entity;

namespace lemon_edge_test.Chess;

[TestClass]
public class QueenPiece {


    CellpositionComparer cellComparer = new CellpositionComparer();
    GridLayout gridLayout = new GridLayout(4, 3);



    [TestMethod]
    [ExpectedException(typeof(OutOfLayoutException))]
    public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

        Queen queen = new Queen(gridLayout);
        queen.GetCellPosition(new CellPosition(-1, -1));

    }


    [TestMethod]
    [ExpectedException(typeof(LayoutNullException))]
    public void Passing_NullGrid_Throws_LayoutNullException() {

        Queen queen = new Queen(null);
        queen.GetCellPosition(new CellPosition(0, 0));

    }


    [TestMethod]
    public void Passing_BorderValue_Expect_Right_Down_Diagonal() {

        Queen queen = new Queen(gridLayout);
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(2, 2));
        testValues.Add(new CellPosition(0, 1));
        testValues.Add(new CellPosition(0, 2));
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(2, 0));
        testValues.Add(new CellPosition(3, 0));

        var validMoves = queen.GetCellPosition(new CellPosition(0, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_BorderValue_Expect_Left_Up_Diagonal() {

        Queen queen = new Queen(gridLayout);
        var testValues = new List<CellPosition>();

        testValues.Add(new CellPosition(2, 1));
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(3, 1));
        testValues.Add(new CellPosition(3, 0));
        testValues.Add(new CellPosition(2, 2));
        testValues.Add(new CellPosition(1, 2));
        testValues.Add(new CellPosition(0, 2));


        var validMoves = queen.GetCellPosition(new CellPosition(gridLayout.RowCount - 1, gridLayout.ColumnCount - 1));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }


    [TestMethod]
    public void Passing_BorderValue_Expect_Left_Down_Diagonal() {


        Queen queen = new Queen(gridLayout);
        var testValues = new List<CellPosition>();


        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(2, 0));
        testValues.Add(new CellPosition(0, 1));
        testValues.Add(new CellPosition(0, 0));
        testValues.Add(new CellPosition(1, 2));
        testValues.Add(new CellPosition(2, 2));
        testValues.Add(new CellPosition(3, 2));


        var validMoves = queen.GetCellPosition(new CellPosition(0, gridLayout.ColumnCount - 1));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_BorderValue_Expect_Right_Up_Diagonal() {


        Queen queen = new Queen(gridLayout);
        var testValues = new List<CellPosition>();


        testValues.Add(new CellPosition(2, 1));
        testValues.Add(new CellPosition(1, 2));
        testValues.Add(new CellPosition(3, 1));
        testValues.Add(new CellPosition(3, 2));
        testValues.Add(new CellPosition(2, 0));
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(0, 0));

        var validMoves = queen.GetCellPosition(new CellPosition(gridLayout.RowCount - 1, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_CenterValue_Expect_Eight_Direction() {


        Queen queen = new Queen(gridLayout);
        var testValues = new List<CellPosition>();

        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(0, 1));
        testValues.Add(new CellPosition(1, 2));
        testValues.Add(new CellPosition(2, 2));
        testValues.Add(new CellPosition(3, 2));
        testValues.Add(new CellPosition(3, 1));
        testValues.Add(new CellPosition(3, 0));
        testValues.Add(new CellPosition(2, 0));

        var validMoves = queen.GetCellPosition(new CellPosition(gridLayout.RowCount / 2, gridLayout.ColumnCount / 2));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }
}


