using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCodeInstantiator2 : MonoBehaviour
{

    //this feels a bit messy do we just inherit and alter eventually we should have a class/struct that defines 
    //what should be made with a itsAship bool, as if player completes a level may want their ship to be instantiated
    //next level keeping its layout

    public bool makeShip = false; 
    public float frequencyInstanciate;
   
    private int countInstanciations = 1;
   
    public GameObject containerPrefab;

    public Vector3 birthVelocity;

 
   // private BadTriData[] badTriDataForContainer = new BadTriData[10]; //cant get it to work
    [Tooltip("fill arrays and keep them same length ")]
    public Vector3[] vectorsForTriDataPos;
    [Tooltip("fill arrays and keep them same length ")]
    public Color[] colorsForTriData;


    // Start is called before the first frame update
    void Start()
    {

        // containerPrefab.AddComponent<badCodeParent>(giveParentsThisColorForTheirKids); // will need constructors
    }

    // Update is called once per frame
    void Update()
    {


        //this would be a coroutine
        // foreach(BadTriData badTriData in badTriDataForContainer) { badTriData = new BadTriData(); }
        //for (int i = 0; i<badTriDataForContainer.Length; i++)
        // {
        //       badTriDataForContainer[i].setUpData( vectorsForTriDataPos[i], colorsForTriData[i]);

        // }

        if (makeShip) {
            makeShip = false;
            GameObject ship = makeContainer();
            ship.AddComponent<BadShip>();
            ship.GetComponent<BadShip>().enabled = true;
            Debug.Log("bad ship enabled");


        }
        if (Time.timeSinceLevelLoad > (countInstanciations + 1) * frequencyInstanciate)
        {
            //this is so if we alter frequency during play it account for it
            countInstanciations = (int)Mathf.Floor(Time.timeSinceLevelLoad / frequencyInstanciate);
            makeContainer();




        }
    }
    public GameObject makeContainer() {
        Debug.Log(this + " is making a container");



        //ahh okay we want it placed at the instantiator but parented elsewhere 
        // Debug.Log("local " + this.gameObject.transform.localPosition + " to world " + this.gameObject.transform.localToWorldMatrix);
        
        GameObject container = GameObject.Instantiate(containerPrefab, this.transform.position, Quaternion.identity, this.gameObject.transform.parent);
        BadParent2 containerScript = container.GetComponent<BadParent2>();

        containerScript.positions = vectorsForTriDataPos; //is it something with this line
        containerScript.colors = colorsForTriData;


        containerScript.birthVelocity = birthVelocity;

        // containerScript.badTriData = badTriDataForContainer;

        containerScript.enabled = true;
        // container.GetComponent<Rigidbody2D>().velocity = birthVelocity; // should it set t pwn or have it set
        //if like a constructor they set themselves then cannot be forgot
        return container;
    }
}
