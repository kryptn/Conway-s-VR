using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public Grid Grid;
    public bool State;
    private bool NextState;
    private Vector3 pos;
    private Func<Vector3, List<Cell>> GetSurrounding;
    private int nextUpdate = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= nextUpdate)
	    {
	        nextUpdate = Mathf.FloorToInt(Time.time);
	        Cycle();
	    }
	}

    void Cycle()
    {
        var neighbors = GetSurrounding(pos);
    }

    void Initialize(Vector3 pos, Func<Vector3, List<Cell>> GetSurrounding)
    {
        this.pos = pos;
        this.GetSurrounding = GetSurrounding;
    }
}
