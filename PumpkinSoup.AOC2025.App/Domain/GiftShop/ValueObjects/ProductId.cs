namespace PumpkinSoup.AOC2025.App.Domain.GiftShop.ValueObjects;

public record ProductId
{
    public ProductId(string Value)
    {
        this.Value = long.Parse(Value);
    }
    public ProductId(long Value)
    {
        this.Value = Value;
    }

    public long Value { get; init; }

    public bool IsSillyPattern()
    {
        var idAsArray = Value.ToString().ToCharArray();
        int length = idAsArray.Length;

        if (length % 2 == 1)
            return false;

        var firstHalf = string.Join("", idAsArray.Take(length / 2));
        var secondHalf = string.Join("", idAsArray.Skip(length / 2).Take(length / 2));
        return firstHalf.Equals(secondHalf);
    }

    public bool IsEvenSillierPattern()
    {
        string strId = Value.ToString();
        int length = strId.Length;
        int windowSize = 1;
        
        while (windowSize <= length / 2)
        {
            if (length % windowSize == 0)
            {
                ;

                var sections = new List<string>();
                int i = 0;
                while ((i * windowSize) + windowSize  <= length)
                {
                    sections.Add(strId.Substring(i * windowSize, windowSize));
                    i++;
                }

                if (sections.Distinct().Count() == 1)
                    return true;
            }

            windowSize++;
        }
        
        return false;
    }

}