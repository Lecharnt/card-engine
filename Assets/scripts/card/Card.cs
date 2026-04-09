using System;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, ITargetable
{
    public CardDefinition cardDefinition;
    public CardInstance cardInstance;
    public CardAnimation cardAnimation;
    public Transform cardTransform;
    public SpriteRenderer cardRenderer;

    public List<Func<Card, Card, Zone, List<string>, List<string>, bool>> TargetChecks {get; set;}
}
