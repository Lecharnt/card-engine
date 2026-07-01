using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public List<Card> playerHand;
    public List<Card> opponentHand;
    public List<Card> deck;
    public int playerHealth;
    public int opponentHealth;
    public int playerMana;
    // ... all other state

    public GameState Clone()
    {
        return new GameState
        {
            playerHand = new List<Card>(playerHand),
            opponentHand = new List<Card>(opponentHand),
            deck = new List<Card>(deck),
            playerHealth = playerHealth,
            opponentHealth = opponentHealth,
            playerMana = playerMana,
        };
    }
}