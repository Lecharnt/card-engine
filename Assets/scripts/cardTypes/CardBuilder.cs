using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CardBuilder
{
    public static void BuildCard(CardBase card, List<string> baseTags)
    {
        TagRegistry.Initialize();

        var finalTags = new HashSet<string>(baseTags);

        // idk i looked this up to do transitive closure https://algs4.cs.princeton.edu/42digraph/TransitiveClosure.java.html https://www.youtube.com/watch?v=3uD1ftia8I8
        bool added = true;
        while (added)
        {
            added = false;

            foreach (var tag in finalTags.ToList())
            {
                var def = TagRegistry.Get(tag);
                if (def == null) continue;

                foreach (var parent in def.inheritsFrom)
                {
                    if (finalTags.Add(parent))
                        added = true;
                }
            }
        }

        // Handle cancels
        var cancels = new HashSet<string>();

        foreach (var tag in finalTags)
        {
            var def = TagRegistry.Get(tag);
            if (def?.cancels == null) continue;

            cancels.UnionWith(def.cancels);
        }


        foreach (var tag in cancels)
        {
            finalTags.Remove(tag);
        }
        // this adds the vas and effects
        foreach (var t in finalTags)
        {
            var def = TagRegistry.Get(t);
            if (def == null) continue;

            foreach (var kvp in def.defaultVariables)
                card.variables[kvp.Key] = kvp.Value;

            foreach (var effect in def.grantedEffects)
                card.effects.Add(effect);
        }

        // this saves it
        card.tags = finalTags.ToList();
    }
}
