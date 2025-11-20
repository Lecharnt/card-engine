using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class CardTagProcessor : MonoBehaviour
{

    public void ProcessCard(CardInstance card)
    {
        // this creates the tags
        var tagComponents = AddDeclaredTags(card);

        // this fixes the inharitence
        ResolveInheritance(tagComponents, card.gameObject);

        //removes the cancled tags out
        ApplyCancels(tagComponents);

        // applys the vars and effects
        ApplyEffects(card, tagComponents);

        //this saves it
        card.finalTags = tagComponents
            .Select(t => t.GetType().Name)
            .ToList();
    }

    private HashSet<BaseTag> AddDeclaredTags(CardInstance card)
    {
        var set = new HashSet<BaseTag>();

        foreach (var tagName in card.definition.tagTypeNames)
        {
            Type t = Type.GetType(tagName);
            var tag = (BaseTag)card.gameObject.AddComponent(t);
            set.Add(tag);
        }


        return set;
    }

    private void ResolveInheritance(HashSet<BaseTag> tags, GameObject cardOBJ)
    {
        bool added = true;

        while (added)
        {
            added = false;

            foreach (var tag in tags.ToList())
            {
                foreach (var parent in tag.InheritsFrom)
                {
                    if (!cardOBJ.TryGetComponent(parent, out var comp))
                        comp = cardOBJ.AddComponent(parent);

                    if (tags.Add((BaseTag)comp))
                        added = true;
                }
            }
        }
    }

    private void ApplyCancels(HashSet<BaseTag> tags)
    {
        HashSet<Type> canceled = new();

        foreach (var t in tags)
            foreach (var c in t.Cancels)
                canceled.Add(c);

        foreach (var c in canceled)
        {
            var comp = tags.FirstOrDefault(t => t.GetType() == c);
            if (comp != null)
                tags.Remove(comp);
        }
    }

    private void ApplyEffects(CardInstance card, HashSet<BaseTag> tags)
    {
        foreach (var tag in tags)
        {
            foreach (var kvp in tag.DefaultVariables)
                card.variables[kvp.Key] = kvp.Value;

            foreach (var effect in tag.GrantedEffects)
                effect(card);
        }
    }
}
