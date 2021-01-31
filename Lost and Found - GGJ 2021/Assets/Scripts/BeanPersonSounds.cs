using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonSounds : MonoBehaviour
{
    public AudioSource death;
    public AudioSource collected;

    public void playDeath() 
    {
        death.Play();
    }

    public void playCollected() 
    {
        collected.Play();
    }
}
