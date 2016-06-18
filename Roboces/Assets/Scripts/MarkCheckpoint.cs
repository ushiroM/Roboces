using UnityEngine;
using System.Collections;

public class MarkCheckpoint : MonoBehaviour {

    GameObject player;
	GameObject[] enemies;
    public static int enemyLap;
    public static int playerLap;
	public static int maxlaps;
    controlCheckpoint controlPlayer;
    public static bool enemyLapComplete = false;
	PlayerMovement playerMov;
	IASimple enemyIA;
  
	void Start(){
		playerLap = 1;
		maxlaps = 1;
	}

	void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
		playerMov = player.GetComponent<PlayerMovement> ();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        else
        {
			for (int i = 0; i < enemies.Length; i++) {
				enemyIA = enemies[i].GetComponent<IASimple> ();
				if (enemyIA.lapComplete == true) {
					enemyIA.lap++;
					enemyIA.enemyWay = 1;
					enemyIA.lapComplete = false;
				}
			}
        }
    }
}
