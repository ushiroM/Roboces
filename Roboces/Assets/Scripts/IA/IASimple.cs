using UnityEngine;
using System.Collections;
using System;

public class IASimple : MonoBehaviour {


    [HideInInspector] public Transform[] targets;
    NavMeshAgent agente;
    private int destino = 1;
    private bool activo;
	Animator animator;
	public GameObject particle;
	public GameObject particleVelocidad;
    GameObject player;
    private bool Sprint;
    private float SprintCooldown;
    private float SprintTimer;
    private float initialSpeed;
    private float initialAcceleration;
	private bool IAenable = false;
	[HideInInspector]public int position = 0;
	public int enemyWay = 1;
	public int lap = 1;
	public bool lapComplete = false;

    void Start () {

        agente = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
		particle.SetActive (false);
		particleVelocidad.SetActive (false);
        initialAcceleration = agente.acceleration;
        initialSpeed = agente.speed;

        if(activo)
            agente.SetDestination(targets[destino].position);
    }

    private void NextWaypoint()
    {
        if (activo)
        {
            if (destino + 1 > targets.Length)
            {
                destino = 1;
            }
            else
            {
                destino = (destino + 1) % targets.Length;
            }
            agente.SetDestination(targets[destino].position);
        }
    }

    void Update () {

        if (agente.isActiveAndEnabled)
        {
            if (agente.remainingDistance < 1.5f) NextWaypoint();
        }

        var distance = transform.position - player.transform.position;
		if ((distance.sqrMagnitude < 80 && IAenable == true) || (distance.sqrMagnitude > 300 && IAenable == true))
        {
            if (Sprint == false)
            {
				particleVelocidad.SetActive (true);
                Sprint = true;
                animator.speed = 1.5f;
                agente.speed *= 1.5f;
                agente.acceleration *= 1.5f;
                SprintCooldown = 0;
                SprintTimer = 0f;
            }
        }

        if (Sprint == true)
        {
            SprintTimer += Time.deltaTime;
            SprintCooldown += Time.deltaTime;

        }

        if (SprintTimer >= 5f)
        {
			particleVelocidad.SetActive (false);
            animator.speed = 1;
            agente.speed = initialSpeed;
            agente.acceleration = initialAcceleration;
        }

        if (SprintCooldown >= 12f)
        {
            Sprint = false;
            SprintTimer = 0f;
        }
    }

    public void DisableIA()
    {
        activo = false;
		IAenable = false;
		animator.SetBool("IArun", false);
		particle.SetActive (false);
		particleVelocidad.SetActive (false);
    }

    public void EnableIA()
    {
        activo = true;
		IAenable = true;
		animator.SetBool ("IArun", true);
		particle.SetActive (true);
		//particleVelocidad.SetActive (true);
    }

	public void TurnOffIA()
	{
        agente.enabled = false;
	}
}
