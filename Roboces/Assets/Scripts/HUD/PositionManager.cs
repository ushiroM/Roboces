using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour {

    public static int position;
	UILabel text;

    void Awake () {
        position = 4;
		text = GetComponent<UILabel>();
    }
	
	void Update () {
        text.text = position + "º";
    }
}
