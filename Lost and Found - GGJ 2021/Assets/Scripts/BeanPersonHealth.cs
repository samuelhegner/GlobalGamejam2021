using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonHealth : MonoBehaviour
{
    [SerializeField] private GameObject [] deathParticleSystemPrefabs;

    [SerializeField] private float timeBeforeDeletion = 1f;
    public void kill(DeathType type)
    {
        onDeath(type);
        Invoke("onDeathAfterTimer", timeBeforeDeletion);
    }
    void onDeath(DeathType type)
    {
        switch (type)
        {
            case DeathType.laser:
                {
                    break;
                }
            case DeathType.saw:
                {

                    break;
                }
            case DeathType.wrongZone:
                {
                    break;
                }
            default:
                break;
        }
    }

    void onDeathAfterTimer()
    {
        Destroy(gameObject);
    }
}
