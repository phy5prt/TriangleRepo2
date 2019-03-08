using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this should be named the gridSnapper
public class BadGrid : MonoBehaviour //i had a good idea how to do this then found https://www.youtube.com/watch?v=VBZFYGWvm4A so erm thats this!
{
    // Start is called before the first frame update

    public float size = 1f; // maybe there should be a grid visualiser script only for development
                            //and a gameManager static singleton, and it will hold the size - as we want this to be same for all objects
                            //we need a grid but also its bounds?

        //we would have size x and size y

    public int xCount, yCount, zCount;

    //at the momemnt they need to be multiples y .8 appart amd x point .4 appart
    //so we need a grid system of 
    

    void Start()
    {
        //make gizmo grid

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //thinking about singleresponsibility where should this go. also it needs to find nearest empty spot
    //to the collision ?? or to the triangle collided with, so should each triangle ask the parent hey what at my empty grid coords
    
        //an advantage of parent holding coordinate system it flipping the triangles wont need to be accounted for

    public Vector3 GetNNearestPointOnGrid(Vector3 position) {
        position -= transform.position; //zero our transform so solely relative

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.x / size); // maybe we wont need y it may be constant as we are in 2D
        int zCount = Mathf.RoundToInt(position.x / size);

        //build vector (you cant directly make them for reasons I assume are to do with quaternions - its not but i still like to blame them)

        Vector3 result = new Vector3(
            (float)xCount * size,
        (float)yCount * size,
        (float)zCount * size);

        result += transform.position;
        return result;

        
    }
    
}
