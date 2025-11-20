using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Cards/Card Definition")]
public class CardDefinition : ScriptableObject//this is so you can balence cards later on easly
{
    public string cardName;//the name for the card
    public List<string> tagTypeNames;//the user will put the tags the card should have

    //the list of tags to apply to the card
    public List<Type> TagTypes => new();

    //ability variables for how much damage a card should do
    public List<int> abilityVariables = new();


}
