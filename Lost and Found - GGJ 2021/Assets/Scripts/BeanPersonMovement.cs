using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPersonMovement : MonoBehaviour
{
    private Rigidbody beanPersonRigidBody;

    Queue<Vector3> placesToReach = new Queue<Vector3>();

    [Header("Movement Settings")]
    [SerializeField] private float startMovementSpeed = 10f;
     private float currentMovementSpeed = 10f;

    [SerializeField] float maxRandomTurnAngle = 10f;
    [SerializeField] float turningSpeed = 10f;
    [SerializeField] float wallCheckDistance = 1f;
    [SerializeField] float timeBetweenWallChecks = 1f;
    [SerializeField] [Range(0, 100)] float percentageSpeedLostWhenAttracted = 50;




    [Header("Movement Layer Masks")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;

    bool attracted = false;

    bool grounded = true;


    private Vector3 movementDirection;

    private Vector3 randomDirection;

    float randomStartNoiseSample;
    private float wallCheckTimer;

    private void Awake()
    {
        addPlaceToReach(Vector3.zero, false);
        beanPersonRigidBody = GetComponent<Rigidbody>();

        randomStartNoiseSample = Random.Range(-100, 100);

        Vector2 randomStartDirection = Random.insideUnitCircle;
        randomDirection = new Vector3(randomStartDirection.x, 0, randomStartDirection.y);
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

            rotateInMovementDirection();
        }


    }

    private void Update()
    {
        grounded = isGrounded();
        if (wallCheckTimer > 0) 
        {
            wallCheckTimer -= Time.deltaTime;
        }
    }

    private void rotateInMovementDirection()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation
                                           , Quaternion.LookRotation(movementDirection, Vector3.up)
                                           , turningSpeed * Time.deltaTime);
    }



    private void wanderRandomly()
    {
        float angleToAdd = FloatExtensions.Map(Mathf.PerlinNoise(randomStartNoiseSample, 0), 0, 1, -1, 1) * maxRandomTurnAngle;

        angleToAdd = addToAngle(angleToAdd);

        randomDirection = Quaternion.AngleAxis(angleToAdd, Vector3.up) * randomDirection;

        movementDirection = randomDirection;
        moveBeanPerson();
        randomStartNoiseSample += Time.deltaTime;
    }

    private float addToAngle(float angleToAddTo)
    {
        if (wallCheckTimer > 0)
            return angleToAddTo;

        float additionalAngle = 0;


        Vector3 rayStartingPosition = transform.position;
        rayStartingPosition.y += 0.5f;
        Ray straightForwardRay = new Ray(rayStartingPosition, transform.forward);

        Debug.DrawRay(straightForwardRay.origin, straightForwardRay.direction * wallCheckDistance);

        if (Physics.Raycast(straightForwardRay, wallCheckDistance, wallMask))
        {
            additionalAngle += 180;
            wallCheckTimer += timeBetweenWallChecks;
        }
        
        return angleToAddTo + additionalAngle;
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

    public void addPlaceToReach(Vector3 newPlace, bool attracted) 
    {
        placesToReach.Enqueue(newPlace);
        setAttraction(attracted);
    }

    private void setAttraction(bool attracted)
    {
        attracted = true;
        if (attracted)
        {
            currentMovementSpeed = startMovementSpeed *  (percentageSpeedLostWhenAttracted / 100f);
        }
        else 
        {
            currentMovementSpeed = startMovementSpeed;
        }
    }

    public void clearPlacesToReach() 
    {
        placesToReach.Clear();
        setAttraction(false);
    }

    private void moveBeanPerson()
    {
        Vector3 movement = movementDirection * currentMovementSpeed * Time.deltaTime;
        beanPersonRigidBody.MovePosition(transform.position + movement);
    }

    bool isGrounded()
    {
        Vector3 rayStartPosition = transform.position;
        rayStartPosition.y += 0.1f;
        Ray rayDown = new Ray(rayStartPosition, Vector3.down);

        return Physics.Raycast(rayDown, 0.2f, groundMask);
    }
}
