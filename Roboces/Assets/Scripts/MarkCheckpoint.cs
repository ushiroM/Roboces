using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int enemyLap;
    public static int playerLap;
	public static int maxlaps;
    controlCheckpoint controlPlayer;
    public static bool enemyLapComplete = false;
	PlayerMovement playerMov;
	IASimple enemyIA;
  
	void Start(){
		enemyLap = 1;
		playerLap = 1;
		maxlaps = 1;
	}
	void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
		playerMov = player.GetComponent<PlayerMovement> ();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyIA = enemy.GetComponent<IASimple> ();
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
