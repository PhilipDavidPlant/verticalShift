using UnityEngine;
using System.Collections;

public class HUDFactory : BaseFactory{

    ShipAttributes shipAttributes;

    public HUDFactory (ShipAttributes shipAttributes){
        this.shipAttributes = shipAttributes;
    }

    protected override void bootStrap(GameObject instaniatedObject)
    {
        instaniatedObject.GetComponent<HUDManager>().shipAttributesReference = shipAttributes;
    }
}