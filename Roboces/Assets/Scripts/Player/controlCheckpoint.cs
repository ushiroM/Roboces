using UnityEngine;
using System.Collections;

public class controlCheckpoint : MonoBehaviour {

    [HideInInspector]public Transform[] checkpoints;
    int index ;
    [HideInInspector]public Transform checkpoint;
    [HideInInspector]public bool lapComplete = false;

    void Start () {
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

}
