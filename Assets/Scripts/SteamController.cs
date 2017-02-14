using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamController : MonoBehaviour
{

    
    private SteamVR_TrackedObject trackedObj;
    private const EVRButtonId Trigger = EVRButtonId.k_EButton_SteamVR_Trigger;
    private const EVRButtonId Pad = EVRButtonId.k_EButton_SteamVR_Touchpad;

    public GameObject Cells;
    private GameObject cell;

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller == null)
            return;

        if (cell != null && Controller.GetPressDown(Trigger))
            cell.SendMessage("Toggle");

        if (Controller.GetPressDown(Pad))
            Cells.GetComponent<Cells>().Iterate();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        cell = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        cell = null;
    }
}