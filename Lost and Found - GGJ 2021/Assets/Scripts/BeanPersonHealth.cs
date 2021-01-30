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
                    print("Lasered to Death");
                    ScoreManager.subtractFromScore();
                    break;
                }
            case DeathType.saw:
                {
                    print("Sawed to Death");
                    ScoreManager.subtractFromScore();
                    break;
                }
            case DeathType.wrongZone:
                {
                    print("Place the wrong zone");
                    ScoreManager.subtractFromScore();
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
