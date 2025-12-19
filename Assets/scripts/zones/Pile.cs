using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : Zone, ICardInteractable
{
    [Header("Pile Settings")]
    public float cardOffsetY = 0.01f;
    public float moveSmooth = 15f;
    public bool isDraggable = false;
    public int dragableCard = 1;

    [HideInInspector] public List<Card> cards = new List<Card>();
    private Dictionary<Card, Coroutine> cardCoroutines = new Dictionary<Card, Coroutine>();

    bool ICardInteractable.isDraggable { get; set; }
    int ICardInteractable.dragableCard { get; set; }


    private void Awake()
    {
        var interactable = (ICardInteractable)this;
        interactable.isDraggable = isDraggable;
        interactable.dragableCard = dragableCard;
    }

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
    public override bool ContainsCard(Card card)
    {
        return cards.Contains(card);
    }
    public virtual void FixLayout()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.y -= i * cardOffsetY;
            cards[i].cardTransform.position = pos;
        }
    }

    public virtual void FixLayerOrder()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var sr = cards[i].GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = i;
        }
    }
}
