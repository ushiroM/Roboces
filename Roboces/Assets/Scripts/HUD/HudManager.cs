using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    Text text;
    GameObject player;
    GameObject enemy;
    public static bool SprintUp = true;
    public RawImage SprintOn;
    public RawImage SprintOff;

    void Awake()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

   void Update()
    {
        text.text = "LAP" + " " + MarkCheckpoint.playerLap + "/"+MarkCheckpoint.maxlaps;  

        if (SprintUp)
        {
            SprintOff.enabled = false;
            SprintOn.enabled = true;
        }
        else
        {
            SprintOn.enabled = false;
            SprintOff.enabled = true;
        }
    }
}
