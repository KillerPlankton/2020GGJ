using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{

    public AK.Wwise.Event sndOutpost;
    public GameObject wwiseObj;
    private string state = "DOWN";

    [SerializeField]
    private string functionCalledOnRepaired;

    [SerializeField]
    private OutpostState[] states;

    private Material bulbMat, screenMat;

    [SerializeField]
    private Light screenLight, bulbSpotLight, bulbPointLight;

    [SerializeField]
    private GameObject activationZone, outpostZone;

    [SerializeField]
    private TrailRenderer activationZoneTrail, outpostLoadingTrail;

    [SerializeField]
    private float degreesPerSecond = 180f;

    private float progress = 0f;

    void Start()
    {
        this.bulbMat = GetComponent<MeshRenderer>().materials[1];
        this.screenMat = GetComponent<MeshRenderer>().materials[3];
        applyState(this.state);
    }

    void Update()
    {
        bulbSpotLight.transform.RotateAround(Vector3.up, degreesPerSecond * Time.deltaTime);
    }

    public void setState(string newState)
    {
        this.state = newState;
        applyState(this.state);
    }

    public string getState()
    {
        return this.state;
    }

    public void incrementProgress(float value)
    {
        this.progress += value;
        if (progress >= 100f) {
            this.setState("REPAIRED");
            sndOutpost.Post(wwiseObj);
            outpostZone.SendMessage(functionCalledOnRepaired);
            GameObject.FindGameObjectWithTag("GameController").SendMessage("OutpostRepaired");
        }
    }

    public float getProgress()
    {
        return this.progress;
    }

    private void applyState(string newState)
    {
        bool foundState = false;
        foreach (OutpostState state in states)
        {
            if (state.state_name.Equals(newState))
            {
                foundState = true;

                // Handle Bulb style
                this.bulbMat.SetColor("_BaseMap", state.light);
                this.bulbMat.SetColor("_EmissiveColor", state.light);
                this.bulbSpotLight.enabled = state.isInteractive;
                this.bulbSpotLight.color = state.light;
                this.bulbPointLight.color = state.light;

                // Handle Screen style
                this.screenMat.SetColor("_BaseMap", state.dark);
                this.screenMat.SetColor("_EmissiveColor", state.dark);
                this.screenMat.color = state.dark;
                this.screenLight.color = state.dark;

                // Handle Activation Zone
                this.activationZone.SetActive(state.isInteractive);
                this.activationZoneTrail.enabled = state.isInteractive;

                if (state.state_name == "REPAIRING")
                {
                    this.outpostLoadingTrail.gameObject.SetActive(true);
                }
                else {
                    this.outpostLoadingTrail.gameObject.SetActive(false);
                }
            }
        }
        if (foundState == false)
        {
            Debug.LogError("Couldn't find given state '" + newState + "', changes are ignored.");
        }
    }
}
