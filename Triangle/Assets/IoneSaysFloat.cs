using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoneSaysFloat : MonoBehaviour
{
    // Start is called before the first frame update


     [SerializeField] bool myBool;
    private Rigidbody myRb;

    void Start()

    {
        myRb = this.gameObject.GetComponent<Rigidbody>();


            }

    // Update is called once per frame
    void Update()

       {
        myRb.isKinematic = myBool;
    }
}
