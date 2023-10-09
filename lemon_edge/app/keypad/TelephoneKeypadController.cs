using System.Collections.Generic;
using app.Entity;
using app.chess;
using app.rule;
using app.constant;

namespace app.keypad;

public class TelephoneKeypadController : IKeyPadController {


    private GridLayout? _gridLayout;
    private Stack<string?> _phoneNumber = new Stack<string?>();
    private IChessPiece? _chessPiece;
    private IRule _rule;


    public TelephoneKeypadController(GridLayout? gridLayout, IChessPiece? chessPiece, IRule rule) {


        this._gridLayout = gridLayout;
        this._chessPiece = chessPiece;
        this._rule = rule;

    }

    public long GetCountofValidCombination() {

        long validCount = 0;
        string? data = string.Empty;

        if(_chessPiece is null)
            throw new NullReferenceException("chess piece cannot be null");

        if(_rule is null)
            throw new NullReferenceException("rule cannot be null");



        for(int i = 0; i < this._gridLayout?.RowCount; i++) {

            for(int j = 0; j < this._gridLayout?.ColumnCount; j++) {


                data = this._gridLayout?.Grid?[i, j];

                //checking prefix rule and non contains rule 
                if(_rule.IsSatisfied(data, ExclusionRuleCase.Contains) ||
                    _rule.IsSatisfied(data, ExclusionRuleCase.prefix)) {
                    continue;
                }

                this._phoneNumber.Push(data);

                try {

                    validCount += getValidPhoneNumberCombinationsCount(new CellPosition(i, j));

                } catch(Exception ex) {


                    Console.WriteLine($"Exception ocurred at {_chessPiece?.GetType()} Message -{ex.Message}, stackTrace-{ex.StackTrace}");
                    throw;
                }


                this._phoneNumber.Clear();
            }
        }


        return validCount;
    }


    private long getValidPhoneNumberCombinationsCount(CellPosition currentCellPosition) {

        long count = 0;

        try {

            var validPosition = this._chessPiece?.GetCellPosition(currentCellPosition);

            for(int i = 0; i < validPosition?.Count; i++) {

                int rowPointer = validPosition[i].Row;
                int columnPointer = validPosition[i].Column;
                string? data = this._gridLayout?.Grid?[rowPointer, columnPointer];

                //Not contains rule, enter into statement when the rule is not statisfied
                if(!this._rule.IsSatisfied(data, ExclusionRuleCase.Contains)) {

                    this._phoneNumber.Push(data);

                    //checking lenght rule
                    if(this._rule.IsSatisfied(this._phoneNumber.Count.ToString(), ExclusionRuleCase.Length))

                        count++;
                    else

                        count += getValidPhoneNumberCombinationsCount(new CellPosition(rowPointer, columnPointer));

                    this._phoneNumber.Pop();
                }

            }


        } catch(Exception) {

            Console.WriteLine($"Current Cell position row -{currentCellPosition.Row} column-{currentCellPosition.Column}");
            throw;
        }




        return count;

    }

}



