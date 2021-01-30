using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserVisuals : MonoBehaviour
{
    [SerializeField] private GameObject start, end;
    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.SetPosition(0, start.transform.position);
        lineRenderer.SetPosition(1, end.transform.position);
    }
}
