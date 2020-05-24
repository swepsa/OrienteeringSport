using UnityEngine;
using System.Collections.Generic;

// use with sportsmen, have attached to object with collider. Not trigger 
public class Puncher : MonoBehaviour
{
    private readonly List<Punch> punches = new List<Punch>();
    private GameController gameController;
    private Clock clock;
    private string previosControlPoint;

    public Athlete Athlete { get; set; }
    public Route Route { get; set; }

    //const int playSoundInterval = 3;


    void Awake()
    {
        GameObject gameControlerObj = GameObject.Find(Constants.GAME_CONTROLLER);
        clock = gameControlerObj.GetComponent<Clock>();
        gameController = gameControlerObj.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(Constants.CONTROL_POINT_TAG))
        {
            return;
        }

        string controlPoint = collider.name.Substring(2);
        if (!controlPoint.Equals(previosControlPoint))
        {
            Punch punch = new Punch(controlPoint, clock.ClockTime);
            punches.Add(punch);
            previosControlPoint = controlPoint;
            Debug.Log(punch);
            collider.GetComponent<AudioSource>().Play();
        }

        if (controlPoint.Equals(Route.GetLastControlPoint().GetNumber()))
        {
            gameController.AddResult(Athlete, Route, punches);
        }
    }
}