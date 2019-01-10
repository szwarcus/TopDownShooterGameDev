using UnityEngine;
using System.Collections;
 
[System.Serializable]
public class MyArrayLayout10
{
    [System.Serializable]
    public struct rowData{
        public int[] row;
    }
    
    public rowData[] rows = new rowData[10];
}
