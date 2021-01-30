using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ObjectToPickUp : MonoBehaviour, IPickup
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float hoverSpeed = 5f;
    [SerializeField] private float followPointSpeed = 20f;




    public void onPickUp()
    {
        objectRigidbody.isKinematic = true;
    }

    public void onRelease()
    {
        objectRigidbody.isKinematic = false;
    }

    public void whilePickedUp(Transform hoverPoint)
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, hoverPoint.position.x, followPointSpeed * Time.deltaTime)
                                       , Mathf.Lerp(transform.position.y, hoverPoint.position.y, hoverSpeed * Time.deltaTime)
                                       , Mathf.Lerp(transform.position.z, hoverPoint.position.z, followPointSpeed * Time.deltaTime));
    }

    void Awake() 
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
}