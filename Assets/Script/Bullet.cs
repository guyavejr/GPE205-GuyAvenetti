using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPawn : MonoBehaviour
{
    public GameObject prefab;
    private Rigidbody rb;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject newObject = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        Debug.Log(newObject.name);

        //get rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        //if it has one
        if (rb != null)
        {
            //add force
            //rb.AddForce(firepointTransform.forward * fireForece);
        }
    }

}
