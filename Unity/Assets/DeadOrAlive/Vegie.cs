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
        this.GO = Instantiate(this._isAlive ? this.aliveObject : this.deadObject, this.transform.position, this.transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Kill() {
        this._isAlive = false;
        Destroy(this.GO);
        this.GO = Instantiate(this._isAlive ? this.aliveObject : this.deadObject, this.transform.position, this.transform.rotation);
    }

    public void Restore()
    {
        this._isAlive = true;
        Destroy(this.GO);
        this.GO = Instantiate(this._isAlive ? this.aliveObject : this.deadObject, this.transform.position, this.transform.rotation);
    }

    public GameObject getAliveObject() {
        return this.aliveObject;
    }

    public GameObject getGO()
    {
        return this.GO;
    }
}
