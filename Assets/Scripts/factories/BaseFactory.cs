using UnityEngine;
using System.Collections;

abstract public class BaseFactory {

    public GameObject create(GameObject prefab){
        prefab.SetActive(false);
        var concretePrefab = Object.Instantiate(prefab);
        bootStrap(concretePrefab);
        concretePrefab.gameObject.SetActive(true);
        return concretePrefab;
    }

    public GameObject create(GameObject prefab, Vector3 position){
        prefab.SetActive(false);
        var concretePrefab = Object.Instantiate(prefab, position, new Quaternion());
        bootStrap(concretePrefab);
        concretePrefab.gameObject.SetActive(true);
        return concretePrefab;
    }

    public GameObject create(GameObject prefab, Vector3 position, Quaternion rotation){
        prefab.SetActive(false);
        var concretePrefab = Object.Instantiate(prefab,position,rotation);
        bootStrap(concretePrefab);
        concretePrefab.gameObject.SetActive(true);
        return concretePrefab;
    }

    abstract protected void bootStrap(GameObject instaniatedObject);


}