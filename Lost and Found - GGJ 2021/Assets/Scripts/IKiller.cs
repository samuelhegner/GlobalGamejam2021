using System.Collections;
using UnityEngine;


public interface IKiller
{
    void killObject(BeanPersonHealth beanPerson);

    void trapTriggered(BeanPersonHealth beanPersonWhoTriggered);
}
