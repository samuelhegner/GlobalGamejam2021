using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawKiller : ObstacleKill
{ 
    private void OnCollisionEnter(Collision collision)
    {
        BeanPersonHealth beanPersonHealth = collision.transform.GetComponent<BeanPersonHealth>();
        if (beanPersonHealth != null) 
        {
            trapTriggered(beanPersonHealth);
        }
    }
}
