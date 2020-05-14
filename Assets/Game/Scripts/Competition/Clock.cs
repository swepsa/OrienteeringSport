using System;
using UnityEngine;
using UnityEngine.UI;

// using with GameController
public class Clock : MonoBehaviour
{
    public Text clock;
    public DateTime ClockTime { get; set; }
    private const double MULTIPLIER = 1;

    void Update()
    {
        ClockTime = ClockTime.AddSeconds(MULTIPLIER * Time.deltaTime);
        clock.text = ClockTime.ToString(Constants.FORMAT_TIME);
    }
}