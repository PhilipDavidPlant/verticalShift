using UnityEngine;
using System.Collections;

public class ShipFactory : BaseFactory{
    int playerNumber;

    public ShipFactory (int playerNumber){
        this.playerNumber = playerNumber;
    }

    protected override void bootStrap(GameObject instaniatedObject)
    {
        ShipAttributes attributes = instaniatedObject.GetComponent<ShipAttributes>();
        attributes.playerNumber = playerNumber;
    }
}