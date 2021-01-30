using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTractorBeam : MonoBehaviour
{
    bool tractorBeamOn;

    ObjectToPickUp objectToCarry;

    [SerializeField] private Transform hoverTransform;
    [SerializeField] private Transform beamLight;
    [SerializeField] private Transform beamTarget;


    [SerializeField] private float beamRadius;
    [SerializeField] private float beamRayLength;

    [SerializeField] private LayerMask beamMask;


    Ray beamRay;

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

    private void releaseObject()
    {
        objectToCarry.onRelease();
        objectToCarry = null;
    }

    private void carryObject()
    {
        objectToCarry.whilePickedUp(hoverTransform);
    }

    private void pickUpObject()
    {
        RaycastHit hit;
        beamRay = new Ray(transform.position, Vector3.down);
        if (Physics.SphereCast(beamRay, beamRadius, out hit, beamRayLength, beamMask))
        {
            if (hit.transform.CompareTag("Collected")) 
            {
                objectToCarry = hit.transform.GetComponent<ObjectToPickUp>();
                objectToCarry.onPickUp();
            }
            
        }
        
    }

    void enableOrDisableVisuals (bool value) 
    {
        beamLight.gameObject.SetActive(value);
        beamTarget.gameObject.SetActive(value);
    }

    public void setBeamState(bool value) 
    {
        tractorBeamOn = value;
        enableOrDisableVisuals(tractorBeamOn);
    }
}
