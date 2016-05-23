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

	void Start () {
        agente = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator> ();
		particle.SetActive (false);
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
