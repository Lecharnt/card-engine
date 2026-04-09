using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{

    public List<Func<Card, Card, Zone, List<string>, List<string>, bool>> TargetChecks { get; set; }

    public bool IsTargetable(Card cardSorce, Card target, Zone targetZone, List<string> targetAbleTags = null, List<string> notTargetAbleTags = null)
    {
        foreach (var check in TargetChecks)
        {
            if (check(cardSorce, target, targetZone, targetAbleTags, notTargetAbleTags))
            {
                return false;
            }
        }
        return true;
    }
}
