using System;
using UnityEngine;

public class Zone : MonoBehaviour//this is the zone class type
{
    public Action OnMouseEnterZone;
    public Action OnMouseExitZone;
    public Action OnZoneClicked;
    public Action<Card> OnCardAdded;
    public Action<Card> OnCardRemoved;

    private void OnMouseEnter() => OnMouseEnterZone?.Invoke();
    private void OnMouseExit() => OnMouseExitZone?.Invoke();
    private void OnMouseDown() => OnZoneClicked?.Invoke();

    public virtual void AddCard(Card card)
    {
        TriggerCardAdded(card);
    }

    public virtual void RemoveCard(Card card)
    {
        TriggerCardRemoved(card);
    }
    public virtual bool ContainsCard(Card card)
    {
        return false;
    }

    public virtual void TriggerCardAdded(Card card)
    {
        OnCardAdded?.Invoke(card);
    }
    public virtual void TriggerCardRemoved(Card card)
    {
        OnCardRemoved?.Invoke(card);
    }
}
