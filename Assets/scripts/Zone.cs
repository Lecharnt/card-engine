using System;
using UnityEngine;

public class Zone : MonoBehaviour//this is the zone class type
{
    public Action OnMouseEnterZone;
    public Action OnMouseExitZone;
    public Action OnZoneClicked;
    public Action<Transform> OnCardAdded;
    public Action<Transform> OnCardRemoved;

    private void OnMouseEnter() => OnMouseEnterZone?.Invoke();
    private void OnMouseExit() => OnMouseExitZone?.Invoke();
    private void OnMouseDown() => OnZoneClicked?.Invoke();

    public virtual void AddCard(Transform card)
    {
        TriggerCardAdded(card);
    }

    public virtual void RemoveCard(Transform card)
    {
        TriggerCardRemoved(card);
    }
    public virtual bool ContainsCard(Transform card)
    {
        return false;
    }

    public virtual void TriggerCardAdded(Transform card) => OnCardAdded?.Invoke(card);
    public virtual void TriggerCardRemoved(Transform card) => OnCardRemoved?.Invoke(card);
}
