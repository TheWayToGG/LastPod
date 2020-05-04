using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(10f, 0f);
    [SerializeField] float period = 2f;

    float movementFactor; // 0 for not moved, 1 for fully moved.
    Vector3 startingPos;
    Vector3 offset;
    float cycles;
    float rawSinWave;

    const float tau = Mathf.PI * 2f; // about 6.28

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        
        cycles = Time.time / period;
        
        rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;
        offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}