using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool tranformUpInstead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!tranformUpInstead)
        transform.RotateAround(transform.position, transform.forward, rotateSpeed * Time.deltaTime);
        else
            transform.RotateAround(transform.position, transform.up, rotateSpeed * Time.deltaTime);
    }
}
