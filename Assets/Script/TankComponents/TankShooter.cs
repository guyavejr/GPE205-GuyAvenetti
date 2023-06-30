using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;
    public override void Start()
    {

    }
    public override void Update()
    {

    }
    public override void Shoot(GameObject BulletPrefab, float fireForce, float damage, float lifespan, float fireRate)
    {
        //instantiate projectile
        GameObject newBullet = Instantiate(BulletPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        //damage on hit component
        DamageOnHit doh = newBullet.GetComponent<DamageOnHit>() as DamageOnHit;
        if (doh != null)
        {
            //damgeDone from damage on hit component passed in 
            doh.damageDone = damage;
            doh.owner = GetComponent<Pawn>();
        }

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        Destroy(newBullet, lifespan);
    }

}
