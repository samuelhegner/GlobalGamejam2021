using System;
using System.Collections;
using UnityEngine;


public class BeanPersonType : MonoBehaviour
{
    [SerializeField] private BeanType type;

    public BeanType Type { get => type; set => type = value; }

    void Start()
    {
        setRandomType();
    }

    void Update()
    {

    }

    private void setRandomType()
    {
        Array values = Enum.GetValues(typeof(BeanType));
        System.Random random = new System.Random();
        type = (BeanType)values.GetValue(random.Next(values.Length));
        print(type);
    }

    
}

public enum BeanType 
{
    green,
    red,
}
