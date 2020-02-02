using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegie : MonoBehaviour
{
    [SerializeField]
    private GameObject deadObject;

    [SerializeField]
    private GameObject aliveObject;

    [SerializeField]
    private bool _isAlive = true; // Alive by default
    private GameObject GO;

    void Start()
    {
        GO = Instantiate(this._isAlive ? aliveObject : deadObject, transform.position, Quaternion.identity);
    }

    public void Kill() {
        this._isAlive = false;
        Destroy(GO);
        GO = Instantiate(this._isAlive ? aliveObject : deadObject, transform.position, Quaternion.identity);
    }

    public void Restore()
    {
        this._isAlive = true;
        Destroy(GO);
        GO = Instantiate(this._isAlive ? aliveObject : deadObject, transform.position, Quaternion.identity);
    }
}
