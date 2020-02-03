using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutpostInteractions : MonoBehaviour
{
    [SerializeField]
    private GameObject parentOutpostGO;

    private Outpost parentOutpost;
    private bool isPlayerInteracting;

    public AK.Wwise.Event sndRepair;
    public GameObject wwiseObj;


    private void Start()
    {
        this.parentOutpost = parentOutpostGO.GetComponent<Outpost>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.isPlayerInteracting = true;
            if (parentOutpost.getState() == "DOWN")
            {
                parentOutpost.setState("REPAIRING");
                sndRepair.Post(wwiseObj);
            }
        }
    }

    void Update()
    {
        if (isPlayerInteracting && parentOutpost.getState() == "REPAIRING") {
            parentOutpost.incrementProgress(Time.deltaTime * 20f);
            Debug.Log("'" + parentOutpostGO.gameObject.name + "' repair progress is at '" + parentOutpost.getProgress() + "%'.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.isPlayerInteracting = false;
            if (parentOutpost.getState() != "REPAIRED") {
                parentOutpost.setState("DOWN");
            }
        }
    }
}
