using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Joystick attackjoy;
    [SerializeField]
    private Transform playersprite;
    private CharacterController controller;
    [SerializeField]
    private float speed = 5.0f;
    private float gravity = 1.0f;
    Vector3 offset;
   
   

    private Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
            
        }

        offset = transform.position - Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playersprite.position = new Vector3(attackjoy.Horizontal + transform.position.x, 0, attackjoy.Vertical + transform.position.z);

        transform.LookAt(new Vector3(playersprite.position.x, 0, playersprite.position.z));

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        Movement();        
    }

    public void Movement()
    {

        if (controller.isGrounded)
        {
            //move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);


        }

        move.y -= gravity * Time.deltaTime;

        controller.Move(move * Time.deltaTime * speed);

        Camera.main.transform.position = transform.position - offset;
    }

    
}
