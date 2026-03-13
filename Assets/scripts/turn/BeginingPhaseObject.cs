using UnityEngine;

public class BeginingPhaseObject : PhaseObject
{
    public override void BeginingOfPhase()
    {
        Debug.Log("Untap");
    }

    public override void MiddleOfPhase()
    {
        
        Upkeep();
        

    }

    public override void EndOfPhase()
    {
        Debug.Log("Draw");
    }
    public void Upkeep()
    {
        Debug.Log("Upkeep");
    }

}
