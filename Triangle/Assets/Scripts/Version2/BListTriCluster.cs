using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BListTriCluster : MonoBehaviour
{
    //positioning she work on unity world unit
    /* we need to work out what world unit to pixel to do for sprites
     we need spacing to be measured with these units.  
     */

    /*
     Also if we are destroying and instantiating all the time thats messy! - would lists have avoided this? We dont need to reinstantiate whole array just new bits?

     */

    //script doing to much
    //instantiating
    //delegating 
    //we want all triCluster objects to delegate yet we want scripts to do only so many things
    //is this reason for interface and abstract so we can have mini scripts - and make them necessary
    //yep"!


    public Vector3 birthVelocity;
    public float spin; // not implemented yet
    public GameObject uncoloredTri;
    public Color[,] badTriDataTC;
    private BadShip ship;

    //once world space is sorted this should be unnecessary
    private float scaleMultiplierX = 0.45f, scaleMultiplierY = 0.85f; //think 0.4 0.8 will be good when colliders sorted
                                                                      // public Vector3[] positionsScaledToTriDimensions; // maybe name wrong



    //these not need for initial instantiation
    //when there is a collision and make new array will set its zero
    //this will cause a shift on screen unless we either move the parent on screen at the same time we move the triangle cluster so it cancels
    //or when placing the triangles we adjust the index -> so the choice is adjust transfrom or index and index is better

    //How big should the array be - if we use arrays going to have to recreate everytime
    //We should zero it

    private int smallestXCoord, largestXCoord, smallestYCoord, largestYCoord;

    //the adjustment should be the amount we are moving all coords so sit at zero zero - we need them to because using indexes
    //should only be needed if adding triangles to the top? or the left. because they would be the negative indexes ->maybe its bottom and left
    private int indexToTransAdjustmentX = 0, indexToTransAdjustmentY = 0;


    void Start() //maybe a set up method to replace constructor
    {
      //  Debug.Log(this + " is turned on and active");
        //  badGrid = gameObject.GetComponent<BadGrid>();


        // positionUnorientatedButScaledAndRelative = new Vector3[positions.Length];


        SetUpMyTri(badTriDataTC);
        SetUpMyPhysics();


        if (gameObject.GetComponent<BadShip>() != null)
        { ship = gameObject.GetComponent<BadShip>();
            ship.analyseChildArrangementAndDelegateMethods(); //ship shouldnt do this cluster or a script always with cluster should
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeSizeOFTriCluster(Color[,] thisObjectsColorAr, Color[,] collidingObject) {
        //this would be run before setupmy tri when there is a collision
        //would like to use an opperator overload for it

        //the script will need to rotate the joining object about the triangle edge space nearest collision
        //make a new array to fit both maintaining their configurations
        //where there are overlaps deal with it be it explosions ...
        //create an index adjuster such that when the new object is made the original of the two  colliding sets is in the same position
        //so if triangle S was at 0,0 and now is at 1,1 then the adjustment for x and y is -1 so when the triangle is instantiated though its
        //array position has changed its world position hasnt

        //should then run SetUpMyTri with everything changed ready for setup

    }

    private void SetUpMyTri(Color[,] triDataSet) {

        for (int i = 0; i < triDataSet.GetLength(0); i++)
        {
            for (int j = 0; j < triDataSet.GetLength(1); j++)

            {
                if (triDataSet[i, j] == null) {
                    Debug.Log("No Colour assigned so not instantiating this array element");
                    continue; } //currently untested

                //alot of the code below should be replaceable with something that looks like this
                //once gamespace is right
                // GameObject newTri = GameObject.Instantiate(uncoloredTri, position(), Quaternion.identity, this.transform to local);

                //building coords from index
                //later will need to put in the adjuster
                float myX = (float)i;
                float myY = (float)j;


                //this makes it relative to this TriCluster Transform but surely can do that in the instantiation
                Vector3 position = new Vector3((myX + this.gameObject.transform.position.x), (myY + this.gameObject.transform.position.y), (this.gameObject.transform.position.z));

                //this scales it but we shouldnt need this because we should set the gamespace right
                float myXScaled = position.x * scaleMultiplierX;
                float myYScaled = position.y * scaleMultiplierY;
                Vector3 positionUnorientatedButScaledAndRelative = new Vector3(myXScaled, myYScaled, position.z); //bad nammed put instages



                GameObject newTri = GameObject.Instantiate(uncoloredTri, positionUnorientatedButScaledAndRelative, Quaternion.identity, this.transform);

                //invert triangles in positions needing inverting
                //this step could trip us up if we are not reinstantiating whole object if there is an impact but could be okay

                //this flips even triangles upsidedown if we use ! could do opposite
                if ((i + j) % 2 < 0.1f)


                {
                    newTri.transform.localScale = new Vector3(newTri.transform.localScale.x, -1 * newTri.transform.localScale.y, newTri.transform.localScale.z);

                }

                BadCodeTri2 newTriScript = newTri.GetComponent<BadCodeTri2>();
                newTriScript.myColor = triDataSet[i,j];
                newTriScript.myColor.a = 1; //only reason i need to do this is coz i havent looked up how to update new prefabs

                newTriScript.enabled = true; // why enabled what does it do in start and update?



            }
            
        }
        

        //CreateCompositeRBSoChildrenMoveWithParent();

        
       

    }

    private void SetUpMyPhysics() { 
    gameObject.GetComponent<Rigidbody2D>().velocity = birthVelocity;
        gameObject.GetComponent<Rigidbody2D>().AddTorque(spin);
    }
   

}