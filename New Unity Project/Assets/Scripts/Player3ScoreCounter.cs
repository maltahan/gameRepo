using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3ScoreCounter : MonoBehaviour {

    // Use this for initialization
    public static int ScoreValue = 50;
    Text Score;
    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score " + ScoreValue;
    }
}
