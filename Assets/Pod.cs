using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Accelerating!");
            rigidbody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rigidbody.AddRelativeTorque(0, 0, 0.1f);
            transform.Rotate(Vector3.forward);
            print("Rotating left!");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //rigidbody.AddRelativeTorque(0, 0, -0.1f);
            transform.Rotate(Vector3.back);
            print("Rotating right!");
        }
    }
}
