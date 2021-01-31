using System.Collections;
using UnityEngine;


public class CollectionZone : Zone
{

    [SerializeField] private BeanType zoneType;
    [SerializeField] private DeathType deathType;

    [SerializeField] private Transform exitPoint;

    public override void onZoneEntered(GameObject gameObject)
    {
        if (zoneType == gameObject.GetComponent<BeanPersonType>().Type)
        {
            gameObject.tag = "Collected";
            EndGameManager.subtractFromNumberOfBeans();
            gameObject.GetComponent<BeanPersonMovement>().addPlaceToReach(exitPoint.position, false);
            ScoreManager.addToScore();
            BeanPersonHealth health;
            gameObject.GetComponent<BeanPersonHealth>().kill(DeathType.killedOff);
        }
        else
        {
            gameObject.GetComponent<BeanPersonHealth>().kill(deathType);
        }
    }

    public override void onZoneLeft(GameObject beanPerson)
    {

    }
}
