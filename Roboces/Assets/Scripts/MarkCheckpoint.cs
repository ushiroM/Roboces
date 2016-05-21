using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int enemyLap = 1;
    public static int playerLap = 1;
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
                playerLap++;
                MarkWaypoint.playerWay = 1;
                controlPlayer.lapComplete = false;
            }
        }
        else if (other.gameObject == enemy)
        {
            if (enemyLapComplete == true){
                enemyLap++;
                MarkWaypoint.enemyWay = 1;
                enemyLapComplete = false;
            }
        }
    }
}
