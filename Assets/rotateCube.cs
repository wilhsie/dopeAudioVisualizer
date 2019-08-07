using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCube : MonoBehaviour
{
    public GameObject ourCube;

    public float terrainSpeed = 0.5f;
    private float rotateX, rotateY, rotateZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rotateX = 0;
        rotateY = 0;
        rotateZ = 0;

        ourCube.transform.Rotate(rotateX, rotateY, rotateZ, 0);
        ourCube.transform.position = new Vector3(ourCube.transform.position.x, ourCube.transform.position.y, ourCube.transform.position.z - terrainSpeed);


        /*
        if (ourCube.transform.position.z <= -10)
        {
            Destroy(ourCube);
        }
        */
    }
}
