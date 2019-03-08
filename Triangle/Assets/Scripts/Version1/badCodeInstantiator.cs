using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badCodeInstantiator : MonoBehaviour
{
    public float frequencyInstanciate;
    public Color giveParentsThisColorForTheirKids;
    private int countInstanciations = 1;
    // private GameObject go; // all this making it dynamically in code is really just making it hard for sake learning more coding
    //a public field and prefab in there would be better
    //especially seeing we need picture and fetching it from a special folder is a bit tedious
    public GameObject containerPrefab;
    public Vector3 birthVelocity;

    // Start is called before the first frame update
    void Start()
    {

       // containerPrefab.AddComponent<badCodeParent>(giveParentsThisColorForTheirKids); // will need constructors
    }

    // Update is called once per frame
    void Update()
    {
        //this would be a coroutine
        
        if (Time.timeSinceLevelLoad > (countInstanciations+1) * frequencyInstanciate)
        {
            //this is so if we alter frequency during play it account for it
            countInstanciations = (int) Mathf.Floor(Time.timeSinceLevelLoad / frequencyInstanciate);


            GameObject container = GameObject.Instantiate(containerPrefab);
            container.GetComponent<Rigidbody2D>().velocity = birthVelocity;

        }
    }
}
