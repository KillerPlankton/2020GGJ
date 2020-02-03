using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public AK.Wwise.Event initialisationRadio;

    public GameObject wwiseObj;
    // Start is called before the first frame update
    void Start()
    {
        initialisationRadio.Post(wwiseObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
