using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonAnimation : MonoBehaviour
{

    Animator anim;

    public ParticleSystem heartSystem;
    public ParticleSystem deathSystem;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DeathAnimation() 
    {
        anim.SetTrigger("Death");
        deathSystem.Play();
    }

    public void HoverAnimation(bool value) 
    {
        anim.SetBool("Hover", value);
    }

    public void SetHeartAttraction(bool value) 
    {
        if (value)
        {
            heartSystem.Play();
        }
        else 
        {
            heartSystem.Stop();
        }
    }
}

