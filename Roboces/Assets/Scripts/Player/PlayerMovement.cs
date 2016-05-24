using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{       
    public float Speed = 20f;            
    public float TurnSpeed = 180f;
    public float SpeedLimit = 20f;
    private float initialSpeedLimit;

    private string MovementAxisName;     
    private string TurnAxisName;         
    private Rigidbody Rigidbody;         
    private float MovementInputValue;    
    private float TurnInputValue;        
    private float Acceleration = 40f;
    private Animator anim;
	public GameObject particle;
	public GameObject particleVelocidad;
	public AudioSource runningAudio;

    //public Rigidbody Shell;
    //public Transform FireTransform;
    private string FireButton;
    private bool Fired;
    private bool Sprint = false;
    private float SprintTimer;
    private float SprintCooldown;

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
		particle.SetActive (false);
		particleVelocidad.SetActive (false);
        initialSpeedLimit = SpeedLimit;
    }
    
    private void Update()
    {
		runningAudio.Play ();
        MovementInputValue = Input.GetAxis(MovementAxisName);
        TurnInputValue = Input.GetAxis(TurnAxisName);

        if (Input.GetButtonUp(FireButton))
        {
            if (Sprint == false)
            {
                Sprint = true;
				particleVelocidad.SetActive (true);
                SpeedLimit = SpeedLimit * 1.5f;
                Speed = SpeedLimit;
                anim.speed = 1.5f;
                SprintCooldown = 0;
                SprintTimer = 0f;
            }
            
        }

        if (Sprint == true)
        {

            SprintTimer += Time.deltaTime;
            SprintCooldown += Time.deltaTime;
            HudManager.SprintUp = false;
        }

        if (SprintTimer >= 5f)
        {
			particleVelocidad.SetActive (false);
            SpeedLimit = initialSpeedLimit;
            anim.speed = 1;
            
        }

        if (SprintCooldown >= 12f)
        {
			
            Sprint = false;
            SprintTimer = 0f;
            HudManager.SprintUp = true;
        }

        //Fired = false;
        //if (Input.GetButtonUp(FireButton) && !Fired)
        //{
        //    Fire();
        //}
    }

    //private void Fire()
    //{
    //    Fired = true;
    //    Vector3 adjust = new Vector3(0, 0, 0);
    //    Rigidbody shellInstance = Instantiate(Shell, FireTransform.position, FireTransform.rotation) as Rigidbody;
    //    shellInstance.velocity = 40f * FireTransform.forward;
    //}

    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    private void Move()
    {
       
        if (MovementInputValue > 0.1f)
        {
            anim.SetBool("Moving", true);
			particle.SetActive (true);
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed > SpeedLimit) Speed = SpeedLimit;
			runningAudio.Play ();
        }
        else if(MovementInputValue == 0)
        {
            anim.SetBool("Moving", false);
			particle.SetActive (false);
            Speed = Speed - Acceleration * 10 * Time.deltaTime;
            if (Speed < 0) Speed = 0;
			runningAudio.Stop ();
        }
        else
        {
            anim.SetBool("Moving", true);
			particle.SetActive (true);
            Speed = Speed - Acceleration * Time.deltaTime;
            if (Speed < -SpeedLimit) Speed = -SpeedLimit;
			runningAudio.Play ();
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