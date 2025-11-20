using UnityEngine;

public class GoblinRaiderInstance : CardInstance
{
    public override void AddAbilityEvents()
    {
        // adds the custiom ability to the event
        Events.OnEnterBattlefield += DealTwoDamage;
    }

    private void DealTwoDamage(CardInstance card)
    {
        Debug.Log(definition.cardName + " deals "+definition.abilityVariables[0]+" damage when entering");
    }
}
