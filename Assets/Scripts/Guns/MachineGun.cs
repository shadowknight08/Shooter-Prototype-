using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapons 
{
    public override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward + new Vector3(0, -.1f, 0), out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Damage(500);
            }

            GameObject impact = Instantiate(hitprefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }

        StartCoroutine(Fire());
    }

}
