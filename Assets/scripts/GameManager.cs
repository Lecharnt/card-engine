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

    }

}
