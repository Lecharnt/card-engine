using UnityEngine;
using System.Collections.Generic;

public class DragManager : MonoBehaviour
{
    public List<Card> draggableObjects;
    public float clickPadding = 0.2f;
    public float dragSmooth = 15f;

    private Camera cam;
    private Card currentDrag;
    private Zone fromZone;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // this is to start the drag
        if (Input.GetMouseButtonDown(0))
        {
            currentDrag = FindDraggableObject(mousePos);

            if (currentDrag != null)
            {
                fromZone = GameManager.Instance.zoneManager.FindZoneContaining(currentDrag);

                if (fromZone is ICardInteractable interactable)
                {
                    if (!interactable.isDraggable)
                    {
                        currentDrag = null;
                        return;
                    }

                    if (fromZone is Pile pile)
                    {
                        int index = interactable.dragableCard;
                        currentDrag = pile.cards[pile.cards.Count - index];
                    }
                    currentDrag.cardTransform.SetParent(null);
                }
                else
                {
                    currentDrag.cardTransform.SetParent(null);
                    //currentDrag = null;
                    //return;
                }
            }
        }

        // this is for the active draging of the card
        //later have this be more custimisabull
        if (currentDrag != null)
        {
            currentDrag.cardAnimation.MoveTo(mousePos);
        }

            // this is for the droping of the card
            if (Input.GetMouseButtonUp(0) && currentDrag != null)
        {
            Zone zoneUnderMouse = FindZoneUnderMouse(mousePos);

            if (zoneUnderMouse != null)//if the card is in a new zone do this
            {
                GameManager.Instance.zoneManager.MoveCard(currentDrag, fromZone, zoneUnderMouse);
            }
            else // returen the card to its origanal zone
            {
                GameManager.Instance.zoneManager.MoveCard(currentDrag, fromZone, fromZone);
            }

            currentDrag = null;
            fromZone = null;
        }
    }

    Card FindDraggableObject(Vector3 mousePos)//this is to get the card/obgect that is selected
    {
        foreach (Card obj in draggableObjects)
        {
            SpriteRenderer sprite = obj.cardTransform.GetComponent<SpriteRenderer>();
            if (sprite == null) continue;

            Bounds bounds = sprite.bounds;
            bounds.Expand(clickPadding);

            if (bounds.Contains(mousePos))
                return obj;
        }

        return null;
    }

    Zone FindZoneUnderMouse(Vector3 mousePos)//this is to find the zone
    {
        ZoneManager zm = GameManager.Instance.zoneManager;
        foreach (var kvp in zm.zones)
        {
            Zone zone = kvp.Value;
            SpriteRenderer sprite = zone.GetComponent<SpriteRenderer>();
            if (sprite == null) continue;

            Bounds bounds = sprite.bounds;
            bounds.Expand(clickPadding);

            if (bounds.Contains(mousePos))
                return zone;
        }

        return null;
    }
}
