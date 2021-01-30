using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
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
                gameObject.GetComponent<BeanPersonMovement>().addPlaceToReach(exitPoint.position);
                ScoreManager.addToScore();
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
}