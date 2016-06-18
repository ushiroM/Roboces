using UnityEngine;
using System.Collections;

public class MarkWaypoint : MonoBehaviour {

    GameObject player;
    GameObject[] enemies;
    public static int playerWay;
    public static int enemyWay;
    bool playerCollided = false;
    bool enemyCollided = false;
    controlCheckpoint controlPlayer;
	IASimple ia;
	int positionToGive;
	int Lap = 1;

    void Start () {
		playerWay = 1;
		//enemyWay = 1;
		positionToGive = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void OnTriggerEnter(Collider other) {
		

        if (other.gameObject == player)
        {
            if (playerCollided == false)
            {
				playerWay++;
				playerCollided = true;
				if (Lap < MarkCheckpoint.playerLap) {
					PositionManager.position = 1;
					Lap++;
					positionToGive = 2;
				} else if (Lap >= MarkCheckpoint.playerLap) {
					PositionManager.position = positionToGive;
					positionToGive++;
					if (positionToGive > 4)
						positionToGive = 1;
				}
				if (controlPlayer.checkpoint == transform) {
					controlPlayer.nextWaypoint();
				}
            }
        }
        else
        {
			for (int i = 0; i < enemies.Length; i++) {
				if (other.gameObject == enemies[i]) {
					ia = enemies [i].GetComponent<IASimple> ();
					ia.enemyWay++;
					enemyCollided = true;
					if (Lap < ia.lap) {
						ia.position = 1;
						Lap++;
						positionToGive = 2;
					} else if (Lap >= ia.lap) {
						ia.position = positionToGive;
						positionToGive++;
						if (positionToGive > 4)
							positionToGive = 1;
					}
					if (ia.enemyWay == WaypointManager.waypointSize)
						ia.lapComplete = true;
				}
			}
        }
    }
    void OnTriggerExit(Collider other)
    {
		if (other.gameObject == player) {
			playerCollided = false;
		}
//        }else if (other.gameObject == enemies)
//        {
//            enemyCollided = false;
//        }
    }
}
