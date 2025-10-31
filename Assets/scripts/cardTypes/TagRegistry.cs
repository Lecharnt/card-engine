using System.Collections.Generic;
using UnityEngine;

public static class TagRegistry
{
    private static Dictionary<string, TagDefinition> tags;

    public static void Initialize()//this is temp for how mtg would do it
    {
        if (tags != null) return;

        tags = new Dictionary<string, TagDefinition>();

        // this would be a spell wich allmost all cards inhati from 
        Add(new TagDefinition
        {
            name = "Spell",//this is the name of the type this called spell
            category = TagCategory.CardType,//what kind of type is this this is a card type 
        });

        // next is permanent wich inharits from spell and stays on the board 
        Add(new TagDefinition
        {
            name = "Permanent",//the name
            category = TagCategory.CardType,//card type
            inheritsFrom = new List<string> { "Spell" }, // it inharits from spell so it gains all of the vars from the vars above it
            grantedEffects = new List<string> { "StaysOnBoard" }//this adds a flag called stays on borad
        });

        // this inharits from perminit wich then inharits from all above it this means that is has the var of StaysOnBoard
        Add(new TagDefinition
        {
            name = "Creature",
            category = TagCategory.CardType,
            inheritsFrom = new List<string> { "Permanent" },
            defaultVariables = new Dictionary<string, object>//this add mutalbull vars
            {
                { "power", 1 }, //power an int that has a defalt value of 1
                { "health", 1 },// health with a amount of 1
                { "summoningSickness", true }// and a bool for its sommining sickness since it can be canceled by haste
            },
            grantedEffects = new List<string> { "CanBePlayedYourTurn" }//normaly creatures can only be played on your turn
        });

        //this is the tag for land witch is speial because it is a perminit but not a spell so you can cancel out the spell tag
        Add(new TagDefinition
        {
            name = "Land",
            category = TagCategory.CardType,
            inheritsFrom = new List<string> { "Permanent" },
            cancels = new List<string> { "Spell" }
        });

        // this is an instant spell that is not a perminit since it does not inharit from permanent
        Add(new TagDefinition
        {
            name = "Instant",
            category = TagCategory.CardType,
            inheritsFrom = new List<string> { "Spell" },
            grantedEffects = new List<string> { "CanBePlayedAnytime" }//this has the spetial effect that it can be played at any time
        });

        //this i dont think i need to explain
        Add(new TagDefinition
        {
            name = "Sorcery",
            category = TagCategory.CardType,
            inheritsFrom = new List<string> { "Spell" },
            grantedEffects = new List<string> { "CanBePlayedYourTurn" }
        });

        //this is an example of some Identity types 
        Add(new TagDefinition { name = "Dragon", category = TagCategory.Identity });
        Add(new TagDefinition { name = "Goblin", category = TagCategory.Identity });
    }

    public static TagDefinition Get(string name)//this is a getter for the tag defs
    {
        if (tags == null)
        {
            Initialize();
        }

        if (tags.ContainsKey(name))
        {
            return tags[name];
        }

        return null;
    }


    private static void Add(TagDefinition def)
    {
        tags[def.name] = def;
    }
}
