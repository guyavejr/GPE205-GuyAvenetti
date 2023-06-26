using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;

    public void OnTriggerEnter(Collider other)
    {
        //get health from game object that has overlapping collider
        Health otherHealth = other.gameObject.GetComponent<Health>();
        //damage if it has health
        if (otherHealth != null)
        {
            //damage
            otherHealth.TakeDamage(damageDone, owner);
        }

        //destroy ourselves
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
