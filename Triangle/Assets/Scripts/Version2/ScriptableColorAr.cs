using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//though this kind of works 
//side click scriptableColorAr -> create -> TriAr
//it doesnt display left to right the way rows and columns would go
//it isnt actually a 2d array its an array of arrays
//which is slightly different though converting one to the other as long as they are both same dimension is just [][] vs [,]

//we want it to display more like an array of vectors

    //could i use a vector array i dont need the vector 3 it is same as parent i dont need the vector1 or 2 as that will be the array
    //but only give me a 2d array 3 wide 
    //an array of vectors the array index is their x value, the vector x value is its y position if it were an array 
    // if we use a vector 4 we then have enough variables to make a colour the Vectors could just be a 1d array on inspector
    //then turned into 2d array by the method using the Vectors X and Y for position Z is known it is the parents and game is 2d
    //that leaves the third and forth vector value - if we start the colour in the right position changing just two color vectors should be enough
    //and we only need to change one value so if it is a vector 3, and the third  vector is 1 that means you change the third color vector to 1. - start all as black
    //or an enum could take that vector
    //this wouldnt make visualising it in the instpector much easier at all!

    //vector 4s not in columns

    


[CreateAssetMenu(fileName = "TriArrangement", menuName = "TriAr")]
public class ScriptableColorAr : ScriptableObject
{
    //[SerializeField] Color[,] triLayout =new Color[5,5];
    //[SerializeField] string workPlease = "stringy";

    //public int[] myInts;
    //public Color[] myUncomplicatedColors;
    //public int colorArLength = 5;
    
   // public List<Color> colorlist;
    [System.Serializable]
    public class myColorClassColumns {
       public Color[] colors = new Color[5];
    }

    public Vector4[] vector4;
    public Vector3[] vector3;

    public enum colorEnum  { r,g,b};
    public colorEnum[] enumAr;

    public myColorClassColumns[] myColors2D = new myColorClassColumns[5];
}
