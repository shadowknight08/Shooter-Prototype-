using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble 
{
    int Heath { get; set; }

    void Damage(int damage);
}
