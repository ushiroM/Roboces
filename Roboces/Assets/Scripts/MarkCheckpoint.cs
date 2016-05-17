using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int enemyLap = 0;
    controlCheckpoint controlPlayer;
    public static bool enemyLapComplete = false;
   
  
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
                MarkWaypoint.playerWay = 0;
                controlPlayer.lapComplete = false;
                HudManager.lap++;
            }
        }
        else if (other.gameObject == enemy)
        {
            if (enemyLapComplete == true){
                MarkWaypoint.enemyWay = 0;
                enemyLapComplete = false;
                enemyLap++;
                
            }
        }

    }
}
