using System;

public class CompetitionEvent
{
    public string Name { get; }

    public string TerrainName { get; }

    public CompetitionTypeByLenght CompetitionTypeByLenght { get; }

    public CompetitionTypeByTime CompetitionTypeByTime { get; }

    public CompetitionTypeByStart CompetitionTypeByStart { get; }

    public CompetitionTypeByVisitingOrder CompetitionTypeByVisitingOrder { get; }

    public CompetitionTypeByNumberOfCompetitors CompetitionTypeByNumberOfCompetitors { get; }

    public CompetitionType CompetitionType { get; }

    public CompetitionEvent(string name, string terrainName, CompetitionTypeByLenght competitionTypeByLenght, 
        CompetitionTypeByTime competitionTypeByTime, CompetitionTypeByStart competitionTypeByStart, CompetitionTypeByVisitingOrder competitionTypeByVisitingOrder, 
        CompetitionTypeByNumberOfCompetitors competitionTypeByNumberOfCompetitors, CompetitionType competitionType)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        TerrainName = terrainName ?? throw new ArgumentNullException(nameof(terrainName));
        CompetitionTypeByLenght = competitionTypeByLenght ?? throw new ArgumentNullException(nameof(competitionTypeByLenght));
        CompetitionTypeByTime = competitionTypeByTime;
        CompetitionTypeByStart = competitionTypeByStart;
        CompetitionTypeByVisitingOrder = competitionTypeByVisitingOrder;
        CompetitionTypeByNumberOfCompetitors = competitionTypeByNumberOfCompetitors;
        CompetitionType = competitionType;
    }
}
