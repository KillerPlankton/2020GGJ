using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAliveCollider : MonoBehaviour
{
    [SerializeField]
    private SphereCollider _collider;
    
    void Start()
    {
            
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Colliding from Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
