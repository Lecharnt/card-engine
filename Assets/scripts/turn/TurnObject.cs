using System.Collections.Generic;
using UnityEngine;

public class TurnObject : MonoBehaviour
{
    // Phases that happen during this object's turn

    public List<PhaseObject> PhaseOrder = new List<PhaseObject>();

    private int currentPhaseIndex = 0;

    // Call the current phase
    public void CallCurrentPhase()
    {
        if (PhaseOrder.Count == 0) return;

        PhaseOrder[currentPhaseIndex].SetCurrentPhase(PhaseObject.Phases.Beginning);
    }

    // Move to next/previous phase object
    public void GoToNextPhaseObject(bool reverse = false)
    {
        if (PhaseOrder.Count == 0) return;

        if (reverse)
            currentPhaseIndex--;
        else
            currentPhaseIndex++;

        if (currentPhaseIndex < 0)
            currentPhaseIndex = PhaseOrder.Count - 1;

        if (currentPhaseIndex >= PhaseOrder.Count)
            currentPhaseIndex = 0;

        CallCurrentPhase();
    }

    // Jump directly to a specific phase object
    public void SetCurrentPhaseObject(int index)
    {
        if (index < 0 || index >= PhaseOrder.Count) return;

        currentPhaseIndex = index;
        CallCurrentPhase();
    }

    // Check if another phase object exists
    public bool HasNextPhaseObject(bool reverse = false)
    {
        if (PhaseOrder.Count == 0) return false;

        if (reverse)
            return currentPhaseIndex > 0;

        return currentPhaseIndex < PhaseOrder.Count - 1;
    }

    //geter
    public PhaseObject GetCurrentPhaseObject()
    {
        if (PhaseOrder.Count == 0) return null;

        return PhaseOrder[currentPhaseIndex];
    }
}
