using UnityEngine;
using System.Collections.Generic;

public class ZoneManager : MonoBehaviour
{
    public Dictionary<string, Zone> zones = new Dictionary<string, Zone>();

    void Awake()//adds zones to dic
    {
        Zone[] allZones = FindObjectsByType<Zone>(FindObjectsSortMode.None);
        foreach (Zone z in allZones)
        {
            if (!zones.ContainsKey(z.name))
            {
                zones.Add(z.name, z);
                GlobalVars.cardsInZone.Add(z.name, new GlobalVars.CardZone(z));
            }
            else
                Debug.LogWarning("multabull of the same zone name " + z.name);

        }
    }

    public void MoveCard(Card card, Zone fromZone, Zone toZone)
    {
        if (card == null || fromZone == null || toZone == null)
        {
            Debug.LogWarning("invalled prams for move card");
            return;
        }

        if (fromZone == toZone)// this is temp so when i later implement event calls for moveing to zone this might bring up an error
        {
            fromZone.RemoveCard(card);
            toZone.AddCard(card);
            return;
        }
        if (fromZone.name == "hand" && toZone.name == "battlefield")
        {
            CardInstance cardInstance = card.cardInstance;
            cardInstance.Events.TriggerPlay(cardInstance);
        }
        if (fromZone.name == "draw" && toZone.name == "hand")
        {
            CardInstance cardInstance = card.cardInstance;
            cardInstance.Events.TriggerDraw(cardInstance);
        }
        fromZone.RemoveCard(card);
        toZone.AddCard(card);
    }


    public Zone FindZoneContaining(Card card)
    {
        foreach (var kvp in zones)
        {
            if (kvp.Value.ContainsCard(card))
                return kvp.Value;
        }
        return null;
    }


    public void MoveCardToZone(Card card, string zoneKey)
    {
        if (!zones.TryGetValue(zoneKey, out Zone targetZone))
        {
            Debug.LogWarning("zone key is not found " + zoneKey);
            return;
        }

        Zone from = FindZoneContaining(card);
        MoveCard(card, from, targetZone);
    }
    public GameObject AddNewCardToZone(GameObject cardPrefab, string zoneKey)
    {
        if (!zones.TryGetValue(zoneKey, out Zone targetZone))
        {
            Debug.LogWarning("zone key is not found " + zoneKey);
            return null;
        }

        if (cardPrefab == null) return null;

        GameObject newCard = Instantiate(cardPrefab);
        Card card = newCard.GetComponent<Card>();
        GameManager.Instance.dragManager.draggableObjects.Add(card);//temp this should eventually be in the setting mager for game start state
        targetZone.AddCard(card);

        return newCard;
    }

}
