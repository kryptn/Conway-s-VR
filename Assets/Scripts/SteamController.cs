using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamController : MonoBehaviour
{

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    private SteamVR_TrackedObject trackedObj;

    // Update is called once per frame
    void Update()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void OnCollisionStay(Collision collision)
    {

    }
}