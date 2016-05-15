using UnityEngine;
using System.Collections;
using System;

public class IASimple : MonoBehaviour {


    [HideInInspector] public Transform[] targets;
    NavMeshAgent agente;
    private int destino = 0;

	void Start () {
        agente = GetComponent<NavMeshAgent>();
        NextWaypoint();
    }

    private void NextWaypoint()
    {
        agente.SetDestination(targets[destino].position);
        destino = (destino + 1) % targets.Length;
    }

    // Update is called once per frame
    void Update () {
        if (agente.remainingDistance < 1.5f) NextWaypoint();
	}
}
