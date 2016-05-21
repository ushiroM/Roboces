using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour {

    public static int position;
    Text text;

    void Awake () {
        position = 2;
        text = GetComponent<Text>();
    }
	
	void Update () {
        text.text = position + " " +"/2";
    }
}
