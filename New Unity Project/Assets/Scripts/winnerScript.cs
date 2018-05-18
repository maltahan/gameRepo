using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winnerScript : MonoBehaviour {

    // Use this for initialization
    public static List<string> winnerList = new List<string>(2);
    Text Score;
    void Start()
    {
        Score = GetComponent<Text>();
        winnerList.Add("Black");
        winnerList.Add("Red");
        winnerList.Add("Green");
    }

    // Update is called once per frame
    void Update()
    {
        if (winnerList.Count == 1) {
            Score.text = "the winner is " + winnerList[0];
        }
    }
}
