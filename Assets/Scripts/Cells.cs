using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cells : MonoBehaviour {

    public GameObject config;
    public GameObject CellPrefab;
    private Dictionary<Vector3, Cell> grid;

    private float CycleTime;
    private float CellWidth;
    private Vector3 scale {get { return new Vector3(CellWidth * .5f, CellWidth * .5f, CellWidth * .5f); } }
    private Vector3 origin;
    private Vector3 dimensions;

    private float nextUpdate;

    // Use this for initialization
    void Start () {
        
        var configObj = config.GetComponent<LifeConfig>();
        CycleTime = configObj.CycleTime;
        CellWidth = configObj.CellWidth;
        origin = configObj.GridStart;

        var start = configObj.GridStart;
        var end = configObj.GridStop;
        var dx = Mathf.Abs(end.x - start.x) / CellWidth + 1;
        var dy = Mathf.Abs(end.y - start.y) / CellWidth + 1;
        var dz = Mathf.Abs(end.z - start.z) / CellWidth + 1;
        
        dimensions = new Vector3(dx, dy, dz);
        
        grid = new Dictionary<Vector3, Cell>();
        MakeGrid();
    }

    private void MakeGrid()
    {
        foreach (var pos in Util.Range3D(new Vector3(), dimensions, CellWidth))
        {
            var gopos = (pos * CellWidth) + origin;
            var go = Instantiate(CellPrefab, gopos, Quaternion.identity);
            go.transform.localScale = scale;
            go.transform.parent = transform;
            go.GetComponent<BoxCollider>().size = scale;
            grid[pos] = go.GetComponent<Cell>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time+CycleTime);
            Iterate();
        }
    }

    public void Iterate()
    {

        foreach (var kvp in grid)
        {
            var alive = Surrounding(kvp.Key).Count(i => i.State == Util.CellStateEnum.Alive);
            kvp.Value.UpdateNeighbors(alive);
        }

    }

    private IEnumerable<Cell> Surrounding(Vector3 pos)
    {
        return from c in Util.Surrounding(pos) where c != pos && grid.ContainsKey(c) select grid[c];
    }
}
