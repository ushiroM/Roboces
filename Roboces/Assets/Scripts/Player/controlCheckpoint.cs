using UnityEngine;
using System.Collections;

public class controlCheckpoint : MonoBehaviour {

    [HideInInspector]public Transform[] checkpoints;
    int index ;
    public Transform checkpoint;
    public bool lapComplete = false;

    void Start () {
        //  nextWaypoint();
        index = 1;
        checkpoint = checkpoints[index];

	}

    public void nextWaypoint()
    {
        if (index + 1 == checkpoints.Length)
        {
            index = 1;
            lapComplete = true;
        }
        else
        {
            index = (index + 1) % checkpoints.Length;
        }
        checkpoint = checkpoints[index];
        
    }
    void Update()
    {
        Debug.Log("Destino: " + checkpoint + " index: " + index);
    }

}
