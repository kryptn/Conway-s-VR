using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject config;
    public GameObject LinePrefab;
    private Vector3 GridStart;
    private Vector3 GridStop;
    private float CellWidth;

    // Use this for initialization
    private void Start()
    {
        var configObj = config.GetComponent<LifeConfig>();
        GridStart = configObj.GridStart;
        GridStop = configObj.GridStop;
        CellWidth = configObj.CellWidth;

        MakeGrid(GridStart, GridStop, CellWidth);
    }

    private void MakeGrid(Vector3 gridStart, Vector3 gridStop, float cellWidth)
    {
        foreach (var line in makeLines(gridStop, gridStart, cellWidth))
        {
            var go = Instantiate(LinePrefab);
            go.GetComponent<LineRenderer>().SetPositions(line.ToArray());
            go.transform.parent = transform;
        }
    }

    private IEnumerable<List<Vector3>> makeLines(Vector3 start, Vector3 end, float step)
    {
        var all = new List<IEnumerable<List<Vector3>>>
        {
            Util.SideX(start, end, step),
            Util.SideY(start, end, step),
            Util.SideZ(start, end, step)
        };
        foreach (var side in all)
        {
            foreach (var line in side)
                yield return line;
        }
    }
}
