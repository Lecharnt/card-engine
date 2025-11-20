using System.Collections.Generic;
using System;
using UnityEngine;

public class CreatureTag : BaseTag
{
    public override List<System.Type> InheritsFrom => new()
    {
        typeof(PermanentTag)
    };
    public override Dictionary<string, object> DefaultVariables => new()
    {
        { "power", 1 },
        { "health", 1 },
        { "summoningSickness", true }
    };

    public override List<Action<CardInstance>> GrantedEffects => new()
    {
        (card) =>
        {
            //add to the card events container
            card.Events.OnEnterBattlefield += TestEnter;
        }
    };

    private void TestEnter(CardInstance card)
    {
        Debug.Log(card.definition.cardName+ " entered the battlefield as a Creature");
    }
}
