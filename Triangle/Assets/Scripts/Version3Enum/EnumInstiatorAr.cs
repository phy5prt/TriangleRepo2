using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumInstiatorAr : MonoBehaviour
{
    //https://stackoverflow.com/questions/14186873/whats-the-best-practice-to-code-shared-enums-between-classes


    public bool makeShip = false;
    public float frequencyInstanciate;
    private int countInstanciations = 1;

    [Tooltip("give me a container prefab that takes my datalist")]
    public GameObject containerPrefab;


    public Vector3 birthVelocity;
    public float birthSpin; // not applied yet

    /*
     
        What I need
A 2d (so location is x y coords) collection of triangle info (possibly just colour)
The ability to replace colours in existing collection
The ability to know which are the “edge” empty spaces around colours (could be a seperate list)
To be able to add triangles on top bottom left right without changing their position in the collection e.g if at -1-1 there is a collision and a triangle joins  - suggesting an index offset
I want to know the squared off space  the triangles take up then have 1 triangle border of edge locations joining them, and a 5 triangle distance of empty space around for gizmos to fill
It would be cool to do it not square like a jagged array but looping through could get messy
Disadvantage of an array is we need to make a new one every time
List wouldnt shuffle everything along in the right way when adding in to the left and right unless managed
A list of lists like jagged array could work maybe some effort to maintain it being square
Need X,Y int offset when using indexes for positioning transforms for if grow triangles into the minus positions

Is using index as transfrom because transform can have negative X Y starting to be bad because we could just store the coords
Or is the advantage of looping in order useful
We do need them in order for later for calculating formations
     */

    //cant see in inspectorwhen public
    //2d arrays not serialazable in the inspector so we will need a fix 
    //if instead of color it is an array of a custom class it may work - http://realtime-computer-graphics.blogspot.com/2016/07/unity3d-show-multidimensional-array-in.html
    //it could contain maybe the word red green blue edge space or something


    //this is why weve made the serializeble version just need to put the two together

    [Tooltip("not hooked up or refined yet")]
    public Inspector2DArVis2 notWiredUpYet;











    

    //TheEnum has its own css file no class
    public TheEnum[,] triDataEnumAr = new TheEnum[,] {   //next try edge and space
           { TheEnum.red,TheEnum.blue },
            { TheEnum.blue,TheEnum.blue},
            { TheEnum.blue, TheEnum.blue },
            { TheEnum.green,TheEnum.green },
            { TheEnum.blue, TheEnum.blue },
            { TheEnum.blue, TheEnum.blue },
            { TheEnum.red,TheEnum.blue}

    };

    //how do we put empty space into the array
    //do we do it with a color to reprent empty

    // public Color[,] triDataAr = new Color[8, 2];   //code makes black ship when create a color array it has no null starting value

    void Start()
    {


    }


    void Update()
    {


        //this should be a coroutine


        if (makeShip)
        {
            makeShip = false;
            GameObject ship = makeContainer();
            ship.AddComponent<BadShip>();
            ship.GetComponent<BadShip>().enabled = true; // currently ship gives delegates to buttons and activating
                                                         //now it does so before triangles have been colored this is a problem now but TriCluster will have
                                                         //the role of delegating the methods later so the issue will resolve itself
                                                         //       Debug.Log("Blist ship enabled");


        }
        if (Time.timeSinceLevelLoad > (countInstanciations + 1) * frequencyInstanciate)
        {
            //this is so if we alter frequency during play it account for it
            countInstanciations = (int)Mathf.Floor(Time.timeSinceLevelLoad / frequencyInstanciate);
            makeContainer();




        }
    }
    public GameObject makeContainer()
    {
        //     Debug.Log(this + " is making a BList container");



        //ahh okay we want it placed at the instantiator but parented elsewhere 
        // Debug.Log("local " + this.gameObject.transform.localPosition + " to world " + this.gameObject.transform.localToWorldMatrix);

        GameObject container = GameObject.Instantiate(containerPrefab, this.transform.position, Quaternion.identity, this.gameObject.transform.parent);
        EnumTriClusterAr containerScript = container.GetComponent<EnumTriClusterAr>();

        containerScript.badTriDataTC = triDataEnumAr;//here give the instructions to containerScript how to build itself


        containerScript.birthVelocity = birthVelocity;
        containerScript.spin = birthSpin;
        // here give the container instructions how to rotate themselves

        containerScript.enabled = true;

        return container;
    }
}

