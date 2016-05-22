using UnityEngine;
using System.Collections;
using System;

public class IASimple : MonoBehaviour {


    [HideInInspector] public Transform[] targets;
    NavMeshAgent agente;
    private int destino = 1;
    private bool activo;

	void Start () {
        agente = GetComponent<NavMeshAgent>();
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
    }
    public void EnableIA()
    {
        activo = true;
    }
}
