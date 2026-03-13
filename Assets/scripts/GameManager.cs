using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private CardTagProcessor cardTagProcessor;
    public ZoneManager zoneManager;
    public DragManager dragManager;
    public TurnManager turnManager;


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
        StartCoroutine(SetupCards());
        turnManager.CallCurrentTurn();
    }

    private IEnumerator SetupCards()
    {
        foreach (GameObject card in draggableObjects)//this is temp and a start game function sould controll this
        {
            GameObject instanceCard = GameManager.Instance.zoneManager.AddNewCardToZone(card, "draw");
            Card cardObj = instanceCard.GetComponent<Card>();//get the card Instance
            cardTagProcessor.ProcessCard(cardObj.cardInstance);//add the tags 
            cardObj.cardInstance.AddAbilityEvents();//add the ability events
            yield return new WaitForSeconds(.2f);
            GameManager.Instance.zoneManager.MoveCardToZone(cardObj, "hand");
        }
    }

}
