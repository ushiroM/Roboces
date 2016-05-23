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
    GameObject player;
    private bool Sprint;
    private float SprintCooldown;
    private float SprintTimer;
    private float initialSpeed;
    private float initialAcceleration;

    void Start () {

        agente = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator> ();
        player = GameObject.FindGameObjectWithTag("Player");
		particle.SetActive (false);
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

        if (agente.remainingDistance < 1.5f) NextWaypoint();

        var distance = transform.position - player.transform.position;
        if (distance.sqrMagnitude < 80)
        {
            if (Sprint == false)
            {
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
            Debug.Log("Sprint IA");
            SprintTimer += Time.deltaTime;
            SprintCooldown += Time.deltaTime;

        }

        if (SprintTimer >= 5f)
        {
            Debug.Log("No Sprint IA");
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
		animator.SetBool ("IArun", false);
		particle.SetActive (false);
    }

    public void EnableIA()
    {
        activo = true;
		animator.SetBool ("IArun", true);
		particle.SetActive (true);
    }

	public void TurnOffIA()
	{
		agente.Stop ();
	}
}
