using System;
using app.keypad;
using app.chess;
using app.Entity;
using app.constant;
using app.rule;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

namespace app;

public class Appcontroller {


    private List<IChessPiece>? _chessPieces;
    private GridLayout? _gridLayout;
    private Dictionary<string, long> countOfEachChesspice = new Dictionary<string, long>();

    public Appcontroller(List<IChessPiece> chessPieces, GridLayout gridLayout) {

        this._chessPieces = chessPieces;
        this._gridLayout = gridLayout;
    }


    public void Process() {

        if(_chessPieces != null) {

            long count = 0;

            foreach(var chesspiece in _chessPieces) {


                var keypadController = KeyPadFactory.GetInstance(this._gridLayout, chesspiece, RuleFactory.Instance(RuleInstanceType.ExclusionRule));

                if(keypadController != null)
                    count = keypadController.GetCountofValidCombination();

                countOfEachChesspice.TryAdd(chesspiece.GetType().ToString(), count);
            }

            PrintResult();

        }


    }

    private void PrintResult() {


        foreach(var keyvaluePair in countOfEachChesspice) {

            Console.WriteLine($"{keyvaluePair.Key}, {keyvaluePair.Value}");

        }



    }
}

