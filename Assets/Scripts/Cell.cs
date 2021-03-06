﻿using System;
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

    private void Start()
    {
        NextState = State;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (State == NextState) return;
	    State = NextState;
        //GetComponent<MeshRenderer>().enabled = State == Util.CellStateEnum.Alive;
	}

    public void UpdateNeighbors(int alive)
    {
        neighbors = alive;

        if (alive < 5 || alive >20)
            NextState = Util.CellStateEnum.Dead;
        else if (State == Util.CellStateEnum.Dead && new List<int>{8, 9, 10}.Contains(alive))
            NextState = Util.CellStateEnum.Alive;
    }
    
    void Toggle()
    {
        NextState = State == Util.CellStateEnum.Alive ? Util.CellStateEnum.Dead : Util.CellStateEnum.Alive;
    }
    
}
