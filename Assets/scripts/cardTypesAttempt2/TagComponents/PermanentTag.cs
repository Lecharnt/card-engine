using System.Collections.Generic;

public class PermanentTag : BaseTag
{
    public override List<System.Type> InheritsFrom => new()
    {
        typeof(SpellTag)
    };
}
