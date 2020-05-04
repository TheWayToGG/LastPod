using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;

    // todo remove from inspector
    [Range(0, 1)]
    [SerializeField]
    float movementFactor; // 0 for full stop, 1 for max speed

    Vector3 startingPosition;
    Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offSet = movementVector * movementFactor;
        transform.position = startingPosition + offSet;
    }
}
