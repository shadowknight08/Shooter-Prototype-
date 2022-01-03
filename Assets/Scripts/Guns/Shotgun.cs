using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapons
{
    public float spread = 5;
    public override void Shoot()
    {

        base.Shoot();
        
       
        for(int i=0;i<4;i++)
        {
            float range = Random.Range(-1,1);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position + new Vector3(0, 0, 1), SpreadDirection(), out hit, base.range))
            {
                
                GameObject impact = Instantiate(base.hitprefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }
           

        }

       
        StartCoroutine(base.Fire());
    }


    Vector3 SpreadDirection()
    {
        Vector3 targetpos = transform.position + new Vector3(0, 0, 1) + transform.forward * range;
        targetpos = new Vector3(
            targetpos.x + Random.Range(-spread, spread),
            targetpos.y,
            targetpos.z);

        Vector3 direction = targetpos - transform.position;
        return direction.normalized;
    }

}
