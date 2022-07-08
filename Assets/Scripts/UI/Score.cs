using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   
    [SerializeField] private Text text;
    private static int CurrentScore;


    void Start()
    {
        CurrentScore = 0;
    }

    void Update()
    {
        text.text = "Очки: " + CurrentScore;

    }

    public static void AddScore(int score)
    {
        CurrentScore += score;
    }
}
