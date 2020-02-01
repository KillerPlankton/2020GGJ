using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Detects objects with trigger colliders that collide with the cone. Gets bigger/smaller
/// with the use of the mouse wheel. 
/// 
/// </summary>
public class Tracker : MonoBehaviour
{
    public GameObject cone;
    public float signalStrength = 0f;
    public float minValue = 0f;
    public float maxValue = 10f;
    public float defaultConeScale = 0.1256478f;

    [Header("Debug settings")]
    public bool showTrackerCone = true;

    private void Start()
    {
        cone.GetComponent<MeshRenderer>().enabled = showTrackerCone;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The tracker has hit " + other.name);
        // Example usage
        if (other.gameObject.TryGetComponent<VegiAlive>(out var vegitation))
        {
            vegitation.SetAlive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("The tracker has exited collision with " + other.name);
        // Example usage
        if (other.gameObject.TryGetComponent<VegiAlive>(out var vegitation))
        {
            vegitation.SetAlive(false);
        }
    }

    private void Update()
    {
        cone.GetComponent<MeshRenderer>().enabled = showTrackerCone;
        signalStrength += Input.GetAxis("Mouse ScrollWheel");
        signalStrength = Mathf.Clamp(signalStrength, minValue, maxValue);
        cone.transform.localScale = new Vector3(defaultConeScale + signalStrength / 5, defaultConeScale, defaultConeScale + signalStrength / 5);
    }
}
