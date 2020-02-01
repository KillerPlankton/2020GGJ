using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegiAlive : MonoBehaviour
{
    [SerializeField]
    private GameObject _deadObject;

    [SerializeField]
    private GameObject _aliveObject;

    [SerializeField]
    private bool _isAlive = false;

    // Start is called before the first frame update
    void Start()
    {
        ToggleObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DeadAliveCollider>() != null)
        {
            _isAlive = true;
            ToggleObjects();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DeadAliveCollider>() != null)
        {
            _isAlive = false;
            ToggleObjects();
        }
    }

    private void ToggleObjects()
    {
        _deadObject.gameObject.SetActive(!_isAlive);
        _aliveObject.gameObject.SetActive(_isAlive);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
