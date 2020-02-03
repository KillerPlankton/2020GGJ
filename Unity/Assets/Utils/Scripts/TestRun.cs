using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRun : MonoBehaviour
{
    public MoveUpSome MovingCubeScript;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Moving Cube up.");
        MovingCubeScript.execute();
    }
}
