using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ZoneManager zoneManager;
    public DragManager dragManager;
    public List<GameObject> draggableObjects;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        foreach (GameObject prefab in draggableObjects)//this is temp and a start game function sould controll this
        {
            GameManager.Instance.zoneManager.AddNewCardToZone(prefab, "hand");
        }
        var card = new CardBase { cardName = "Goblin Raider" };

        // Base tag (you define just "Creature" and "Goblin")
        CardBuilder.BuildCard(card, new List<string> { "Creature", "Goblin" });

        Debug.Log($"Card: {card.cardName}");
        Debug.Log($"Tags: {string.Join(", ", card.tags)}");
        Debug.Log($"Effects: {string.Join(", ", card.effects)}");
        foreach (var kvp in card.variables)
            Debug.Log($"Var {kvp.Key} = {kvp.Value}");
    }

}
