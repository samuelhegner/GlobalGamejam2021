using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonMovement : MonoBehaviour
{
    private Rigidbody beanPersonRigidBody;

    Queue<Vector3> placesToReach = new Queue<Vector3>();

    private Vector3 movementDirection;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private float movementSpeed = 10f;

    [SerializeField] bool grounded = true;

    private void Awake()
    {
        setStartingPlace();
        beanPersonRigidBody = GetComponent<Rigidbody>();
    }



    private void moveBeanPerson()
    {
        Vector3 movement = movementDirection * movementSpeed * Time.deltaTime;
        beanPersonRigidBody.MovePosition(transform.position + movement);
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            if (placesToReach.Count > 0)
            {
                walkToFirstPlaceToReach();
            }
            else
            {
                wanderRandomly();
            }
        }
    }

    private void Update()
    {
        grounded = isGrounded();
    }

    private void wanderRandomly()
    {
        movementDirection = Vector3.right;
        moveBeanPerson();
    }

    private void walkToFirstPlaceToReach()
    {
        Vector3 placePosition = placesToReach.Peek();
        if (Vector3.Distance(transform.position, placePosition) > 0.1f)
        {
            movementDirection = getDirectionToPlace(placePosition);
            moveBeanPerson();
        }
        else
        {
            placesToReach.Dequeue();
        }
    }

    private Vector3 getDirectionToPlace(Vector3 position)
    {
        return Vector3.Normalize(position - transform.position);
    }

    private void setStartingPlace()
    {
        placesToReach.Enqueue(Vector3.zero);
    }

    bool isGrounded() 
    {
        Vector3 rayStartPosition = transform.position;
        rayStartPosition.y += 0.1f;
        Ray rayDown = new Ray(rayStartPosition, Vector3.down);

        return Physics.Raycast(rayDown, 0.2f, groundMask);
    }
}
