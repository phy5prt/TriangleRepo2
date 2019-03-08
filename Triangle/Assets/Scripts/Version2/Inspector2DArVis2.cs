
using System.Collections;

using UnityEngine;

[System.Serializable]
public class Inspector2DArVis2

  
   


//this is still and array of arrays
//we will proabably want it square so
//should add a tool tip





{

    [System.Serializable]
    public struct rowData
    //public class rowData
    {
        //[Tooltip("Array Lengths Should Match")]
        public Color[] row;
    }


    // [Tooltip("Array Lengths Should Match")]
    public rowData[] rows = new rowData[10]; //believe it needs to be initialised for editor to work


}
