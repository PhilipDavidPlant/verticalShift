using UnityEngine;
using System.Collections;

public class CameraFactory : BaseFactory{

    int totalColumns, totalRows, currentColumn, currentRow;
    GameObject playerRef;

    public CameraFactory(int totalColumns, int totalRows, int currentColumn, int currentRow, GameObject playerRef){
        this.totalColumns = totalColumns;
        this.totalRows = totalRows;
        this.currentColumn = currentColumn;
        this.currentRow = currentRow;
        this.playerRef = playerRef;
    }

    protected override void bootStrap(GameObject instaniatedObject){
        instaniatedObject.GetComponent<Camera>().rect = new Rect((1f/this.totalColumns)*currentColumn, 1-((1f/totalRows)*currentRow), 1f/totalColumns, 1f/totalRows);
        instaniatedObject.tag = "Camera";

        //instaniatedObject.transform.position = playerRef.transform.position + new Vector3(0,0,-1f);
        instaniatedObject.GetComponent<CameraScript>().ship = playerRef;
        instaniatedObject.GetComponent<CameraScript>().enabled = true;
    }

}