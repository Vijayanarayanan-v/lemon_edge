using System;
using System.Collections.Generic;
using app.constant;

namespace app.rule;

public class RuleFactory {



    private static readonly Dictionary<RuleInstanceType, IRule> _IRuleInstances = new Dictionary<RuleInstanceType, IRule>();

    public static IRule Instance(RuleInstanceType instanceType) {

        if(_IRuleInstances.ContainsKey(instanceType))
            return _IRuleInstances[instanceType];

        switch(instanceType) {

            case RuleInstanceType.ExclusionRule:
                _IRuleInstances.Add(RuleInstanceType.ExclusionRule, new ExclusionRule());
                break;

        }


        return _IRuleInstances[instanceType];
    }




    private static readonly Dictionary<Type, object> _RuleInstances = new Dictionary<Type, object>();

    public static T? GetInstance<T>() where T : class {

        Type type = typeof(T);

        if(!_RuleInstances.ContainsKey(type)) {
            _RuleInstances.Add(type, new Lazy<T>(() => Activator.CreateInstance<T>()));
        }

        return ((Lazy<T>)_RuleInstances[type]).Value;

    }





}

