using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    BeginingTurnObject BeginingPhaseObject;
    TurnObject PreCombatMainPhaseObject;
    TurnObject CombatPhaseObject;
    TurnObject PostCombatMainPhaseObject;
    TurnObject EndPhaseObject;


    public TurnOrder currentTurn;
    public TurnOrder nextTurn => getNextTurn();

    private TurnOrder getNextTurn()
    {
        return currentTurn + 1;
    }

    public enum TurnOrder
    {
        BeginingPhase,
        PreCombatMainPhase,
        CombatPhase,
        PostCombatMainPhase,
        EndPhase

    }

    public virtual void StartTurnOrder(TurnOrder Turn)
    {
        switch (Turn)
        {
            case TurnOrder.BeginingPhase:
                // Code to handle the menu state
                BeginingPhase();
                break; // Exits the switch block
            case TurnOrder.PreCombatMainPhase:
                // Code to handle the playing state
                PreCombatMainPhase();
                break;
            case TurnOrder.CombatPhase:
                // Code to handle the paused state
                CombatPhase();
                break;
            case TurnOrder.PostCombatMainPhase:
                // Code to handle the game over state
                PostCombatMainPhase();
                break;
            case TurnOrder.EndPhase:
                // Code to handle the game over state
                EndPhase();
                break;
            default:
                // Code to handle any other unexpected value
                Debug.Log("Unknown game state!");
                StartTurnOrder(TurnOrder.BeginingPhase);
                break;
        }
    }
    public virtual void BeginingPhase()
    {
        currentTurn = TurnOrder.BeginingPhase;

        BeginingPhaseObject.StartTurnOrder();
    }
    public virtual void PreCombatMainPhase()
    {
        currentTurn = TurnOrder.PreCombatMainPhase;

        PreCombatMainPhaseObject.StartTurnOrder();
    }
    public virtual void CombatPhase()
    {
        currentTurn = TurnOrder.CombatPhase;

        CombatPhaseObject.StartTurnOrder();
    }
    public virtual void PostCombatMainPhase()
    {
        currentTurn = TurnOrder.PostCombatMainPhase;

        PostCombatMainPhaseObject.StartTurnOrder();
    }
    public virtual void EndPhase()
    {
        currentTurn = TurnOrder.EndPhase;

        EndPhaseObject.StartTurnOrder();
    }
}
