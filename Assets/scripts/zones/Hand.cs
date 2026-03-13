using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Zone //this is an example of a probley defalt class for zones
{
    [Header("Pile Settings")]
    public float cardOffsetX = 0.01f;
    public float moveSmooth = 15f;

    [HideInInspector] public List<Card> cards = new List<Card>();
    private Dictionary<Card, Coroutine> cardCoroutines = new Dictionary<Card, Coroutine>();

    public override void AddCard(Card card)//adds the card to the zone and animates it and stops all courutens on card
    {
        cards.Add(card);

        card.cardTransform.SetParent(null);
        FixLayout();
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
    }
    void FixLayout()
    {
        if (cards.Count == 0) return;

        int count = cards.Count;

        float handWidth = transform.localScale.x;
        float handHeight = transform.localScale.y;

        // estimate card width
        float cardWidth = cards[0].GetComponent<SpriteRenderer>().bounds.size.x;

        // spacing so cards sit next to each other normally
        float naturalSpacing = cardWidth;

        // spacing allowed inside the hand
        float maxSpacing = handWidth / Mathf.Max(count, 1);

        // choose the smaller spacing
        float spacing = Mathf.Min(naturalSpacing/1.5f, maxSpacing);

        float radius = handWidth * 1.5f;

        float totalWidth = spacing * (count - 1);

        // convert width to arc angle
        float totalAngle = Mathf.Rad2Deg * (totalWidth / radius);

        float startAngle = -totalAngle / 2f;

        Vector3 center = transform.position
            + Vector3.up * (handHeight * 0.25f)
            + Vector3.down * radius;

        for (int i = 0; i < count; i++)
        {
            Card card = cards[i];

            float angle = startAngle + (totalAngle / Mathf.Max(count - 1, 1)) * i;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 targetPos = new Vector3(
                center.x + Mathf.Sin(rad) * radius,
                center.y + Mathf.Cos(rad) * radius,
                transform.position.z
            );

            Quaternion rot = Quaternion.Euler(0, 0, -angle);

            card.cardAnimation.MoveAndRotateTo(targetPos, rot);
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
