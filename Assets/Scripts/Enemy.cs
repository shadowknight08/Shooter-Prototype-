using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IDamageble
{

    public int health = 1000;
    public int speed = 2;

    public NavMeshAgent agent;

    private Player player;

    public int Heath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Damage(int damage)
    {
        Debug.Log("bullet hit ");
        health -= damage;
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
        agent.speed = speed;

       
    }
}
