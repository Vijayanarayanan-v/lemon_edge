using System;
using app.chess;
using app.CustomException;
using app.Entity;

namespace lemon_edge_test.Chess;

[TestClass]
public class KinightPiece {


    CellpositionComparer cellComparer = new CellpositionComparer();
    GridLayout gridLayout = new GridLayout(4, 4);


    [TestMethod]
    [ExpectedException(typeof(OutOfLayoutException))]
    public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

        Knight knight = new Knight(gridLayout);
        knight.GetCellPosition(new CellPosition(-1, -1));

    }


    [TestMethod]
    [ExpectedException(typeof(LayoutNullException))]
    public void Passing_NullGrid_Throws_LayoutNullException() {

        Knight knight = new Knight(null);
        knight.GetCellPosition(new CellPosition(0, 0));

    }


    [TestMethod]
    public void Passing_CenterValue_Expect_All_Direction() {

        Knight knight = new Knight(gridLayout);
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(0, 1));
        testValues.Add(new CellPosition(0, 3));
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(3, 0));


        var validMoves = knight.GetCellPosition(new CellPosition(2, 2));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        validMoves.Sort(cellComparer);
        testValues.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }




}


