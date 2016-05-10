using UnityEngine;
using System.Collections;

public class IASimple : MonoBehaviour {


    public Transform target;
    NavMeshAgent agente;
	// Use this for initialization
	void Start () {
        agente = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agente.SetDestination(target.position);
	}
}
