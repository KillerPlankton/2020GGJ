using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegieKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vegie") {
            other.gameObject.GetComponent<Vegie>().Kill();
        }
    }
}
