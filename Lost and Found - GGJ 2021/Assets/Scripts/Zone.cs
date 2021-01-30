using System.Collections;
using UnityEngine;


public abstract class Zone : MonoBehaviour, IZone
{
    [SerializeField] protected LayerMask beanPersonLayer;


    public virtual void onZoneEntered(GameObject beanPerson) { }

    public virtual void onZoneLeft(GameObject beanPerson) { }

    private void OnTriggerEnter(Collider other)
    {
        if (beanPersonLayer == (beanPersonLayer | (1 << other.gameObject.layer)))
        {
            onZoneEntered(other.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (beanPersonLayer == (beanPersonLayer | (1 << other.gameObject.layer)))
        {
            onZoneLeft(other.transform.parent.gameObject);
        }
    }
}
