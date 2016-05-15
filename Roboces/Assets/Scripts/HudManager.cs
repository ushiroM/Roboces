﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	
    public static int lap;
    public static int position;
    Text text;
    GameObject player;
    GameObject enemy;
   

    void Awake()
    {
        text = GetComponent<Text>();
        lap = 0;
        position = 2;
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

   void Update()
    {
        text.text = "LAP" + " " + lap + "/3";

        
    }
}
