﻿using UnityEngine;
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
            playerWay++;
            if (playerWay > enemyWay) PositionManager.position = 1;

            if (controlPlayer.checkpoint == transform)
            {
                controlPlayer.nextWaypoint();
            }
        }
        else
        {
            enemyWay++;
            if (enemyWay > playerWay) PositionManager.position = 2;
        }

	}
}
