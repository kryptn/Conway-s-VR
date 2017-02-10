using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Cell : MonoBehaviour
{
    
    public Util.CellStateEnum State;
    private Util.CellStateEnum NextState;
    
    private Func<Vector3, List<GameObject>> GetSurrounding;
    private Vector3 position;

    private const EVRButtonId Trigger = EVRButtonId.k_EButton_SteamVR_Trigger;

    // Initialize with arguments
    public void Initialize(Vector3 pos, Func<Vector3, List<GameObject>> getSurrounding)
    {
        position = pos;
        GetSurrounding = getSurrounding;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    State = NextState;
	}

    void Cycle()
    {
        var neighbors = GetSurrounding(position);
    }

    private void OnCollisionStay(Collision collision)
    {
        // this is where i'd add an effect to the gameobject to show it's selected


        var controller = collision.collider.GetComponent<SteamController>().Controller;
        if (controller.GetPress(Trigger))
            NextState = State == Util.CellStateEnum.Alive ? Util.CellStateEnum.Dead : Util.CellStateEnum.Alive;
        
    }


}
