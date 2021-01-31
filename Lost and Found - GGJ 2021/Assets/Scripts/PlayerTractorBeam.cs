using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTractorBeam : MonoBehaviour
{
    public bool tractorBeamOn;

    public ObjectToPickUp objectToCarry;

    [SerializeField] private Transform hoverTransform;
    [SerializeField] private Transform beamLight;
    [SerializeField] private Transform beamTarget;
    [SerializeField] private Transform beamLaser;


    [SerializeField] private float beamRadius;
    [SerializeField] private float beamRayLength;

    [SerializeField] private LayerMask beamMask;


    Ray beamRay;

    [SerializeField] private Vector3 beamVector = new Vector3(0, 0, 9);

    [SerializeField] private LineRenderer lr;

    void Start()
    {

    }

    void LateUpdate()
    {
        if (tractorBeamOn)
        {
            if (objectToCarry == null)
            {
                pickUpObject();
            }
            else
            {
                carryObject();
            }
        }
        else
        {
            if (objectToCarry != null)
            {
                releaseObject();
            }
        }
    }

    public void releaseObject()
    {
        objectToCarry.onRelease();
        objectToCarry = null;
        lr.useWorldSpace = false;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, beamVector);
    }

    private void carryObject()
    {
        objectToCarry.whilePickedUp(hoverTransform);
        lr.useWorldSpace = true;
        lr.SetPosition(0, beamLaser.transform.position);
        lr.SetPosition(1, objectToCarry.transform.position);
    }

    private void pickUpObject()
    {
        RaycastHit hit;
        beamRay = new Ray(transform.position, Vector3.down);
        if (Physics.SphereCast(beamRay, beamRadius, out hit, beamRayLength, beamMask))
        {
            if (!hit.transform.CompareTag("Collected")) 
            {
                objectToCarry = hit.transform.GetComponent<ObjectToPickUp>();
                objectToCarry.GetComponent<BeanPersonMovement>().clearPlacesToReach();
                objectToCarry.onPickUp();
            }
        }
        
    }

    void enableOrDisableVisuals(bool value)
    {
        beamLight.gameObject.SetActive(value);
        beamTarget.gameObject.SetActive(value);
        beamLaser.gameObject.SetActive(value);
    }

    public void setBeamState() 
    {
        tractorBeamOn = !tractorBeamOn;
        enableOrDisableVisuals(tractorBeamOn);
    }
}


