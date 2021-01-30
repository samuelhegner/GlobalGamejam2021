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
        
        type = (BeanType)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        print(type);
    }

    
}

public enum BeanType 
{
    green,
    red,
}
