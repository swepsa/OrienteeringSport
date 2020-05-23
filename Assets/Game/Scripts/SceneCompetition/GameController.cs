using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

//using with GameControllerObject
//GameControllerObject include script "Clock"
public class GameController : MonoBehaviour
{
    public MapController mapController;
    private Competition competition;
    private Results resultsMan;
    private Results resultsWoman;
    private List<Athlete> athletes;
    private DateTime startTime;

    private void Awake()
    {
        //TODO delete/////////////////////////////////
        
            PlayerProfile.Id = 0;
            PlayerProfile.Gender = Gender.male;
            PlayerProfile.Name = "Yuri";
            PlayerProfile.Surname = "Ulyanov";
            PlayerProfile.Team = "Tri-O";

        DataHolder.CompetitionEvent = new CompetitionEvent("Test competition", Constants.TERRAIN_TEST, new CompetitionTypeByLenght.Sprint(), CompetitionTypeByTime.Day,
                CompetitionTypeByStart.Individual, CompetitionTypeByVisitingOrder.CrossCountry, CompetitionTypeByNumberOfCompetitors.Individual, CompetitionType.Individual);

      ////////////////////////////////////////////////////////////////////////////
    
        InitAthletes();
        CreateCompetition();

        Dictionary<Athlete, DateTime> startList = CreateStartList();

        resultsMan = new Results(competition.RouteMan, startList);
        resultsWoman = new Results(competition.RouteWoman, startList);
        DrawRouteOnMap();

        InstantiatePlayer();
    }

    private void Start()
    {
        StartClock();
    }

    public void AddResult(Athlete athlete, Route route, List<Punch> punches)
    {
        if (route.Equals(competition.RouteMan))
        {
            resultsMan.AddResult(athlete, punches);
        }
        else
        {
            resultsWoman.AddResult(athlete, punches);
        }

        if (PlayerProfile.Id.Equals(athlete.Id))
        {
            GameOver();
        }
    }

    private void InitAthletes()
    {
        athletes = new List<Athlete>();
        Athlete player = new Athlete(PlayerProfile.Id, PlayerProfile.Name, PlayerProfile.Surname, PlayerProfile.Gender, PlayerProfile.Team);
        athletes.Add(player);
        PlayerProfile.Athlete = player;
    }

    private void CreateCompetition()
    {
        competition = gameObject.AddComponent<Competition.CompetitionCreator>().Create(DataHolder.CompetitionEvent);
    }

    private Dictionary<Athlete, DateTime> CreateStartList()
    {
        if (DataHolder.CompetitionEvent.CompetitionTypeByTime == CompetitionTypeByTime.Day)
        { startTime = new DateTime(1, 1, 1, 10, 0, 0); }
        else { startTime = new DateTime(1, 1, 1, 2, 0, 0); }

        Dictionary<Athlete, DateTime> startList = new Dictionary<Athlete, DateTime>
        {
            { athletes.Find(x => x.Id == 0), startTime }
        };
        startList = startList.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        return startList;
    }

    private void DrawRouteOnMap()
    {
        Route route;
        if (PlayerProfile.Gender == Gender.male)
        { route = competition.RouteMan; }
        else { route = competition.RouteWoman; }
        mapController.Draw(competition.StartsPlace.Position, route.RouteSegments, competition.ScaleMap);
    }

    private void InstantiatePlayer()
    {
        GameObject player = GameObject.Find(Constants.PLAYER);
        player.transform.position = competition.StartsPlace.PlayerStartPosition;
        player.transform.rotation = Quaternion.Euler(competition.StartsPlace.Rotation);

        Puncher puncher = player.GetComponentInChildren<Puncher>();
        puncher.Athlete = athletes.Find(x => x.Id == 0);
        puncher.Route = PlayerProfile.Gender == Gender.male ? competition.RouteMan : competition.RouteWoman;
    }

    private void StartClock()
    {
        Clock clock = GetComponent<Clock>();
        clock.ClockTime = startTime;
    }

    private void GameOver()
    {
        DataHolder.ResultsMan = resultsMan;
        DataHolder.ResultsWoman = resultsWoman;
        SceneManager.LoadScene("Results");
    }
}