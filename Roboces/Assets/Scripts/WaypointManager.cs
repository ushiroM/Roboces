using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {

    private Transform[] waypoints;
    GameObject enemigo;
    IASimple Simple;
    public static int waypointSize;

	void Start () {
        waypoints = GetComponentsInChildren<Transform>();
        enemigo = GameObject.FindGameObjectWithTag("Enemy");
        Simple = enemigo.GetComponent<IASimple>();
        waypointSize = waypoints.Length;
        Simple.targets = waypoints;

	}
}
