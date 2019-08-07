using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomHeight : MonoBehaviour
{
    public GameObject ourCube;
    public float cubeWidth = 10.0f;
    public float cubeDepth = 10.0f;

    private float acquiredHeight;

    // Start is called before the first frame update
    void Start()
    {
        // give cube random height on creation
        // acquiredHeight = Random.Range(1.0f, 30.0f);

        /*
        ourCube.transform.localScale = new Vector3
            (
            cubeWidth,
            acquiredHeight,
            cubeDepth
            );
        */

        // adjust base of cube to position y = 0


        /*
        ourCube.transform.position = new Vector3
            (
            0,
            ourCube.transform.position.y + (acquiredHeight / 2),
            75
            );
            */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
