using System;
using System.Collections;
using UnityEngine;


public class BeanPersonColourSwitch : MonoBehaviour
{
    [SerializeField] private Material hidden, green, red;
    [SerializeField] private Renderer rend;

    private BeanPersonType beanPersonType;


    Material reveal;


    private void Start()
    {
        beanPersonType = GetComponent<BeanPersonType>();
        setupMaterials();
    }

    private void setupMaterials()
    {
        if (beanPersonType.Type == BeanType.green)
        {
            reveal = green;
        }
        else 
        {
            reveal = red;
        }
        rend.material = hidden;
    }

    public void showColour() 
    {
        rend.material = reveal;
    }
    public void hideColour() 
    {
        rend.material = hidden;
    }
}