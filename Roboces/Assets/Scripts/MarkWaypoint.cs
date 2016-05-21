using UnityEngine;
using System.Collections;

public class MarkWaypoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int playerWay = 1;
    public static int enemyWay = 1;
    bool playerCollided = false;
    bool enemyCollided = false;
    controlCheckpoint controlPlayer;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject == player)
        {
            if (playerCollided == false)
            {
                playerWay++;
                playerCollided = true;
                if (controlPlayer.checkpoint == transform)
                {
                    controlPlayer.nextWaypoint();
                }
            }
        }
        else if (other.gameObject == enemy)
        {
            if (enemyCollided == false)
            {
                enemyWay++;
                enemyCollided = true;
                if (enemyWay == WaypointManager.waypointSize)
                    MarkCheckpoint.enemyLapComplete = true;
            }
        }
    }

    void Update()
    {
        if (MarkCheckpoint.playerLap > MarkCheckpoint.enemyLap)
        {
            PositionManager.position = 1;
        }
        else if (MarkCheckpoint.playerLap < MarkCheckpoint.enemyLap)
        {
            PositionManager.position = 2;
        }
        else if(MarkCheckpoint.playerLap == MarkCheckpoint.enemyLap)
        {
            if (playerWay > enemyWay) PositionManager.position = 1;
            else if (playerWay < enemyWay)
                PositionManager.position = 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerCollided = false;
        }else if (other.gameObject == enemy)
        {
            enemyCollided = false;
        }
    }
}
