using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int scorePerBean;

    public Action<int> onScoreChanged;
    private static ScoreManager instance;
    [SerializeField] int score;

    private void Awake()
    {
        instance = this;
    }

    public static void addToScore() 
    {
        instance.score += instance.scorePerBean;
        instance.onScoreChanged?.Invoke(instance.score);
    }

    public static void subtractFromScore()
    {
        instance.score -= instance.scorePerBean;
        instance.onScoreChanged?.Invoke(instance.score);
    }
}
