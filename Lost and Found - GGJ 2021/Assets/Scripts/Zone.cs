using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Zone : MonoBehaviour, IZone
    {
        [SerializeField] protected LayerMask beanPersonLayer;

        
        public virtual void onZoneEntered(GameObject gameObject) {}

        public virtual void onZoneLeft(GameObject beanPerson){}

        private void OnTriggerEnter(Collider other)
        {
            if (beanPersonLayer == (beanPersonLayer | (1 << other.gameObject.layer)))
            {
                print(other.gameObject + " entered the zone");
                onZoneEntered(other.transform.parent.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == beanPersonLayer)
            {
                print(other.gameObject + " left the zone");
                onZoneLeft(other.transform.parent.gameObject);
            }
        }
    }
}