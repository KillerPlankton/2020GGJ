using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{

    public Light spotLight;
    public float degreesPerSecond = 180f;

    public void OnInteraction()
    {
        Debug.Log("You've interacted with me");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spotLight.transform.RotateAround(Vector3.up, degreesPerSecond * Time.deltaTime);
    }
}
