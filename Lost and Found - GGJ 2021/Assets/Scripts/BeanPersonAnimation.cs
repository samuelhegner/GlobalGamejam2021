using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonAnimation : MonoBehaviour
{

    Animator anim;

    public ParticleSystem heartSystem;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DeathAnimation() 
    {
        anim.SetTrigger("Death");
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

