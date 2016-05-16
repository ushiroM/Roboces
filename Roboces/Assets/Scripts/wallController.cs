using UnityEngine;
using System.Collections;

public class wallController : MonoBehaviour {

    GameObject player;
    PlayerMovement playermov;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playermov = player.GetComponent<PlayerMovement>();
	}
	
	void onTriggerEnter(Collider other) {
        if (other.gameObject == player)
            playermov.wallCollide(true);
    }
    void onTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playermov.wallCollide(false);
    }
}
