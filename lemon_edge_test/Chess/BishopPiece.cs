using System;
using app.chess;
using app.CustomException;
using app.Entity;

namespace lemon_edge_test.Chess;

[TestClass]
public class BishopPiece {

    [TestMethod]
    [ExpectedException(typeof(OutOfLayoutException))]
    public void Passing_OutOfLayoutValue_Throws_OutOfLayOutException() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        bishop.GetCellPosition(new CellPosition(-1, -1));

    }


    [TestMethod]
    [ExpectedException(typeof(LayoutNullException))]
    public void Passing_NullGrid_Throws_LayoutNullException() {

        Bishop bishop = new Bishop(null);
        bishop.GetCellPosition(new CellPosition(0, 0));

    }

    [TestMethod]
    public void Passing_Value_Expect_Down_RightDiagonal() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(2, 2));

        var validMoves = bishop.GetCellPosition(new CellPosition(0, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);


        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_Value_Expect_UP_LeftDiagonal() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(2, 1));
        testValues.Add(new CellPosition(1, 0));

        var validMoves = bishop.GetCellPosition(new CellPosition(3, 2));
        Assert.AreEqual(testValues.Count, validMoves.Count);


        CollectionAssert.AreEqual(testValues, validMoves);

    }

    [TestMethod]
    public void Passing_Value_Expect_UP_RightDiagonal() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(2, 1));
        testValues.Add(new CellPosition(1, 2));

        var validMoves = bishop.GetCellPosition(new CellPosition(3, 0));
        Assert.AreEqual(testValues.Count, validMoves.Count);


        CollectionAssert.AreEqual(testValues, validMoves);

    }


    [TestMethod]
    public void Passing_Value_Expect_down_lefttDiagonal() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(1, 1));
        testValues.Add(new CellPosition(2, 0));

        var validMoves = bishop.GetCellPosition(new CellPosition(0, 2));
        Assert.AreEqual(testValues.Count, validMoves.Count);


        CollectionAssert.AreEqual(testValues, validMoves);

    }


    [TestMethod]
    public void Passing_Value_Expect_All_Diagonal() {

        Bishop bishop = new Bishop(new GridLayout(4, 3));
        var testValues = new List<CellPosition>();
        testValues.Add(new CellPosition(1, 0));
        testValues.Add(new CellPosition(3, 0));
        testValues.Add(new CellPosition(1, 2));
        testValues.Add(new CellPosition(3, 2));

        var validMoves = bishop.GetCellPosition(new CellPosition(2, 1));
        Assert.AreEqual(testValues.Count, validMoves.Count);

        var cellComparer = new CellpositionComparer();
        testValues.Sort(cellComparer);
        validMoves.Sort(cellComparer);
        CollectionAssert.AreEqual(testValues, validMoves);

    }








}

