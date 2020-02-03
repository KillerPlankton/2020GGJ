using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutpostLoading : MonoBehaviour
{
    [SerializeField]
    private float speed = (2 * Mathf.PI) / 5;
    [SerializeField]
    private float height = (2 * Mathf.PI) / 5;

    private float angle = 0;
    private float radius = 0.5f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        angle += -speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        this.transform.position = new Vector3( this.initialPosition.x + height, this.initialPosition.y + y, this.initialPosition.z + x);
    }
}
