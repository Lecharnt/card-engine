using System.Collections.Generic;

[System.Serializable]
public class CardBase
{
    public string cardName;
    public List<string> tags = new List<string>();
    public Dictionary<string, object> variables = new Dictionary<string, object>();
    public List<string> effects = new List<string>();
}
