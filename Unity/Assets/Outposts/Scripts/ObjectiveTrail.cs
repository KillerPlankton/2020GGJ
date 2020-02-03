using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrail : MonoBehaviour
{
    [SerializeField]
    private float speed = (2 * Mathf.PI) / 5;
    [SerializeField]
    private float height = (2 * Mathf.PI) / 5;

    private float angle = 0;
    private float radius = 3;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        angle += -speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        this.transform.position = new Vector3(initialPosition.x + x, initialPosition.y + height, initialPosition.z + z);
    }
}
