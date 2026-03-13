using UnityEngine;

public class PreCombatMainPhaseObject : PhaseObject
{
    public override void BeginingOfPhase()
    {
        foreach (Card card in GlobalVars.cardsInZone["battlefield"].cardsInZone)
        {
            card.cardInstance.Events.TriggerBeginingOfPhase(card.cardInstance);
        }
        Debug.Log("Declare attackers");
    }

    public override void MiddleOfPhase()
    {
        
        Upkeep();
        Debug.Log("Declare blockers");
    }

    public override void EndOfPhase()
    {
        Debug.Log("Deal combat damage");

    }
    public void Upkeep()
    {
        Debug.Log("Upkeep");
    }
}
