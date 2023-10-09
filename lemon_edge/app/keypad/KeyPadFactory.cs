using System;
using app.Entity;
using app.rule;
using app.chess;
using app.constant;

namespace app.keypad;

public class KeyPadFactory {



    public static IKeyPadController? GetInstance(GridLayout? gridLayout, IChessPiece? chessPiece, IRule rule) {

        return new TelephoneKeypadController(gridLayout, chessPiece, rule);

    }

}

