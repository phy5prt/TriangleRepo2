using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTriData : MonoBehaviour
{

    public Color myColor;
    public Vector3 posRelParent; //may need to be local position or position later
    


    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setUpData(Vector3 setMyRelParent, Color setMyColor) {
        myColor = setMyColor;
        posRelParent = setMyRelParent;
    }
}
