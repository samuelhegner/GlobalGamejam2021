using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerp : MonoBehaviour
{

    private float CurrentCutoffValue;
    Renderer rend;
        
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetColour(Color col, float intensity)
    {
        CurrentCutoffValue = 1;
        StopAllCoroutines();
        StartCoroutine(ColourFade(col, intensity));
    }

    IEnumerator ColourFade(Color col, float intensity)
    {
        rend.material.SetColor("Color_0f1c94e6d6b44082988fe568abfb0bf0", col * intensity);

        while (CurrentCutoffValue > -1)
        {
            CurrentCutoffValue -= Time.deltaTime;
            rend.material.SetFloat("Vector1_8cfcfe239a2b49d489dc88c27b3929dd", CurrentCutoffValue);
            
            yield return null;
        }

        
    }
}
