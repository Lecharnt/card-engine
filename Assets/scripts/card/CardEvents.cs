using System;

[Serializable]
public class CardEvents
{
    //the events
    public event Action<CardInstance> OnEnterBattlefield;
    public event Action<CardInstance> OnLeaveBattlefield;
    public event Action<CardInstance> OnCast;
    public event Action<CardInstance> OnDeath;
    public event Action<CardInstance, int> OnDamageTaken;
    public event Action<CardInstance> OnUpkeep;
    public event Action<CardInstance> OnDraw;

    public event Action<CardInstance> OnBeginingOfPhase;
    public event Action<CardInstance> OnMiddleOfPhase;
    public event Action<CardInstance> OnEndOfPhase;


    //the triggers for the events
    public void TriggerEnterBattlefield(CardInstance card) => OnEnterBattlefield?.Invoke(card);
    public void TriggerLeaveBattlefield(CardInstance card) => OnLeaveBattlefield?.Invoke(card);
    public void TriggerPlay(CardInstance card) => OnCast?.Invoke(card);
    public void TriggerDeath(CardInstance card) => OnDeath?.Invoke(card);
    public void TriggerDamageTaken(CardInstance card, int dmg) => OnDamageTaken?.Invoke(card, dmg);
    public void TriggerUpkeep(CardInstance card) => OnUpkeep?.Invoke(card);
    public void TriggerDraw(CardInstance card) => OnDraw?.Invoke(card);

    public void TriggerBeginingOfPhase(CardInstance card) => OnBeginingOfPhase?.Invoke(card);
    public void TriggerMiddleOfPhase(CardInstance card) => OnMiddleOfPhase?.Invoke(card);
    public void TriggerEndOfPhase(CardInstance card) => OnEndOfPhase?.Invoke(card);

}
