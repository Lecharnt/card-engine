using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{//turns are the players turn below that are phases below that are the phases phases
    public List<TurnObject> possibleTurns = new List<TurnObject>();
    private Turns currentTurn = Turns.Player;

    public enum Turns
    {
        Player,
        Enemy
    }
    //helper functions
    public void incrementer(
        bool reverseTurn = false, bool isExtraTurn = false,
        bool reversePhase = false, bool isExtraPhase = false,
        bool reversePhasePhase = false, bool isExtraPhasePhase = false
        )
    {
        if (isExtraPhasePhase)
        {
            GetCurrentPhase().CallCurrentPhase();
        }
        else if (GetCurrentPhase().HasNextPhase(reversePhasePhase))
        {
            GetCurrentPhase().GoToNextPhase(reversePhasePhase);
        }


        else if (isExtraPhase)
        {
            GetCurrentTurn().CallCurrentPhase();
        }

        else if (GetCurrentTurn().HasNextPhaseObject(reversePhase))
        {
            GetCurrentTurn().GoToNextPhaseObject(reversePhase);
        }

        
        else
        {
            GoToNextTurn(reverseTurn, isExtraTurn);
        }
    }

    private TurnObject GetCurrentTurn()
    {
        return possibleTurns[(int)currentTurn];
    }
    private PhaseObject GetCurrentPhase()
    {
        return GetCurrentTurn().PhaseOrder[GetCurrentTurn().currentPhaseIndex];
    }

    public void GoToNextTurn(bool reverse = false, bool isExtraTurn = false)
    {
        int phaseIndex = (int)currentTurn;

        if (reverse)
            phaseIndex--;
        else
            phaseIndex++;

        if (phaseIndex < 0)
            phaseIndex = System.Enum.GetValues(typeof(Turns)).Length - 1;

        if (phaseIndex >= System.Enum.GetValues(typeof(Turns)).Length)
            phaseIndex = 0;

        if (!isExtraTurn) currentTurn = (Turns)phaseIndex;
        GetCurrentTurn().currentPhaseIndex = 0;

        CallCurrentTurn();

    }

    public void SetCurrentTurn(Turns phase)
    {
        currentTurn = phase;
        CallCurrentTurn();
    }

    public void CallCurrentTurn()
    {
        possibleTurns[(int)currentTurn].CallCurrentPhase();
    }
    public void CallNextPhase()
    {
        possibleTurns[(int)currentTurn].GetCurrentPhaseObject().GoToNextPhase();
    }

    public bool HasNextTurn(bool reverse = false)
    {
        int phaseIndex = (int)currentTurn;

        if (reverse)
            return phaseIndex > 0;

        return phaseIndex < System.Enum.GetValues(typeof(Turns)).Length - 1;
    }
}
