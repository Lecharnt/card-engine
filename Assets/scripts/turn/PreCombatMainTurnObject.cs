using UnityEngine;

public class PreCombatMainTurnObject : TurnObject
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
