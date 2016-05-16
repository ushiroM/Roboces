using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{       
    public float Speed = 20f;            
    public float TurnSpeed = 180f;
    public float SpeedLimit = 20f;

    private string MovementAxisName;     
    private string TurnAxisName;         
    private Rigidbody Rigidbody;         
    private float MovementInputValue;    
    private float TurnInputValue;        
    private float Acceleration = 40f;
    private Animator anim;

    public Rigidbody Shell;
    public Transform FireTransform;
    private string FireButton;
    private bool Fired;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    private void OnEnable ()
    {
        MovementInputValue = 0f;
        TurnInputValue = 0f;
    }


    private void Start()
    {
        MovementAxisName = "Vertical";
        TurnAxisName = "Horizontal";
        FireButton = "Fire1";
        Speed = 0;
    }
    

    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        MovementInputValue = Input.GetAxis(MovementAxisName);
        TurnInputValue = Input.GetAxis(TurnAxisName);
        Fired = false;
        if (Input.GetButtonUp(FireButton) && !Fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Fired = true;
        Vector3 adjust = new Vector3(0, 0, 0);
        Rigidbody shellInstance = Instantiate(Shell, FireTransform.position, FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = 40f * FireTransform.forward;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        if (MovementInputValue > 0.1f)
        {
            anim.SetBool("Moving", true);
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed > SpeedLimit) Speed = SpeedLimit;
        }
        else if(MovementInputValue == 0)
        {
            anim.SetBool("Moving", false);
            Speed = Speed - Acceleration * 10 * Time.deltaTime;
            if (Speed < 0) Speed = 0;
        }
        else
        {
            anim.SetBool("Moving", true);
            Speed = Speed - Acceleration * Time.deltaTime;
            if (Speed < -SpeedLimit) Speed = -SpeedLimit;
        }

        Vector3 movement = transform.forward * Speed * Time.deltaTime;
        Rigidbody.MovePosition(Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.

        float turn = TurnInputValue * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }

    public void wallCollide(bool collide)
    {
        while (collide == true)
            Acceleration = Acceleration * -1;
    }
}