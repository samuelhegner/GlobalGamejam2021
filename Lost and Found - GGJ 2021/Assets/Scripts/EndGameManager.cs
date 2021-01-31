using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EndGameManager : MonoBehaviour
{
    private static EndGameManager instance;

    [SerializeField] int numberOfBeansLeft;

    [SerializeField] int scoreNeededToWin;

    public UnityEvent gameCompleteSuccess;
    public UnityEvent gameCompleteFail;


    private void Awake()
    {
        instance = this;
    }

    public static void addToNumberOfBeans() 
    {
        instance.numberOfBeansLeft++;
    }

    public static void subtractFromNumberOfBeans()
    {
        instance.numberOfBeansLeft--;
    }

    private void Update()
    {
        if (Time.frameCount > 120 && numberOfBeansLeft <= 0) 
        {
            if (scoreNeededToWin <= ScoreManager.instance.score)
            {
                gameCompleteSuccess?.Invoke();
            }
            else 
            {
                gameCompleteFail?.Invoke();
            }
            
        }
    }
}
