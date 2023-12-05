class ScrathcTime
{
    public static void Main(string[] args)
    {
        //Read card from input.txt
        var cards = ReadCardsFromFile(@"..\..\..\input.txt");

        int totalPoints = cards.Sum(cards => CalculateCardPoints(cards.Item1, cards.Item2));
        Console.WriteLine(totalPoints);
    }
    private static List<Tuple<List<int>, List<int>>> ReadCardsFromFile(string path)
    {
        var cards = new List<Tuple<List<int>, List<int>>>();

        foreach (var card in File.ReadAllLines(path))
        {
            // Split the line at the ':' character to separate the card number from the numbers
            var parts = card.Split(new char[] { ':' }, 2);
            // Further split the second part at the '|' character to separate winning numbers from your numbers
            var numberParts = parts[1].Trim().Split('|');
            var winningNumbers = numberParts[0].Trim().Split(" ").Select(int.Parse).ToList();
            //var yourNumbers = numberParts[1].Trim().Split(" ").Select(int.Parse).ToList();
            var yourNumbers = numberParts[1].Trim().Split(' ').Select(int.Parse).ToList();

            cards.Add(Tuple.Create(winningNumbers, yourNumbers));
        }

        return cards;
    }
    private static int CalculateCardPoints(List<int> winningNumbers, List<int> yourNumbers)
    {
        var matches = winningNumbers.Intersect(yourNumbers).Count();
        if (matches > 0)
        {
            return (int)Math.Pow(2, matches - 1);
        }
        return 0;
    }
}