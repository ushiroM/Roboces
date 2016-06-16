using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	UILabel text;
    public static bool SprintUp = true;
    public UITexture SprintOn;
    public UITexture SprintOff;

    void Awake()
    {
		text = GetComponent<UILabel>();
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
