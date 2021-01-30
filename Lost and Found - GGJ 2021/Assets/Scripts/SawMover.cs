using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMover : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private GameObject blade;

    [SerializeField] private float sawBladeSpeed = 2f;

    [SerializeField] private LineRenderer track;

    void Start()
    {
        if (waypoints.Length > 1) 
        {
            setUpSawBladeTrack();
            StartCoroutine(moveSawBlade());
        }
    }

    void Update()
    {

    }

    void setUpSawBladeTrack()
    {
        track.positionCount = waypoints.Length;
        for (int i = 0; i < waypoints.Length; i++)
        {
            track.SetPosition(i, waypoints[i].position);
        }
    }

    IEnumerator moveSawBlade()
    {
        int trackIndex = 0;

        while (true)
        {
            if (Vector3.Distance(blade.transform.position, waypoints[trackIndex].position) > 0.1f)
            {
                blade.transform.position = Vector3.MoveTowards(blade.transform.position, waypoints[trackIndex].position, sawBladeSpeed * Time.deltaTime);
            }
            else
            {
                trackIndex++;
                
                if (trackIndex >= waypoints.Length)
                    trackIndex = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
