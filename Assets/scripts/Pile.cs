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

    [HideInInspector] public List<Transform> cards = new List<Transform>();
    private Dictionary<Transform, Coroutine> cardCoroutines = new Dictionary<Transform, Coroutine>();

    bool ICardInteractable.isDraggable { get; set; }
    int ICardInteractable.dragableCard { get; set; }


    private void Awake()
    {
        var interactable = (ICardInteractable)this;
        interactable.isDraggable = isDraggable;
        interactable.dragableCard = dragableCard;
    }

    public override void AddCard(Transform card)
    {
        if (cardCoroutines.ContainsKey(card) && cardCoroutines[card] != null)
            StopCoroutine(cardCoroutines[card]);

        Coroutine c = StartCoroutine(MoveCardToPile(card));
        cardCoroutines[card] = c;
    }

    public override void RemoveCard(Transform card)
    {
        if (card == null || !cards.Contains(card)) return;

        StopAllCoroutines();
        cards.Remove(card);
        card.SetParent(null);

        FixLayout();
        FixLayerOrder();

        base.RemoveCard(card); // triggers OnCardRemoved
    }
    public override bool ContainsCard(Transform card)
    {
        return cards.Contains(card);
    }



    IEnumerator MoveCardToPile(Transform card)
    {
        Vector3 targetPos = transform.position;
        targetPos.y -= cardOffsetY * cards.Count;

        cards.Add(card);
        FixLayerOrder();

        while (Vector3.Distance(card.position, targetPos) > 0.01f)
        {
            card.position = Vector3.Lerp(card.position, targetPos, Time.deltaTime * moveSmooth);
            yield return null;
        }

        card.position = targetPos;
        card.SetParent(transform);

        TriggerCardAdded(card);
    }

    void FixLayout()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.y -= i * cardOffsetY;
            cards[i].position = pos;
        }
    }

    void FixLayerOrder()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var sr = cards[i].GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = i;
        }
    }
}
