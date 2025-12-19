using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : Zone //this is an example of a probley defalt class for zones
{
    [Header("Pile Settings")]
    public float cardOffsetX = 0.01f;
    public float moveSmooth = 15f;

    [HideInInspector] public List<Card> cards = new List<Card>();
    private Dictionary<Card, Coroutine> cardCoroutines = new Dictionary<Card, Coroutine>();

    public override void AddCard(Card card)//adds the card to the zone and animates it and stops all courutens on card
    {
        cards.Add(card);

        Vector3 targetPos = transform.position;
        targetPos.x -= cardOffsetX * cards.Count;

        card.cardTransform.SetParent(null);
        card.cardAnimation.MoveTo(targetPos);

        FixLayerOrder();
        TriggerCardAdded(card);
    }

    public override void RemoveCard(Card card) //this removes the card form zonek
    {
        if (card == null || !cards.Contains(card)) return;

        StopAllCoroutines();
        cards.Remove(card);
        card.cardTransform.SetParent(null);

        FixLayout();
        FixLayerOrder();

        base.RemoveCard(card); // triggers OnCardRemoved
    }
    public override bool ContainsCard(Card card)//this is a getter for cards in zone
    {
        return cards.Contains(card);
    }
    public override void TriggerCardAdded(Card card)
    {
        base.TriggerCardAdded(card);
        CardInstance cardInstance = card.GetComponent<CardInstance>();
        cardInstance.Events.TriggerEnterBattlefield(cardInstance);
    }

    void FixLayout()//this fixes the layout
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.x -= i * cardOffsetX;
            cards[i].cardTransform.position = pos;
        }
    }

    void FixLayerOrder()//this fix the layer order
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var sr = cards[i].GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = i;
        }
    }
}
