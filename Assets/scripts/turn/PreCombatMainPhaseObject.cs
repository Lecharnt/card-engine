using UnityEngine;

public class PreCombatMainPhaseObject : PhaseObject
{
    public override void BeginingOfPhase()
    {

    }

    public override void MiddleOfPhase()
    {
        Debug.Log("Untap");
        Upkeep();
        Debug.Log("Draw");
    }

    public override void EndOfPhase()
    {

    }
    public void Upkeep()
    {
        Debug.Log("Upkeep");
    }
}
