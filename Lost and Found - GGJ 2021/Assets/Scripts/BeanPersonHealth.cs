using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BeanPersonHealth : MonoBehaviour
{
    [SerializeField] private GameObject [] deathParticleSystemPrefabs;

    [SerializeField] private float timeBeforeDeletion = 1f;

    PlayerTractorBeam tractorBeam;

    private void Start()
    {
        tractorBeam = FindObjectOfType<PlayerTractorBeam>();
    }

    public void kill(DeathType type)
    {
        onDeath(type);
        Invoke("onDeathAfterTimer", timeBeforeDeletion);
    }
    void onDeath(DeathType type)
    {
        Assert.IsNotNull(tractorBeam);

        if (tractorBeam.objectToCarry != null && tractorBeam.objectToCarry.gameObject == gameObject) 
        {
            tractorBeam.releaseObject();
        }

        switch (type)
        {
            case DeathType.laser:
                {
                    print("Lasered to Death");
                    EndGameManager.subtractFromNumberOfBeans();
                    GetComponent<BeanPersonAnimation>().DeathAnimation();
                    GetComponent<BeanPersonSounds>().playDeath();

                    break;
                }
            case DeathType.saw:
                {
                    print("Sawed to Death");
                    EndGameManager.subtractFromNumberOfBeans();
                    GetComponent<BeanPersonAnimation>().DeathAnimation();
                    GetComponent<BeanPersonSounds>().playDeath();
                    break;
                }
            case DeathType.wrongZone:
                {
                    print("Place the wrong zone");
                    EndGameManager.subtractFromNumberOfBeans();
                    GetComponent<BeanPersonAnimation>().DeathAnimation();
                    GetComponent<BeanPersonSounds>().playDeath();
                    break;
                }
            case DeathType.killedOff: 
                {
                    print("Killed off after collection");
                    EndGameManager.subtractFromNumberOfBeans();
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
