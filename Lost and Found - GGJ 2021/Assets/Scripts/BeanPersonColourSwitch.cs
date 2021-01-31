using System;
using System.Collections;
using UnityEngine;


public class BeanPersonColourSwitch : MonoBehaviour
{
    [SerializeField] private Color hidden, green, red;
    [SerializeField] private Renderer rend;
    [SerializeField] private float colourIntensity = 1.25f;
    [SerializeField] private ColourLerp colLerp;

    private BeanPersonType beanPersonType;


    Color reveal;


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
        rend.material.SetColor("_EmissionColor", hidden * colourIntensity);
    }

    public void showColour() 
    {
        rend.material.SetColor("_EmissionColor", reveal * colourIntensity);
        colLerp.SetColour(hidden, colourIntensity);
    }
    public void hideColour() 
    {
        rend.material.SetColor("_EmissionColor", hidden * colourIntensity);
        colLerp.SetColour(reveal, colourIntensity);
    }
}