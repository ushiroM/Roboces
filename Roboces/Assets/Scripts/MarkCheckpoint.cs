using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int enemyLap = 0;
   
  
	void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            if (MarkWaypoint.playerWay == WaypointManager.waypointSize)
            {
                MarkWaypoint.playerWay = 0;
                HudManager.lap++;
            }
            else if (other.gameObject == enemy)
                if (MarkWaypoint.enemyWay == WaypointManager.waypointSize)
                {
                    MarkWaypoint.enemyWay = 0;
                    enemyLap++;
                }

    }
}
