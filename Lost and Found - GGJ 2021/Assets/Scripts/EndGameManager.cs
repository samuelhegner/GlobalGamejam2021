using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGameManager : MonoBehaviour
{
    private static EndGameManager instance;

    [SerializeField] int numberOfBeansLeft;

    static Action gameComplete;


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
            gameComplete?.Invoke();
        }
    }
}
