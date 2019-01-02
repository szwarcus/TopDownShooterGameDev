using System.Collections;
using UnityEngine;

public class MyRangeAttribute : PropertyAttribute
{
    public readonly float min;
    public readonly float max;
    public readonly float step;

    public MyRangeAttribute(float min, float max, float step)
    {
        this.min = min;
        this.max = max;
        this.step = step;
    }
}

