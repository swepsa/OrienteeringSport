using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CareerController : MonoBehaviour
{
    public Queue<CompetitionEvent> Calenadar { get; } = new Queue<CompetitionEvent>();

    private void Awake()
    {
        InitPlayer();
        if (Calenadar.Count == 0) { GenerateCalendar(); }
    }

    public void StartPressed()
    {
        LoadSceneCompetition();
    }

    private void InitPlayer()
    {
        PlayerProfile.Id = 0;
        PlayerProfile.Gender = Gender.male;
        PlayerProfile.Name = "Yuri";
        PlayerProfile.Surname = "Ulyanov";
        PlayerProfile.Team = "Tri-O";
    }

    private void GenerateCalendar()
    {
        CompetitionEvent competitionEvent = new CompetitionEvent("Test competition", Constants.TERRAIN_TEST, new CompetitionTypeByLenght.Sprint(), CompetitionTypeByTime.Day,
            CompetitionTypeByStart.Individual, CompetitionTypeByVisitingOrder.CrossCountry, CompetitionTypeByNumberOfCompetitors.Individual, CompetitionType.Individual);
        Calenadar.Enqueue(competitionEvent);
    }

    private void LoadSceneCompetition()
    {
        DataHolder.CompetitionEvent = Calenadar.Dequeue();
        //TODO save calendar
        SceneManager.LoadScene("Competition");
    }
}
