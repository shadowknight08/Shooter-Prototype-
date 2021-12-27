using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapons 
{
    public override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log("function called");
            Debug.Log(hit.collider.name);
            GameObject impact = Instantiate(hitprefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }

        StartCoroutine(Fire());
    }

}
