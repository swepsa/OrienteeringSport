using System;
using System.Collections.Generic;
using System.Linq;

public class Results
{
    private readonly Route route;
    private readonly Dictionary<Athlete, DateTime> startList;

    public Dictionary<Athlete, CheckCard> CheckCards { get; private set; } = new Dictionary<Athlete, CheckCard>();
    public Dictionary<Athlete, TimeSpan> FinishList { get; private set; } = new Dictionary<Athlete, TimeSpan>();

    public Results(Route route, Dictionary<Athlete, DateTime> startList)
    {
        this.route = route;
        this.startList = startList;
    }

    public void AddResult(Athlete athlete, List<Punch> punches)
    {
        startList.TryGetValue(athlete, out DateTime startTime);
        TimeSpan time;

        CheckCard checkCard = CheckCard.Build(athlete, route, startTime, punches);
        CheckCards.Add(athlete, checkCard);

        if (checkCard.Correct)
        {
            time = (punches[punches.Count - 1].PunchesTime - startTime);
        }
        else
        { time = TimeSpan.MaxValue; }

        FinishList.Add(athlete, time);
        FinishList = FinishList.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

    }

}
