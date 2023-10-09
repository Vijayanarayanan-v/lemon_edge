using System;
using app.constant;

namespace app.rule;



public interface IRule {

    bool IsSatisfied(string? data, ExclusionRuleCase exclusionRuleCase);

}





