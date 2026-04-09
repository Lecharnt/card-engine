using UnityEngine;

public class GoblinRaiderInstance : CardInstance
{
    public override void AddAbilityEvents()
    {
        // adds the custiom ability to the event
        Events.OnEnterBattlefield += DealTwoDamage;
        Events.OnDeath += Death;
        Events.OnCast += Cast;
        Events.OnDraw += DrawToHand;

        Events.OnBeginingOfPhase += BeginingOfPhase;
    }

    private void DealTwoDamage(CardInstance card)
    {

        Debug.Log(definition.cardName + " deals "+ definition.abilityVariables[0] +" damage when entering");
    }
    private void Death(CardInstance card)
    {
        Debug.Log("Arg I have died");
    }
    private void Cast(CardInstance card)
    {
        Debug.Log("I have been cast");

    }
    private void DrawToHand(CardInstance card)
    {
        Debug.Log("i have been drawn");
    }
    private void BeginingOfPhase(CardInstance card)
    {
        Debug.Log("It is the Begining Of Phase I cry");
    }
}
