using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadShip : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D shipRB;
    public float thrust = 1f; // so i think all the methods than can delegated should be assigned
                              //from a script holding them, maybe even an array of them enumerated and we can have a design doc image


    //shoudl eb in tricluster
    // public Color isThisTheColorWereLookingFor = Color.red;


    //      - code excection order, default white is 1,1,1,1 We should always default .5,.5,.5,.5 
    //if checking by colour, rounding error occurs so compare like this - color.r vs Color.red.r 
    //and use Approximately(float a, float b);

    void Start()
    {

        //need to look up best way to send it up
        //whether it should be kinematic ... if it isnt its going to need some axis locking 

        shipRB = gameObject.GetComponent<Rigidbody2D>();
            shipRB.gravityScale = -0.01f;
     

         // needs to only run once all tris there

        //when we have cinemachine we need to tell the camera to follow it.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this would be replaced with a direction from the triangle tip in centre of circle out of its base
    //but our current coordinate system is 90 degrees out so ...

        //hmm this is messy too :(
    public void methodMoveLeft() {
        Debug.Log("delegate method move left triggered");
       // Debug.Log(shipRB);
        bool left = true;
        if (left) {
            shipRB.velocity += Vector2.left * thrust;
        }
        else { shipRB.velocity += Vector2.right * thrust; }
        // else { shipRB.velocity = Vector3.right * thrust; } //this works but changing so get concescutive boosts

    }

    public void methodMoveRight()
    {
        Debug.Log("delegate method move right triggered");
       // Debug.Log(shipRB);
        bool left = false;
        if (left)
        {
            shipRB.velocity += Vector2.left * thrust;
        }
        else { shipRB.velocity += Vector2.right * thrust; }

    }

    //should take information in method
    public void analyseChildArrangementAndDelegateMethods() {   //this code must be running before triangle has their color
        //gonna need something clever and will take in a struct or class describing the arrangement
        //but for now

        //replace below code with code that checks the layout
        //also put it in a script for that ship script
        //either on tri cluster or on one that always goes with it

        BadCodeTri2[] childScriptArray = gameObject.GetComponentsInChildren<BadCodeTri2>();
        // Debug.Log("childscriptarray is this long " + childScriptArray.Length);

        //this is a mess we dont want to use literal colour we want the name colour maybe an enum or string
        //if not get the color wrong get a mess

        foreach (BadCodeTri2 triangle in childScriptArray) {
           
            //  Debug.Log("is this triangle red " + (triangle.gameObject.GetComponent<SpriteRenderer>().color.r == Color.red.r)); if (triangle.gameObject.GetComponent<SpriteRenderer>().color.r == Color.red.r) {
            // Debug.Log("is this triangle red " + (triangle.gameObject.GetComponent<Image>().color == Color.red));
            // Debug.Log("So ... " + triangle.gameObject.GetComponent<Image>().color + "  " + Color.red);
         

            if (triangle.myColor == Color.red)
            {
                //as not calculating the arrangement of tris yet this must have to do
                if (triangle.gameObject.transform.position.x < 2)
                {


                    Debug.Log("delegate move left assigned in bad ship code");
                    triangle.delegateToMe = methodMoveLeft;
                }
                else
                {
                    Debug.Log("delegate assigned move right in bad ship code");
                    triangle.delegateToMe = methodMoveRight;
                }


            }
            else {
                Debug.Log("wasn't equal so debug.Log given as deligate");
                triangle.delegateToMe = IDoNothing;
            }
        }

    }
    public void IDoNothing() { Debug.Log("I do nothing when clicked because im not special"); }
}
