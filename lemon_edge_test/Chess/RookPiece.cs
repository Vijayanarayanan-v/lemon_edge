using System;
using app.chess;
using app.CustomException;
using app.Entity;

namespace lemon_edge_test.Chess;

public class RookPiece {

    CellpositionComparer cellComparer = new CellpositionComparer();
    GridLayout gridLayout = new GridLayout(4, 4);

    [TestMethod]
    [ExpectedException(typeof(OutOfLayoutException))]
    public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

        Rook rook = new Rook(gridLayout);
        rook.GetCellPosition(new CellPosition(-1, -1));

    }


    [TestMethod]
    [ExpectedException(typeof(LayoutNullException))]
    public void Passing_NullGrid_Throws_LayoutNullException() {

        Rook rook = new Rook(null);
        rook.GetCellPosition(new CellPosition(0, 0));

    }


    [TestMethod]
    public void Passing_BorderValue_Expect_Up_Right_Direction() {

        Rook rook = new Rook(gridLayout);
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(2, 0));
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(0, 0));
        testValues.Add(new CellPosition(3, 1));
        testValues.Add(new CellPosition(3, 2));


        var validMoves = rook.GetCellPosition(new CellPosition(3, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }


    [TestMethod]
    public void Passing_CenterValue_Expect_All_Direction() {

        Rook rook = new Rook(gridLayout);
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(2, 0));
        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(0, 1));
        testValues.Add(new CellPosition(2, 2));
        testValues.Add(new CellPosition(3, 1));


        var validMoves = rook.GetCellPosition(new CellPosition(2, 1));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }

}

