using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegieKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Vegie>(out var vegie))
        {
            vegie.Kill();
        }
        else if (other.gameObject.tag == "Player") {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Die();
        } 
    }
}
