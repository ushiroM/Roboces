using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	UILabel text;
    GameObject player;
    GameObject enemy;
    public static bool SprintUp = true;
    public UITexture SprintOn;
    public UITexture SprintOff;

    void Awake()
    {
		text = GetComponent<UILabel>();
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
