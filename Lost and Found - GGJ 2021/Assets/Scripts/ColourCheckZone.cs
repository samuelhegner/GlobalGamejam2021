using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCheckZone : Zone
{
    public override void onZoneEntered(GameObject gameObject)
    {
        print("Show Colour");
        BeanPersonColourSwitch colourSwitch = gameObject.GetComponent<BeanPersonColourSwitch>();
        colourSwitch.showColour();
    }

    public override void onZoneLeft(GameObject beanPerson)
    {
        print("Hide Colour");
        BeanPersonColourSwitch colourSwitch = beanPerson.GetComponent<BeanPersonColourSwitch>();
        colourSwitch.hideColour();
    }

}
