using UnityEngine;
using System.Collections.Generic;

public class CardInstance : MonoBehaviour
{//this is the base class for the card has all the info an exists in the game
    public CardDefinition definition;//these are the vars like tags and such

    public Dictionary<string, object> variables = new();//these are the vars added by the class like health
    public CardEvents Events { get; private set; } = new();//these are the call for the events that effect this card
    [HideInInspector]
    public List<string> finalTags = new();//these are all the tags that were added

    public virtual void AddAbilityEvents() { }//this is where the abilitys will conect to an event this function orginises that call
}
