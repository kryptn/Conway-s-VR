using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour {

    public GameObject config;

    private Dictionary<Vector3, Cell> grid;

    private float CycleTime;
    private Vector3 GridStart;
    private Vector3 GridStop;
    private float CellWidth;
    private Vector3 scale {get { return new Vector3(CellWidth * .90f, CellWidth * .90f, CellWidth * .90f); } }

    // Use this for initialization
    void Start () {
        
        var configObj = config.GetComponent<LifeConfig>();
        CellWidth = configObj.CellWidth;
        GridStart = configObj.GridStart - new Vector3(CellWidth*.5f, CellWidth*.5f, CellWidth*.5f);
        GridStop = configObj.GridStop;
        CycleTime = configObj.CycleTime;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time);
            Cycle();
        }*/
    }


}
