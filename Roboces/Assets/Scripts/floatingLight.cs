using UnityEngine;
using System.Collections;

public class floatingLight : MonoBehaviour {

	float initialY;
	public float amplitude;
	public int speed;

	void Start() {
		initialY = transform.position.y;
	}

	void Update() {
		transform.position = new Vector3(transform.position.x, initialY+amplitude*Mathf.Sin(speed*Time.time), transform.position.z);
	}
}
