using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject CellPrefab;
    public float CycleTime;
    public Vector3 GridStart;
    public Vector3 GridEnd;
    public float CellWidth;


    private List<List<List<Cell>>> grid;


    // Use this for initialization
    private void Start()
    {
        MakeGrid(GridStart, GridEnd, CellWidth);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void Cycle()
    {
        
    }

    private void MakeGrid(Vector3 gridStart, Vector3 gridEnd, float cellWidth)
    {
        foreach (var line in makeLines(gridEnd, gridStart, cellWidth))
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
            SideX(start, end, step),
            SideY(start, end, step),
            SideZ(start, end, step)
        };
        foreach (var side in all)
        {
            foreach (var line in side)
            {
                yield return line;
            }
        }
    }

    private IEnumerable<List<Vector3>> SideX(Vector3 start, Vector3 end, float step)
    {
        return from y in Util.Range(start.y, end.y, step)
            from z in Util.Range(start.z, end.z, step)
            select new List<Vector3> {new Vector3(start.x, y, z), new Vector3(end.x, y, z)};
    }

    private IEnumerable<List<Vector3>> SideY(Vector3 start, Vector3 end, float step)
    {
        return from x in Util.Range(start.x, end.x, step)
            from z in Util.Range(start.z, end.z, step)
            select new List<Vector3> {new Vector3(x, start.y, z), new Vector3(x, end.y, z)};
    }
    private IEnumerable<List<Vector3>> SideZ(Vector3 start, Vector3 end, float step)
    {
        return from x in Util.Range(start.x, end.x, step)
            from y in Util.Range(start.y, end.y, step)
            select new List<Vector3> {new Vector3(x, y, start.z), new Vector3(x, y, end.z)};
    }


}
