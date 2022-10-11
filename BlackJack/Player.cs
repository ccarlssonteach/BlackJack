namespace BlackJack;
public class Player
{
    public List<Card> Hand { get; set; } = new List<Card>();
    public Card LastDrawnCard { get { return Hand[0]; } } 
    public int LowValue { 
        get
        {
            int sum = 0;
            foreach (var card in Hand)
            {
                if (card.Value > 9)
                    sum += 10;
                else
                    sum += card.Value;
            }
            return sum;
        }  
    }

    public int HighValue { 
        get 
        {
            int sum = 0;
            foreach (var card in Hand)
            {
                if (card.Value == 1)
                {
                    sum += 11;
                }
                else if (card.Value > 9)
                {
                    sum += 10;
                }
                else
                {
                    sum += card.Value;
                }
            }
            return sum;
        } 
    }
    public int BestValue
    {
        get
        {
            return HighValue > 21 ? LowValue : HighValue;
            //if(HighValue > 21) 
            //    return LowValue;
            //else
            //    return HighValue;
        }
    }

    public void Reset()
    {
        Hand = new List<Card>();
    }

    public override string ToString()
    {
        string result = "";
        foreach (var card in Hand)
        {
            result += card.ToString() + "\n";
        }
        return result;
    }

}
