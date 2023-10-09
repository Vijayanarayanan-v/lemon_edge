using System;
using app.constant;
namespace app.rule;
public class ExclusionRule : IRule {

    public ExclusionRule() {

    }

    public bool IsSatisfied(string? data, ExclusionRuleCase exclusionRuleCase) {


        var isSatisfied = false;

        if(string.IsNullOrWhiteSpace(data))
            return isSatisfied;

        switch(exclusionRuleCase) {


            case ExclusionRuleCase.Contains:

                if(string.Compare(data, "*", true) == 0 || string.Compare(data, "#", true) == 0)
                    isSatisfied = true;
                break;


            case ExclusionRuleCase.Length:
                if(string.Compare(data, "7", true) == 0)
                    isSatisfied = true;
                break;

            case ExclusionRuleCase.prefix:
                if(string.Compare(data, "0", true) == 0 || string.Compare(data, "1", true) == 0)
                    isSatisfied = true;
                break;
            default:
                isSatisfied = false;
                break;

        }

        return isSatisfied;

    }
}


