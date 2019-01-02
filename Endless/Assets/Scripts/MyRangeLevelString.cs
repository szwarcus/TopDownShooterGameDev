using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRangeLevelString : PropertyAttribute
{
        public readonly int min;
        public readonly int max;
        public readonly int step;

        public MyRangeLevelString(int min, int max, int step)
        {
            this.min = min;
            this.max = max;
            this.step = step;
        }
}
