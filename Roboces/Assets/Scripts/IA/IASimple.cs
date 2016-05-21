using UnityEngine;
using System.Collections;
using System;

public class IASimple : MonoBehaviour {


    [HideInInspector] public Transform[] targets;
    NavMeshAgent agente;
    private int destino = 1;

	void Start () {
        agente = GetComponent<NavMeshAgent>();
        agente.SetDestination(targets[destino].position);
    }

    private void NextWaypoint()
    {
        if(destino + 1 > targets.Length)
        {
            destino = 1;
        }
        else
        {
            destino = (destino + 1) % targets.Length;
        }
        agente.SetDestination(targets[destino].position);
    }

    void Update () {
        if (agente.remainingDistance < 1.5f) NextWaypoint();
	}
}
