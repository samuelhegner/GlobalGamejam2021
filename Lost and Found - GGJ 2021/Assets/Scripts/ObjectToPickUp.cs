using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ObjectToPickUp : MonoBehaviour, IPickup
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float hoverSpeed = 5f;
    [SerializeField] private float followPointSpeed = 20f;

    private bool isHovering;

    public bool IsHovering { get => isHovering; set => isHovering = value; }

    public void onPickUp()
    {
        objectRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        isHovering = true;
    }

    public void onRelease()
    {
        objectRigidbody.constraints = RigidbodyConstraints.None 
                                    | RigidbodyConstraints.FreezeRotationX 
                                    | RigidbodyConstraints.FreezeRotationY 
                                    | RigidbodyConstraints.FreezeRotationZ;
        isHovering = false;
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