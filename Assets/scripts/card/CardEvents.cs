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

    //the triggers for the events
    public void TriggerEnterBattlefield(CardInstance card) => OnEnterBattlefield?.Invoke(card);
    public void TriggerLeaveBattlefield(CardInstance card) => OnLeaveBattlefield?.Invoke(card);
    public void TriggerPlay(CardInstance card) => OnCast?.Invoke(card);
    public void TriggerDeath(CardInstance card) => OnDeath?.Invoke(card);
    public void TriggerDamageTaken(CardInstance card, int dmg) => OnDamageTaken?.Invoke(card, dmg);
    public void TriggerUpkeep(CardInstance card) => OnUpkeep?.Invoke(card);
    public void TriggerDraw(CardInstance card) => OnDraw?.Invoke(card);
}
