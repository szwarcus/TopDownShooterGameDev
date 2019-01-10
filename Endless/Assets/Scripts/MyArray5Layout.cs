using UnityEngine;
using System.Collections;

[System.Serializable]
public class MyArray5Layout
{
    [System.Serializable]
    public struct rowData
    {
        public int[] row;
    }

    public rowData[] rows = new rowData[5];
}
