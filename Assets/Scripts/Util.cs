using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Util : MonoBehaviour {

    public enum CellStateEnum
    {
        Dead,
        Alive
    };

    public static IEnumerable<float> Range(float min, float max, float step)
    {
        for (var i = 0; i < int.MaxValue; i++)
        {
            var value = min + step * i;
            if (value >= max)
                break;
            yield return value;
        }
    }

    public static IEnumerable<Vector3> Range3D(Vector3 start, Vector3 end, float step)
    {
        var xdir = end.x > start.x ? 1 : -1;
        var ydir = end.y > start.y ? 1 : -1;
        var zdir = end.z > start.z ? 1 : -1;

        return from x in Range(start.x, end.x, xdir)
            from y in Range(start.y, end.y, ydir)
            from z in Range(start.z, end.z, zdir)
            select new Vector3(x, y, z);
    }

    public static IEnumerable<List<Vector3>> SideX(Vector3 start, Vector3 end, float step)
    {
        return from y in Range(start.y, end.y, step)
               from z in Range(start.z, end.z, step)
               select new List<Vector3> { new Vector3(start.x, y, z), new Vector3(end.x, y, z) };
    }

    public static IEnumerable<List<Vector3>> SideY(Vector3 start, Vector3 end, float step)
    {
        return from x in Range(start.x, end.x, step)
               from z in Range(start.z, end.z, step)
               select new List<Vector3> { new Vector3(x, start.y, z), new Vector3(x, end.y, z) };
    }

    public static IEnumerable<List<Vector3>> SideZ(Vector3 start, Vector3 end, float step)
    {
        return from x in Range(start.x, end.x, step)
               from y in Range(start.y, end.y, step)
               select new List<Vector3> { new Vector3(x, y, start.z), new Vector3(x, y, end.z) };
    }

    public static int Interval(float start, float end, float step)
    {
        return Mathf.FloorToInt(Mathf.Abs(start - end) / step);
    }

    public static IEnumerable<Vector3> Surrounding(Vector3 pos)
    {

        var offset = new List<float> {-1, 0, 1};
        return from x in offset from y in offset from z in offset select new Vector3(x, y, z) + pos;
    }

}
