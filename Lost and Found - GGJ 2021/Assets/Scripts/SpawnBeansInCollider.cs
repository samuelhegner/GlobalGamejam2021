using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBeansInCollider : MonoBehaviour
{
    [SerializeField] private int numberOfBeansToSpawn;
    [SerializeField] private GameObject beanPrefab;



    void Start()
    {
        spawnBeans();
    }

    private void spawnBeans()
    {
        for (int i = 0; i < numberOfBeansToSpawn; i++)
        {
            /*GameObject newBean = Instantiate(beanPrefab, transform.position, Quaternion.identity);
            var spawnBox = transform.localScale;
            var position = Vector3(Random.value * spawnBox.x, Random.value * spawnBox.x, Random.value * spawnBox.x);
            position = transform.TransformPoint(position - spawnBox / 2);
            var obj = Instantiate(spawnObject, postition, transform.rotation);*/
        }
    }

    void Update()
    {
        
    }
}
