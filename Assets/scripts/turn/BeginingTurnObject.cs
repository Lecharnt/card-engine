using UnityEngine;

public class BeginingTurnObject : TurnObject
{
    public override void BeginingOfTurn()
    {

    }

    public override void MiddleOfTurn()
    {
        Debug.Log("Untap");
        Upkeep();
        Debug.Log("Draw");

    }

    public override void EndOfTurn()
    {
    }
    public void Upkeep()
    {
        Debug.Log("Upkeep");
    }

}
