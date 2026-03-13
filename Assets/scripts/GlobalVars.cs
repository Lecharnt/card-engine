using System;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars
{
    public static List<Card> cardsInTotal = new List<Card>();

    public static Dictionary<String,CardZone> cardsInZone= new Dictionary<String,CardZone>();
    public class CardZone
    {
        public Zone zone = null;
        public List<Card> cardsInZone = new List<Card>();

        public CardZone(Zone Zone, List<Card> CardsInZone =  null)
        {
            this.zone = Zone;
            this.cardsInZone = CardsInZone ?? new List<Card>();
        }
    }
}
