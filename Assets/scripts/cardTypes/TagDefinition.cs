using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TagDefinition
{
    public string name;
    public TagCategory category;
    public List<string> inheritsFrom = new List<string>();  // what this tag includes
    public List<string> cancels = new List<string>();       // what this tag removes

    // this adds a var to this like health or damage
    public Dictionary<string, object> defaultVariables = new Dictionary<string, object>();

    //this is an event flag for things like when a card can be played or if it remains on the board
    public List<string> grantedEffects = new List<string>();
}

public enum TagCategory
{
    Identity,  // this could be something like a dragon goblen or merfolk where these are tags ment to be detected 
    CardType,  // these are card types like land instant or creature which have vars and flags for how they effect cards
    SuperType  // these are super types that could be legendary where it implements the legend rule 
}
