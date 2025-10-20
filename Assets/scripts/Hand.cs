using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Zone //this is an example of a probley defalt class for zones
{
    [Header("Pile Settings")]
    public float cardOffsetX = 0.01f;
    public float moveSmooth = 15f;

    [HideInInspector] public List<Transform> cards = new List<Transform>();
    private Dictionary<Transform, Coroutine> cardCoroutines = new Dictionary<Transform, Coroutine>();

    public override void AddCard(Transform card)//adds the card to the zone and animates it and stops all courutens on card
    {
        if (cardCoroutines.ContainsKey(card) && cardCoroutines[card] != null)
            StopCoroutine(cardCoroutines[card]);

        Coroutine c = StartCoroutine(MoveCardToPile(card));
        cardCoroutines[card] = c;
    }

    public override void RemoveCard(Transform card) //this removes the card form zonek
    {
        if (card == null || !cards.Contains(card)) return;

        StopAllCoroutines();
        cards.Remove(card);
        card.SetParent(null);

        FixLayout();
        FixLayerOrder();

        base.RemoveCard(card); // triggers OnCardRemoved
    }
    public override bool ContainsCard(Transform card)//this is a getter for cards in zone
    {
        return cards.Contains(card);
    }



    IEnumerator MoveCardToPile(Transform card)//this is the animation
    {
        Vector3 targetPos = transform.position;
        targetPos.x -= cardOffsetX * cards.Count;

        cards.Add(card);
        FixLayerOrder();//may change later because in some games the card in hand order may matter

        while (Vector3.Distance(card.position, targetPos) > 0.01f)
        {
            card.position = Vector3.Lerp(card.position, targetPos, Time.deltaTime * moveSmooth);
            yield return null;
        }

        card.position = targetPos;
        card.SetParent(transform);

        TriggerCardAdded(card);
    }


    void FixLayout()//this fixes the layout
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.x -= i * cardOffsetX;
            cards[i].position = pos;
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
