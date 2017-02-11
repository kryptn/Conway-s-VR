using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;

public class Cell : MonoBehaviour
{
    
    public Util.CellStateEnum State;
    private Util.CellStateEnum NextState;

    public int neighbors;
    
    private Func<Vector3, IEnumerable<GameObject>> GetSurrounding;
    public Vector3 position;

    private const EVRButtonId Trigger = EVRButtonId.k_EButton_SteamVR_Trigger;

    // Initialize with arguments
    public void Initialize(Vector3 pos, Func<Vector3, IEnumerable<GameObject>> getSurrounding)
    {
        position = pos;
        GetSurrounding = getSurrounding;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    neighbors = GetSurrounding(position).Count();//go => go.GetComponent<Cell>().State == Util.CellStateEnum.Alive);


        if (State == NextState) return;
	    State = NextState;
        GetComponent<MeshRenderer>().enabled = State == Util.CellStateEnum.Alive;
	}

    void Cycle()
    {
        var count = GetSurrounding(position).Count(go => go.GetComponent<Cell>().State == Util.CellStateEnum.Alive);
    }

    void Toggle()
    {
        NextState = State == Util.CellStateEnum.Alive ? Util.CellStateEnum.Dead : Util.CellStateEnum.Alive;
    }
    
}
