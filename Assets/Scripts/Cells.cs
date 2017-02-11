﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cells : MonoBehaviour {

    public GameObject config;
    public GameObject CellPrefab;
    private Dictionary<Vector3, GameObject> grid;

    private float CycleTime;
    private float CellWidth;
    private Vector3 scale {get { return new Vector3(CellWidth * .5f, CellWidth * .5f, CellWidth * .5f); } }
    private Vector3 origin;
    private Vector3 dimensions;

    // Use this for initialization
    void Start () {
        
        var configObj = config.GetComponent<LifeConfig>();
        CycleTime = configObj.CycleTime;
        CellWidth = configObj.CellWidth;
        origin = configObj.GridStart - new Vector3(CellWidth*.5f, CellWidth*.5f, CellWidth*.5f);
        dimensions = new Vector3(Util.Interval(configObj.GridStart.x, configObj.GridStop.x, CellWidth),
            Util.Interval(configObj.GridStart.y, configObj.GridStop.y, CellWidth),
            Util.Interval(configObj.GridStart.z, configObj.GridStop.z, CellWidth));
        grid = new Dictionary<Vector3, GameObject>();
        MakeGrid();
    }

    private void MakeGrid()
    {
        for(var x = 0; x <= dimensions.x; x++)
        {
            for (var y = 0; y <= dimensions.y; y++)
            {
                for (var z = 0; z <= dimensions.z; z++)
                {
                    var pos = new Vector3(origin.x + x * CellWidth * -1, origin.y + y * CellWidth * -1,
                        origin.z + z * CellWidth * -1);
                    var go = Instantiate(CellPrefab, pos, Quaternion.identity);
                    go.transform.localScale = scale;
                    go.transform.parent = transform;
                    go.GetComponent<BoxCollider>().size = scale;
                    go.GetComponent<Cell>().Initialize(new Vector3(x, y, z), Surrounding);

                    grid[pos] = go;
                }
            }
        }
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

    private IEnumerable<GameObject> Surrounding(Vector3 pos)
    {
        return from c in Util.Surrounding(pos) where c != pos && grid.ContainsKey(c) select grid[c];
    }
}
