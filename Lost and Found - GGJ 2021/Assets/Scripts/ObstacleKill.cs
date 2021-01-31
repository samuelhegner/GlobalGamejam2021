using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleKill : MonoBehaviour, IKiller
{
    [SerializeField] private DeathType typeOfDeath;
    
    public void killObject(BeanPersonHealth beanPerson)
    {
        beanPerson.tag = "Collected";
        beanPerson.kill(typeOfDeath);
    }

    public virtual void trapTriggered(BeanPersonHealth beanPersonWhoTriggered)
    {
        if(!beanPersonWhoTriggered.CompareTag("Collected"))
            killObject(beanPersonWhoTriggered);
    }
}
