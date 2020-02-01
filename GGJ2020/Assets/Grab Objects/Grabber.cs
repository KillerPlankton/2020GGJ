using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private List<CanGrab> _grabbables = new List<CanGrab>();
    private bool _canHold = true;

    private GameObject _objectHolding = null;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canHold && _grabbables.Count > 0)
            {
                PickUp(_grabbables[0].gameObject);
            }
            else if (!_canHold && _objectHolding != null)
            {
                Drop();
            }
        }

        if (_objectHolding != null)
        {
            _objectHolding.transform.position = transform.position;
        }
    }

    private void PickUp(GameObject objectToGrab)
    {
        if (!_canHold) return;
        //We set the object parent to our guide empty object.
        objectToGrab.transform.SetParent(transform);

        //Set gravity to false while holding it
        var rigidBody = objectToGrab.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;

        //we apply the same rotation our main object (Camera) has.
        objectToGrab.transform.localRotation = transform.rotation;
        //We re-position the ball on our guide object 
        objectToGrab.transform.position = transform.position;

        _canHold = false;
        _objectHolding = objectToGrab;
    }

    private void Drop()
    {
        if (_canHold || _objectHolding == null) return;

        //Set our Gravity to true again.
        var rigidBody = _objectHolding.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        // we don't have anything to do with our ball field anymore
        _objectHolding = null;
        //Apply velocity on throwing
        // guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our object
        transform.GetChild(0).parent = null;
        _canHold = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CanGrab>(out var grabObject))
        {
            _grabbables.Add(grabObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CanGrab>(out var grabObject))
        {
            _grabbables.Remove(grabObject);
        }
    }

}
