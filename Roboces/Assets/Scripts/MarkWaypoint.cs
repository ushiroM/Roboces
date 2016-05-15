using UnityEngine;
using System.Collections;

public class MarkWaypoint : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    public static int playerWay = 0;
    public static int enemyWay = 0;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player)
        {
            playerWay++;
        }
        else
            enemyWay++;

	}
}
