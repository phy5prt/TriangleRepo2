using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should be abstract but isnt (though really just needs to be inherrited from?)
public class AbsTriContainer : MonoBehaviour
{

    /*

    //TriData will be a struct that contains the data needed to make triangles
    //Which maybe is just colour
    //it will also include data for their arrangement of positions within the container
    //If the struct is wrong then will have triangles all over so 

        //nope one triangle different colors 
   // public GameObject redTri, blueTri, GreenTri;
   // public GameObject[] myChildren;

    public class TriData {
        public Color triColor;
        public Vector3 location;

    } // delete this asap
    public GameObject blankTrianglePrefab;
    // ideally we would like to make the script of tri inst the prefab
    //this may require a scriptable object or a special material folder with the address
    //in script so it can find its art

    public AbsTriContainer(TriData[] startingTris, Vector3 velocity) {

        //check starting tris is legitimage
        //they all touch
        //they all have coordinates that fit this grid. 
        //put if here
        

        if (true) {

            foreach (TriData triData in startingTris)

            //normally you would just instantiate the gameObject, but we want to instantiate it
            //and feed its script's constructor the details for it
            //though maybe not it only needs a colour so could just instantiate 1 of 3 colours of prefab
            //or one prefab with three colour images and the script tells it which to use on a method running


            {

                //it may be necessary to alter the location if instantiating does not make its location position relative to the parent
                //also if we made triangle 1 grid unit wide then triangles on an odd numbered x coordinate will need to be inverted
                //this would be done via either rotation or giving it a negative x scale. 

                //also it may automatically instantiate with this scripts GO as parent and its coordinates relitive to that



                GameObject newTri = Instantiate(blankTrianglePrefab(triData.triColor), triData.location, Quaternion.identity, this.gameObject};

            //or using a switch
            if (TriData.colour = red) {
                GameObject newTri = Instantiate(redTri);
                newTri.YourTriangleScript.GiveMeMyInfo(hereIsYourColour, hereIsyourlocation, .... );


                newTri..GetComponents<Rigidbody2D>().velocity = velocity;


            }


        }



        void Start()
        {
            //run a method to identify my kids, initiate any instant effects from bnoble arrangements
            //attribute them all there methods for if they are clicked

            organiseChildren();


        }

        // Update is called once per frame
        void Update()
        {

        }

    private void organiseChildren()
        { myChildren = GetComponentInChildren<TriScript>().gameObject;

            //calculate what methods they should all execute if clicked and give them to them

        }

   */
}
