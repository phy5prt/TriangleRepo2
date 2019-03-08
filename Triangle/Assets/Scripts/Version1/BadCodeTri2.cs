using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadCodeTri2 : MonoBehaviour
{

    /*
     For a button to work you need the following in your scene

A button that is a child of a canvas object

The canvas object must have a GraphicRaycaster component

There must be an EventSystem object somewhere in your hierarchy.

Unity will build all this automatically if you create your button from the GameObject menu. But not if you add a button component manually.
     */


    public delegate void aDelegate();
    public aDelegate delegateToMe;

    // Start is called before the first frame update


    //because we cant use constructors instead lets just initialise script by turning it on on the gameobject

    public Color myColor; // just so triangle can be asked its color and ask its neighbours but surely the container will know

    void Start()
    {
        //need an error for if not given a color before activated

        //Debug.Log(this + " is turned on and active"); //i dont think it gets turned on when set up by parent

        //gameObject.GetComponent<SpriteRenderer>().color = myColor; // this could just be set by parent and remembered by them
        gameObject.GetComponent<Image>().color = myColor;
        //triangle doesnt really need it
    }

    // Update is called once per frame
    void Update()
    {
        //i am deriving from monobehaviour

    }
    /*
    public void wellInowIWasClicked() {
        Debug.Log("wellInowIWasClicked ******************************");
    }
    */

    //runDelegateMethod
    public void OnMouseDown ()   {

       // Debug.Log("Hey, I've been clicked I think this is my index: " + transform.GetSiblingIndex() + " Oh and this is my colour " + myColor); //will this return the index of the tri?
        delegateToMe();
       // Debug.Log("if assigned a delegate it should have ran");
    }
}
