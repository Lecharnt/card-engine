using UnityEngine;

public class PhaseObject : MonoBehaviour
{
    private Phases currentPhase = Phases.Beginning;

    public enum Phases
    {
        Beginning,
        Middle,
        End
    }

    public virtual void BeginingOfPhase()
    {

    }
    public virtual void MiddleOfPhase()
    {

    }
    public virtual void EndOfPhase()
    {

    }


    //helper functions

    public void GoToNextPhase(bool reverse = false)
    {
        int phaseIndex = (int)currentPhase;

        if (reverse)
            phaseIndex--;
        else
            phaseIndex++;

        if (phaseIndex < 0)
            phaseIndex = System.Enum.GetValues(typeof(Phases)).Length - 1;

        if (phaseIndex >= System.Enum.GetValues(typeof(Phases)).Length)
            phaseIndex = 0;

        currentPhase = (Phases)phaseIndex;

        CallCurrentPhase();
    }

    public void SetCurrentPhase(Phases phase)
    {
        currentPhase = phase;
        CallCurrentPhase();
    }

    private void CallCurrentPhase()
    {
        switch (currentPhase)
        {
            case Phases.Beginning:
                BeginingOfPhase();
                break;

            case Phases.Middle:
                MiddleOfPhase();
                break;

            case Phases.End:
                EndOfPhase();
                break;
        }
    }

    public bool HasNextPhase(bool reverse = false)
    {
        int phaseIndex = (int)currentPhase;

        if (reverse)
            return phaseIndex > 0;

        return phaseIndex < System.Enum.GetValues(typeof(Phases)).Length - 1;
    }
}
