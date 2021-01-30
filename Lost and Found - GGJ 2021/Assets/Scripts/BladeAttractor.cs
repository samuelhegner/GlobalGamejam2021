using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAttractor : Zone
{
    public override void onZoneEntered(GameObject gameObject)
    {
        if (!gameObject.GetComponent<BeanPersonHover>().IsHovering) 
        {
            BeanPersonMovement movement = gameObject.GetComponent<BeanPersonMovement>();
            movement.addPlaceToReach(transform.position, true);
        }
    }
}
