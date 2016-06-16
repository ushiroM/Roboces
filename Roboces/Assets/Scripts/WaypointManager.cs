using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {

    private Transform[] waypoints;
    GameObject[] enemigo;
    IASimple Simple;
    public static int waypointSize;
    GameObject player;
    controlCheckpoint controlPlayer;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
        waypoints = GetComponentsInChildren<Transform>();
        controlPlayer.checkpoints = waypoints;
        enemigo = GameObject.FindGameObjectsWithTag("Enemy");
        waypointSize = waypoints.Length;
        for (int i = 0; i < enemigo.Length; i++)
        {
            Simple = enemigo[i].GetComponent<IASimple>();
            Simple.targets = waypoints;
        }   
	}
}
