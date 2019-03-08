using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badCodeParent : MonoBehaviour
{
    public GameObject uncoloredTri, coloredTri;
   
    // Start is called before the first frame update
    public badCodeParent(Color triColor) {

      
      // coloredTri = GameObject.Instantiate(uncoloredTri).AddComponent<badCodeTri(triColor)>(); // ah ha this is interesting 
        //you cannot add a script that takes constructors dynammically
        //We need a factory pattern
        //or to cheat and sit the scripts on prefabs
        //great I knew this design would result good code to be necessary
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
