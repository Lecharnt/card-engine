using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class BaseTag : MonoBehaviour
{
    public CardInstance Card => GetComponent<CardInstance>();

    //the added parent tags
    public virtual List<System.Type> InheritsFrom => new List<System.Type>();

    //the cancled tag types
    public virtual List<System.Type> Cancels => new List<System.Type>();

    //adds defalt vars to the cards like health and such
    public virtual Dictionary<string, object> DefaultVariables => new Dictionary<string, object>();

    //the effects that the tag give effects to the cards
    public virtual List<Action<CardInstance>> GrantedEffects => new();


}
