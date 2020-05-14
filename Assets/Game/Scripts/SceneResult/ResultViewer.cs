using System;
using UnityEngine;
using UnityEngine.UI;
using static CheckCard;

public class ResultViewer : MonoBehaviour
{
    public GameObject checkCardFooterRow;
    public GameObject checkCardTableRow;
    public Transform verticalLayoutGroup;

    private void Start()
    {
        Results results = PlayerProfile.Gender == Gender.male ? DataHolder.ResultsMan : DataHolder.ResultsWoman;
        PrintResults(DataHolder.CompetitionEvent, results);
    }

    public void PrintResults(CompetitionEvent cEvent, Results results)
    {
        results.CheckCards.TryGetValue(PlayerProfile.Athlete, out CheckCard checkCard);

        //Header
        Transform headerRow = verticalLayoutGroup.Find("Competition");
        headerRow.GetComponent<Text>().text = cEvent.Name + ", " + cEvent.CompetitionTypeByLenght;

        headerRow = verticalLayoutGroup.Find("Athlet");
        headerRow.GetComponent<Text>().text = checkCard.Athlete.GetFullName();

        headerRow = verticalLayoutGroup.Find("Team");
        headerRow.GetComponent<Text>().text = checkCard.Athlete.Team;

        headerRow = verticalLayoutGroup.Find("Distance");
        headerRow.GetComponent<Text>().text = "Distance " + string.Format("{0:f0}", checkCard.LenghtRoute) + "m, " + checkCard.FlagsCount + " flags";


        headerRow = verticalLayoutGroup.Find("Start");
        headerRow.GetComponent<Text>().text = "Start: " + checkCard.StartTime.ToString("HH:mm:ss");

        //Main rows
        for (int i = 0; i < checkCard.MainRows.Count; i++)
        {
            CheckCardMainRow row = checkCard.MainRows[i];

            Transform rowInstance = (Instantiate(checkCardTableRow) as GameObject).transform;
            rowInstance.SetParent(verticalLayoutGroup);

            string speed = row.speed == 0 ? " - " : (string.Format("{0:f2}", row.speed) + "/км");
            rowInstance.Find("Column1").GetComponent<Text>().text = (i + 1).ToString();
            rowInstance.Find("Column2").GetComponent<Text>().text = "(" + row.number + ")";
            rowInstance.Find("Column3").GetComponent<Text>().text = RoundTimeStamp(row.timeTotal);
            rowInstance.Find("Column4").GetComponent<Text>().text = RoundTimeStamp(row.timeSegment);
            rowInstance.Find("Column5").GetComponent<Text>().text = speed;
        }

        //Additional rows
        if (checkCard.AdditionalRows.Count > 0)
        {
            Transform rowInstance = (Instantiate(checkCardTableRow) as GameObject).transform;
            rowInstance.SetParent(verticalLayoutGroup);
        }

        for (int i = 0; i < checkCard.AdditionalRows.Count; i++)
        {
            CheckCardAdditionalRow row = checkCard.AdditionalRows[i];
            Transform rowInstance = (Instantiate(checkCardTableRow) as GameObject).transform;
            rowInstance.SetParent(verticalLayoutGroup);
            rowInstance.Find("Column2").GetComponent<Text>().text = "*" + row.number;
            rowInstance.Find("Column3").GetComponent<Text>().text = RoundTimeStamp(row.timeTotal);
        }

        //Footer
        GameObject footerRow = Instantiate(checkCardFooterRow) as GameObject;
        footerRow.transform.SetParent(verticalLayoutGroup);
        footerRow.GetComponent<Text>().text = "Result: " + (checkCard.Correct ? "Ок" : "Foul");

        footerRow = Instantiate(checkCardFooterRow) as GameObject;
        footerRow.transform.SetParent(verticalLayoutGroup);
        footerRow.GetComponent<Text>().text = "Total time: " + RoundTimeStamp(checkCard.FinishTime);

        if (checkCard.Correct)
        {
            footerRow = Instantiate(checkCardFooterRow) as GameObject;
            footerRow.transform.SetParent(verticalLayoutGroup);
            footerRow.GetComponent<Text>().text = "Average speed: " + string.Format("{0:f2}", checkCard.AverageSpeed) + " / км";
        }
    }

    private string RoundTimeStamp(TimeSpan time)
    {
        if (time.Milliseconds == 0)
        {
            return "- - - -";
        }

        string format;
        if (time.TotalHours > 0)
        {
            format = @"mm\:ss";
        }
        else
        {
            format = @"hh\:mm\:ss";
        }

        return time.ToString(format);
    }
}