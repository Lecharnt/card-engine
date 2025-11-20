using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private CardTagProcessor cardTagProcessor;
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
        foreach (GameObject card in draggableObjects)//this is temp and a start game function sould controll this
        {
            GameObject instnceCard = GameManager.Instance.zoneManager.AddNewCardToZone(card, "hand");

            CardInstance cardInstance = instnceCard.GetComponent<CardInstance>();//get the card Instance

            cardTagProcessor.ProcessCard(cardInstance); //add the tags 
            cardInstance.AddAbilityEvents();//add the ability events

            cardInstance.Events.TriggerEnterBattlefield(cardInstance);//this is a test addinf the cards to the battlefield on start

        }
    }

}
