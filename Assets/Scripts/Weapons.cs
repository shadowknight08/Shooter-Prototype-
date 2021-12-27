using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Weapons : MonoBehaviour
{
    protected int damage;
    protected int range = 40;
    protected float firerate;
    protected int ammocount = 100;
    protected bool canfire=true;
    [SerializeField]
    protected Joystick joystick;
    [SerializeField]
    protected GameObject hitprefab;
    [SerializeField]
    protected ParticleSystem muzzleflash;

    //private ParticleSystem mussleflash;

   public virtual void Update()
    {
        if(joystick.Horizontal >0.8f || joystick.Horizontal< -0.8f || joystick.Vertical > 0.8f || joystick.Vertical < -0.8f )
        {
            if(canfire)
            Shoot();
        }

        if (ammocount < 1)
        {
            canfire = false;
            Reload();
        }
    }

    public virtual void Shoot()
    {
        muzzleflash.Play();
        canfire = false;
    }
    
   public virtual IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        canfire = true;
    }

    public virtual void Reload()
    {
        ammocount = 100;
        //reload Animation Play

        canfire = true;
    }
}
