using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should be an abstract class
public class AbsTriangle : MonoBehaviour
{


    

//lets try always order rgb as a standard
//what i want to do here is give the method the ability to provide red green or blue
//so was thinking an enum into an array but then how do you set the enum by passing a parameter
//into the method?
//other options are a tool tip or 
    //public enum colorChoice {red, green, blue};     // i think getting it to be an enum would be useful later
    //or you can set indexers to be what you want so maybe just change array to have custom indexer
    public Color myColor;
   // public Color[] triColorAr = {Color.red, Color.green, Color.blue};

   // [Tooltip: "red green or blue"]
    public AbsTriangle(Color giveRGBColor) {

        //we are only using red green blue so we should have
        //some way of storing these colors
        //we could use a string
        //or a color array and then a enum to access it. ??? more readable

        //need a if to check its an RGB color
        myColor = giveRGBColor;
        gameObject.GetComponent<SpriteRenderer>().color = myColor;

    }
// Start is called before the first frame update
void Start()
    {
      //Have I been given my method if not tell parent to calculate it and delegate me a method
      //methods may not need to be delegate could just overload but delegating seems cleaner, though would have to be a list
      //as there isnt a limit on how many configurations a triangle could trigger
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //we could use onTrigger or on collision maybe collision because dont want them to pass into each other
    // private void OnTriggerEnter2D(Collider2D collision)    {   
    // }
    //we want the individual triangle to register the collision
    //but the two parents to experience the physical interaction
    //so when set of triangle a hit set of triangles b they hit and do not fly appart so they move as a whole
    //but we want to know which two triangles hit, and the one of the parent which side to stick the hitting triangle (which would rotate the who group object)
    //but if our grid maths is good we just need the information of where the collision is and the bigger parent just put the colliding triangle
    //in the nearest space and rotate the whole configuration about the triangle it is placing. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
