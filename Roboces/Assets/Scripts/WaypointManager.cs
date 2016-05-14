using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {

    private Transform[] waypoints;
    GameObject enemigo;
    IASimple Simple;

	void Start () {
        waypoints = GetComponentsInChildren<Transform>();
        enemigo = GameObject.FindGameObjectWithTag("Enemy");
        Simple = enemigo.GetComponent<IASimple>();

        Simple.targets = waypoints;

	}
}
