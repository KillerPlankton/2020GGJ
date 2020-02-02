using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
