using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    Text text;
    GameObject player;
    GameObject enemy;
   

    void Awake()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

   void Update()
    {
        text.text = "LAP" + " " + MarkCheckpoint.playerLap + "/"+MarkCheckpoint.maxlaps;  
    }
}
