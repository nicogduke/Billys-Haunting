using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static int team1Score;
    public static int team2Score;

    void Start()
    {
        team1Score = 0;
        team2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Screen.width/2, Screen.height - 20, 0);
        GetComponent<TextMeshProUGUI>().text = "Team 1: " + team1Score + "   Team 2: " + team2Score;

        //text.transform.position = new Vector3(Screen.width * cam.rect.x + (Screen.width/4), Screen.height * 0.8f, 0);
    }
}
