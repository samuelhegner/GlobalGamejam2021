using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBeansInCollider : MonoBehaviour
{
    [SerializeField] private int numberOfBeansToSpawn;
    [SerializeField] private GameObject beanPrefab;

    [SerializeField] private BoxCollider boxCollider;

    [SerializeField] private Transform spawnExit;



    void Start()
    {
        spawnBeans();
    }

    private void spawnBeans()
    {
        for (int i = 0; i < numberOfBeansToSpawn; i++)
        {
            Vector3 localSpawnPoint = RandomPointInBounds(boxCollider.bounds);
            Vector3 worldSpawnPoint = transform.TransformPoint(localSpawnPoint);
            GameObject newBean = Instantiate(beanPrefab, localSpawnPoint, Quaternion.identity);
            newBean.GetComponent<BeanPersonMovement>().addPlaceToReach(spawnExit.position, false);
        }
    }

    void Update()
    {
        
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
