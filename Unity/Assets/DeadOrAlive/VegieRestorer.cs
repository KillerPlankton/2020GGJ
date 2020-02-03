using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegieRestorer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vegie")
        {
            Vegie vegie = other.gameObject.GetComponent<Vegie>();
            Debug.Log(vegie.getGO().name);
            vegie.getGO().transform.parent = this.transform.parent;
            vegie.Restore();
        }
    }

    //public void restoreAreaForceAlive()
    //{

        //        Debug.Log("Restore Area");


        //        for (int i = 0; i < containedVegies.Count; i++)
        //        {
        //            GameObject vegieGO = containedVegies[i];
        //            Debug.Log(vegieGO.name);
        //            // Instantiate permanent instance of the alive vegie.
        //            GameObject stableVegie = Instantiate(vegieGO.GetComponent<Vegie>().getAliveObject(), vegieGO.transform.position, vegieGO.transform.rotation);
        //            stableVegie.name = "WASOP";

        //            // Delete old vegie with vegie behaviours
        //            containedVegies.RemoveAt(i);
        //            Destroy(vegieGO);
        //        }
        //    }

        //    void Start()
        //    {
        //        Invoke("restoreAreaForceAlive", 2.0f);
        //    }
    }
