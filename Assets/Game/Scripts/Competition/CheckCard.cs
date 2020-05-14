using System;
using System.Collections.Generic;

public class CheckCard
{
    public Athlete Athlete { get; }
    public float LenghtRoute { get; }
    public int FlagsCount { get; }
    public List<CheckCardMainRow> MainRows { get; }
    public List<CheckCardAdditionalRow> AdditionalRows { get; private set; }
    public DateTime StartTime { get; }
    public TimeSpan FinishTime { get ; private set; }
    public float AverageSpeed { get; private set; }
    public bool Correct { get; private set; }

    private CheckCard(Athlete athlete, Route route, DateTime startTime, List<Punch> punches) {
        Athlete = athlete;
        LenghtRoute = route.LenghtRoute;
        FlagsCount = route.RouteSegments.Count;
        StartTime = startTime;
        MainRows = new List<CheckCardMainRow>();
    }

    public static CheckCard Build(Athlete athlete, Route route, DateTime startTime, List<Punch> punches)
    {
        CheckCard checkCard = new CheckCard( athlete,route,  startTime,  punches);

        // 1 part
        foreach (RouteSegment routeSegment in route.RouteSegments)
        {
            CheckCardMainRow row = new CheckCardMainRow
            {
                number = routeSegment.ControlPoint.GetNumber(),
                distanceLenght = routeSegment.DistanceFromPreviousControlPoint
            };
            checkCard.MainRows.Add(row);
        }

        // 2 part
        int index = 0;
        checkCard.AdditionalRows = new List<CheckCardAdditionalRow>();
        foreach (CheckCardMainRow row in checkCard.MainRows)
        {
            for (int i = index; i < punches.Count; i++)
            {
                Punch currentPunch = punches[i];
                if (row.number.Equals(currentPunch.NumberControlPoint))
                {
                    row.timeTotal = currentPunch.PunchesTime - startTime;
                    row.ok = true;
                    for (int j = index; j < i; j++)
                    {
                        checkCard.AdditionalRows.Add(new CheckCardAdditionalRow(punches[j].NumberControlPoint, punches[j].PunchesTime - startTime));
                    }
                    index = i + 1;
                    break;
                }
            }
        }

        // 3 part remove
        for (int i = index + 1; i < punches.Count; i++)
        {
            checkCard.AdditionalRows.Add(new CheckCardAdditionalRow(punches[i].NumberControlPoint, punches[i].PunchesTime - startTime));
        }

        // Check
        checkCard.Correct = checkCard.MainRows.Find(x => x.ok == false) == null;

        // part 4 перегон и спид
        for (int i = 0; i < checkCard.MainRows.Count; i++)
        {
            TimeSpan lastTimeTotal;
            if (!checkCard.MainRows[i].ok) { continue; }
            if (lastTimeTotal == null)
            {
                checkCard.MainRows[i].timeSegment = checkCard.MainRows[i].timeTotal;
                lastTimeTotal = checkCard.MainRows[i].timeTotal;
                continue;
            }

            if (!checkCard.MainRows[i].ok) { continue; }
            checkCard.MainRows[i].timeSegment = checkCard.MainRows[i].timeTotal - lastTimeTotal;

            checkCard.MainRows[i].speed = checkCard.MainRows[i].timeSegment.TotalMinutes / (checkCard.MainRows[i].distanceLenght / 1000);
            lastTimeTotal = checkCard.MainRows[i].timeTotal;
        }

        if (checkCard.Correct)
        {
            checkCard.AverageSpeed = (float)checkCard.MainRows[checkCard.MainRows.Count-1].timeTotal.TotalMinutes/ (route.LenghtRoute / 1000);
        }

        checkCard.FinishTime = checkCard.MainRows[checkCard.MainRows.Count-1].timeTotal; //TODO игра не закончена выходом
        return checkCard;
    }

    public class CheckCardMainRow
    {
        public string number;
        public TimeSpan timeTotal;
        public TimeSpan timeSegment;
        public double speed;
        public float distanceLenght;
        public bool ok = false;

        public override string ToString()
        {
            return (ok ? "Ok" : "---") + number + " " + timeTotal + " " + timeSegment + " " + speed;
        }
    }

    public class CheckCardAdditionalRow
    {
        public string number;
        public TimeSpan timeTotal;

        public CheckCardAdditionalRow(string number, TimeSpan timeTotal)
        {
            this.number = number;
            this.timeTotal = timeTotal;
        }

        public override string ToString()
        {
            return "*" + number + " " + timeTotal;
        }
    }
}