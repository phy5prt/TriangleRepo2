using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTriClusterAr : MonoBehaviour
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
    public float spin; 
    public GameObject uncoloredTri;
    
    public TheEnum[,] badTriDataTC, gizmoLocations;
    public int gizmoExtension = 4;
    public float gizmoSize = 0.1f;
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
        {
            ship = gameObject.GetComponent<BadShip>();
            ship.analyseChildArrangementAndDelegateMethods(); //ship shouldnt do this cluster or a script always with cluster should
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeSizeOFTriCluster(Color[,] thisObjectsColorAr, Color[,] collidingObject)
    {
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

    private void SetUpMyTri( TheEnum[,] triDataSet)
    {

        for (int i = 0; i < triDataSet.GetLength(0); i++)
        {
            for (int j = 0; j < triDataSet.GetLength(1); j++)

            {
                if ((triDataSet[i, j] == TheEnum.space) || (triDataSet[i, j] == TheEnum.edge))//I need a reference to the original enum
                {
                    Debug.Log("No Colour assigned so not instantiating this array element");
                    continue;
                } //currently untested

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
                newTriScript.myColor = EnumToColor(triDataSet[i, j]);
                newTriScript.myColor.a = 1; //only reason i need to do this is coz i havent looked up how to update new prefabs

                newTriScript.enabled = true; // why enabled what does it do in start and update?



            }

        }


        //CreateCompositeRBSoChildrenMoveWithParent();




    }

    private void SetUpMyPhysics()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = birthVelocity;
        gameObject.GetComponent<Rigidbody2D>().AddTorque(spin);
    }

    private Color EnumToColor(TheEnum colorOnly)
    {

        switch (colorOnly)
        {
            case TheEnum.red: { return Color.red; }
            case TheEnum.blue: { return Color.blue; }
            case TheEnum.green: { return Color.green; }
            default: { Debug.LogWarning("I should of been given a colour as an Enum but I got " + colorOnly); return Color.white; }

        }
    }


    //gizmos
    //I dont want this to run until everything else is calculated
    //could have a cororutine in
    //private void OnDrawGizmos()  //constant gizmos

    //a gizmo showing the edge triangle spaces <- needs a rule like the flip one like
    //so if ran the logic that every time you place a triangle you set its edges and they arnt applied or are overwritten
    //if it is a colour
    //just need to add the indexes (not the adjustment) if odd check row+1 row x-1 and column -1


    //the space
    //the colours



//we have gizmos in the wrong place
//will be fixed a bit with world unit fix
//we have wrong assigned colours - because were out 90degrees just uncomment original code and comment new code for apply the array when we rotate game
//maybe due to game being out 90 degrees at moment

        //think it draws per frame
        //may need some help with taking parent rotation
    private void OnDrawGizmos() //Selected() //gizmos when selected
    {
        // Gizmos.DrawWireMesh(); - might be cool to have a mesh too

        //draw cube at the parent origin
        Gizmos.color = Color.white;
        Gizmos.DrawCube(this.transform.position, new Vector3(1, 1, 1) * 2 * gizmoSize); // this should mark the parents 0,0 and centre of mass

        //make a bigger array for surrounding space around the triangle array
        //fill it with space
        gizmoLocations = new TheEnum[(badTriDataTC.GetLength(0) + 2 * gizmoExtension), (badTriDataTC.GetLength(1) + 2 * gizmoExtension)];
        for (int i = 0; i < gizmoLocations.GetLength(0); i++)
        { for (int j = 0; j < gizmoLocations.GetLength(1); j++) {
                gizmoLocations[i, j] = TheEnum.space; } }
        // foreach (TheEnum gizmoType in gizmoLocations){ gizmoType = TheEnum.space; } // cant use foreach



        //this section needs checking over with fresh eyes for where gizmoExtension should shouldnt be TODO


        //here i am gonna look through the tri array at the points that will replace me
        //and update my array
        for (int i = gizmoExtension; i < gizmoLocations.GetLength(0) - gizmoExtension; i++)
        {
            for (int j = gizmoExtension; j < gizmoLocations.GetLength(1) - gizmoExtension; j++)

            {
                //apply the color space or edge to the inside of the gizmo array
                gizmoLocations[i, j] = badTriDataTC[i - gizmoExtension, j - gizmoExtension];

                //if it is a color check and apply edge locations
                if ((gizmoLocations[i, j] == TheEnum.red) || (gizmoLocations[i, j] == TheEnum.blue) || (gizmoLocations[i, j] == TheEnum.green))

                {
                    //check the up and down locations
                    //this may fall appart if we havent made the triangles in the right rotation yet

                    //only replace space with an edge not a color
                   // if (gizmoLocations[i, j - 1] == TheEnum.space) { gizmoLocations[i, j - 1] = TheEnum.edge; }
                   // if (gizmoLocations[i, j + 1] == TheEnum.space) { gizmoLocations[i, j + 1] = TheEnum.edge; }

                    if (gizmoLocations[i - 1, j] == TheEnum.space) { gizmoLocations[i - 1, j] = TheEnum.edge; }
                    if (gizmoLocations[i + 1, j] == TheEnum.space) { gizmoLocations[i + 1, j] = TheEnum.edge; }
                    //need to know orientation so know where to look for edges
                    //Im not accounting for gizmoExtension altering this because we cancel it about
                    //if even check forward and vice versa
                    //not taking off extension because its taken away twice so will not effect the even oddness ???
                    //if it is even then check left else right
                    if (!((i + j) % 2 < 0.1f))
                       // if (((i + j) % 2 < 0.1f))
                        {
                       // if (gizmoLocations[i - 1, j] == TheEnum.space) { gizmoLocations[i - 1, j] = TheEnum.edge; }
                        if (gizmoLocations[i, j - 1] == TheEnum.space) { gizmoLocations[i, j - 1] = TheEnum.edge; }
                    }
                    else
                    {
                       // if (gizmoLocations[i + 1, j] == TheEnum.space) { gizmoLocations[i + 1, j] = TheEnum.edge; }
                        if (gizmoLocations[i, j + 1] == TheEnum.space) { gizmoLocations[i, j + 1] = TheEnum.edge; }
                    }
                }


            }
        }


        //this for will place the new array
        for (int i = 0; i < gizmoLocations.GetLength(0); i++)
        {
            for (int j = 0; j < gizmoLocations.GetLength(1); j++)

            {

                //they seem space right but some distance from the origin of parent but so is the tricluster itself
                float myX = (float)i - gizmoExtension;
                float myY = (float)j - gizmoExtension;


                //this makes it relative to this TriCluster Transform but surely can do that in the instantiation
                Vector3 position = new Vector3((myX + this.gameObject.transform.position.x), (myY + this.gameObject.transform.position.y), (this.gameObject.transform.position.z));
               
                //without the add it doesnt seem to move with parent, so it most constantly draw!
                // Vector3 position = new Vector3((myX), (myY), (this.gameObject.transform.position.z));


                //this scales it but we shouldnt need this because we should set the gamespace right
                float myXScaled = position.x * scaleMultiplierX;
                float myYScaled = position.y * scaleMultiplierY;
                Vector3 positionUnorientatedButScaledAndRelative = new Vector3(myXScaled, myYScaled, position.z); //bad nammed put instages

                // if this method isnt run inline should put both in method
                Gizmos.color = getGizmoColor(gizmoLocations[i, j]);
                Gizmos.DrawSphere(positionUnorientatedButScaledAndRelative, gizmoSize);







            }

        }
    }


    //CreateCompositeRBSoChildrenMoveWithParent();
    private Color getGizmoColor(TheEnum whatsAtLocation) {

        switch (whatsAtLocation)
        {
            case TheEnum.red: { return Color.red; }
            case TheEnum.blue: { return Color.blue; }
            case TheEnum.green: { return Color.green; }
            case TheEnum.edge: { return Color.white; }
            case TheEnum.space: { return Color.cyan; }


            default: { Debug.LogWarning("I should of been given a Enum but I got " + whatsAtLocation); return Color.white; }

        }



    }






}
