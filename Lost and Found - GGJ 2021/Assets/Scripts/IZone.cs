using System.Collections;
using UnityEngine;

public interface IZone
{
    void onZoneEntered(GameObject beanPerson);
    void onZoneLeft(GameObject beanPerson);
}
