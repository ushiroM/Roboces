using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	
    public static int lap;
    Text text;
    GameObject player;
    GameObject enemy;
   

    void Awake()
    {
        text = GetComponent<Text>();
        lap = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

   void Update()
    {
        text.text = "LAP" + " " + lap + "/3";  
    }
}
