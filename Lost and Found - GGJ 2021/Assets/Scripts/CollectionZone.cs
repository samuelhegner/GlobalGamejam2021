using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollectionZone : Zone
    {

        [SerializeField] private BeanType zoneType;
        [SerializeField] private DeathType deathType;

        public override void onZoneEntered(GameObject gameObject)
        {
            if (zoneType == gameObject.GetComponent<BeanPersonType>().Type)
            {
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