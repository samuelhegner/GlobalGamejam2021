using System.Collections;
using UnityEngine;


public interface IPickup
{
    public void onPickUp();
    public void whilePickedUp(Transform hoverPoint);
    public void onRelease();
}
