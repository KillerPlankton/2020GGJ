using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpSome : MonoBehaviour
{

    [SerializeField]
    private float numberOfUnits, speed;

    private float targetHeight;
    private bool executed = false;

    void Awake()
    {
        this.targetHeight = this.transform.position.y + numberOfUnits;
    }

    void Update()
    {
        if (executed && this.transform.position.y < targetHeight)
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime * ( (0.125f + targetHeight) - this.transform.position.y));
        }
        else if (this.transform.position.y >= targetHeight) {
            this.transform.position = new Vector3(this.transform.position.x, this.targetHeight, this.transform.position.z);
            this.enabled = false;
        }
    }

    public void execute() {
        this.executed = true;
    }
}
