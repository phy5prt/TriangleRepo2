using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadParent2 : MonoBehaviour
{

    //positioning she work on unity world unit
    /* we need to work out what world unit to pixel to do for sprites
     we need spacing to be measured with these units.  
     */


    public Vector3 birthVelocity;
    public GameObject uncoloredTri;
    // public BadTriData[] badTriData;
    // Start is called before the first frame update
    public Color[] colors;
    public Vector3[] positions;
   private float scaledX, scaleMultiplierX = 0.45f, scaledY, scaleMultiplierY = 0.85f ; //think 0.4 0.8 will be good when colliders sorted
 // public Vector3[] positionsScaledToTriDimensions; // maybe name wrong
    private BadGrid badGrid; // we want all the grids the same, then add our transform to offset
                             // so badGrid is kind of a reference and to provide gizmos to help design
                             //so should it be something other than just a class
                             //there is a grid component and an isometric one!

    private Vector3[] positionUnorientatedButScaledAndRelative;


    void Start() //maybe a set up method to replace constructor
    {
        Debug.Log(this + " is turned on and active");
        badGrid = gameObject.GetComponent<BadGrid>();

       
        positionUnorientatedButScaledAndRelative = new Vector3 [positions.Length];

        /*
        foreach (BadTriData data in badTriData) { 
        GameObject newTri = GameObject.Instantiate(uncoloredTri, data.posRelParent, Quaternion.identity);
            BadCodeTri2 newTriScript = newTri.GetComponent<BadCodeTri2>();
           newTriScript.myColor = data.myColor;
            newTriScript.enabled = true;




        }
        */
        for (int i = 0; i < colors.Length; i++)
        {
            //this should work fine because we would feed the code exact grid locations
            //but lets put in the grid anyway for seeing it work

            positions[i] = new Vector3((positions[i].x+this.gameObject.transform.position.x),(positions[i].y + this.gameObject.transform.position.y),(positions[i].z));   
         scaledX = positions[i].x * scaleMultiplierX;
          scaledY = positions[i].y * scaleMultiplierY;
            positionUnorientatedButScaledAndRelative[i] = new Vector3(scaledX,scaledY, positions[i].z); //bad nammed put instages

            

            GameObject newTri = GameObject.Instantiate(uncoloredTri, positionUnorientatedButScaledAndRelative[i], Quaternion.identity,this.transform);


            //do the if twice as will be a different inversion per line
            // trying to fix last pair of triangles not upside down
            //replace !=0 with >0.1f 
            //using original coord system ad it works so assume it rounding

            // if ((placePositionUnorientatedButScaled[i].x/scaleMultiplierX) % 2  < 0.1f) {
            if (Mathf.Abs(positions[i].x)  % 2 < 0.1f)
            {
                newTri.transform.localScale= new Vector3 ( newTri.transform.localScale.x, -1 * newTri.transform.localScale.y, newTri.transform.localScale.z);

                //invert triangle
                //rotation
                //or multiply scale x by -1?
            }
            if (Mathf.Abs(positions[i].y) % 2  < 0.1f) // doesnt always work probably due to rounding
            {
                newTri.transform.localScale = new Vector3(newTri.transform.localScale.x, -1 * newTri.transform.localScale.y, newTri.transform.localScale.z);
            }

                BadCodeTri2 newTriScript = newTri.GetComponent<BadCodeTri2>();
            newTriScript.myColor = colors[i];
            newTriScript.myColor.a = 1; //only reason i need to do this is coz i havent looked up how to update new prefabs

        
            newTriScript.enabled = true;

            //CreateCompositeRBSoChildrenMoveWithParent();

            gameObject.GetComponent<Rigidbody2D>().velocity = birthVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    
}
