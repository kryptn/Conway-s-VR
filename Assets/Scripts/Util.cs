using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    public static IEnumerable<float> Range(float min, float max, float step)
    {
        for (var i = 0; i < int.MaxValue; i++)
        {
            var value = min + step * i;
            if (value > max)
                break;
            yield return value;
        }
    }

}
