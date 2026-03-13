using UnityEngine;

public class ButtionHookManager : MonoBehaviour
{
    public GameManager GameManager;

    public void nextPhase()
    {
        GameManager.turnManager.incrementer();
    }

    public void endTurn()
    {

    }

}
