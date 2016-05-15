using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int enemyLap = 0;
    controlCheckpoint controlPlayer;
   
  
	void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (controlPlayer.lapComplete == true)
            {
                controlPlayer.lapComplete = false;
                HudManager.lap++;
            }
        }
        else if (other.gameObject == enemy)
        {
            if (MarkWaypoint.enemyWay == WaypointManager.waypointSize)
            {
                MarkWaypoint.enemyWay = 0;
                enemyLap++;
            }
        }

    }
}
