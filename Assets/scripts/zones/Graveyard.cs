using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class Graveyard : Pile
{
    public override void AddCard(Card card)
    {
        cards.Add(card);

        Vector3 targetPos = transform.position;
        targetPos.y -= cardOffsetY * cards.Count;

        card.cardTransform.SetParent(null);
        card.cardAnimation.MoveTo(targetPos);

        FixLayerOrder();
        TriggerCardAdded(card);
    }

    public override void RemoveCard(Card card)
    {
        if (card == null || !cards.Contains(card)) return;

        StopAllCoroutines();
        cards.Remove(card);
        card.cardTransform.SetParent(null);

        FixLayout();
        FixLayerOrder();

        base.RemoveCard(card); // triggers OnCardRemoved
    }
}
