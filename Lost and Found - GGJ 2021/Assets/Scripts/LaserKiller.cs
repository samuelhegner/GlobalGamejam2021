using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserKiller : ObstacleKill
{
    [SerializeField] private GameObject laserStart, laserEnd;
    [SerializeField] private LayerMask beanPersonMask;

    float rayLength;

    Ray ray;
    void Start()
    {
        Vector3 directionToLaserEnd = laserEnd.transform.position - laserStart.transform.position;
        rayLength = directionToLaserEnd.magnitude;

        ray = new Ray(laserStart.transform.position, directionToLaserEnd);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength, beanPersonMask)) 
        {
            trapTriggered(hit.transform.GetComponent<BeanPersonHealth>());
        }
    }
}
