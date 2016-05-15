using UnityEngine;
using System.Collections;

public class MarkWaypoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int playerWay = 0;
    public static int enemyWay = 0;
    controlCheckpoint controlPlayer;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        controlPlayer = player.GetComponent<controlCheckpoint>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player)
        {
           if(controlPlayer.checkpoint == transform)
           {
                controlPlayer.nextWaypoint();
                //Debug.Log(this.name);
           }  
        }
        else
            enemyWay++;

	}
}
