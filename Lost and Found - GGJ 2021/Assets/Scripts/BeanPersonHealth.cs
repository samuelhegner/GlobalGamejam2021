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
        GetComponent<BeanPersonAnimation>().DeathAnimation();

        switch (type)
        {
            case DeathType.laser:
                {
                    print("Lasered to Death");
                    EndGameManager.subtractFromNumberOfBeans();
                    break;
                }
            case DeathType.saw:
                {
                    print("Sawed to Death");
                    EndGameManager.subtractFromNumberOfBeans();
                    break;
                }
            case DeathType.wrongZone:
                {
                    print("Place the wrong zone");
                    EndGameManager.subtractFromNumberOfBeans();
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
