using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Rotating left!");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Rotating right!");
        }
    }
}
