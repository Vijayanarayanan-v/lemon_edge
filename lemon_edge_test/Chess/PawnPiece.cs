using System;
using app.chess;
using app.Entity;
using app.CustomException;


namespace lemon_edge_test.Chess;

[TestClass]
public class PawnPiece {


    [TestMethod]
    [ExpectedException(typeof(OutOfLayoutException))]
    public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

        Pawn pawn = new Pawn(new GridLayout(4, 3));
        pawn.GetCellPosition(new CellPosition(-1, -1));

    }


    [TestMethod]
    [ExpectedException(typeof(LayoutNullException))]
    public void Passing_NullGrid_Throws_LayoutNullException() {

        Pawn pawn = new Pawn(null);
        pawn.GetCellPosition(new CellPosition(0, 0));

    }

    [TestMethod]
    public void Passing_CorrectValue() {

        Pawn pawn = new Pawn(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(2, 0));
        var validMoves = pawn.GetCellPosition(new CellPosition(0, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);


        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_ExactBoundaryValue() {

        Pawn pawn = new Pawn(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        var validMoves = pawn.GetCellPosition(new CellPosition(3, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);

    }



}


