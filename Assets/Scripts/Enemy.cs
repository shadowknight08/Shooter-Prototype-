using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 1000;
    public int speed = 2;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
