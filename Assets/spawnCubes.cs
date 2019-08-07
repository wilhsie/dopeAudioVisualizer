using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour
{
    public GameObject ourCube;
    public AudioSource audioSource;
    public List<GameObject> cubes;
    public int spectrumFrequency;
    
    private float spawnSeconds = 0.375f; // spawn every # seconds
    private float counter; // counter - used for our timer
    private float timeElapsed; // time elapsed - used for our timer

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        counter = 0.0f;
        spectrumFrequency = Random.Range(0, 128);
    }

    // Update is called once per frame
    void Update()
    {

        float[] spectrum = new float[128];

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        timeElapsed += Time.deltaTime;

        // if elapsed time minus counter is greater than spawn
        // seconds .. do something
        if (timeElapsed - counter > spawnSeconds)
        {
            // spawn cube
            GameObject instance = Instantiate(ourCube);

            // adjust scale and position of cube to match spectrum data
            Vector3 prevScale = instance.transform.localScale;

            // set these cubes to represent the lowest sampled frequencies
            prevScale.y = spectrum[spectrumFrequency] * 100.0f;

            // set scale of the cube we just created
            instance.transform.localScale = prevScale;

            // adjust height of cube to accommodate for increased scale
            Vector3 adjustedPosition = new Vector3(
                instance.transform.position.x,
                prevScale.y / 2,
                instance.transform.position.z);

            // set adjusted position to the cube we just created
            instance.transform.position = adjustedPosition;

            // add cube we just created to list of cubes
            cubes.Add(instance);

            // sync our counter with elapsed time to reset our timer
            counter = timeElapsed;
        }

        for (int i = 0; i < cubes.Count; i++)
        {
            /*
            Vector3 prevScale = cubes[i].transform.localScale;
            prevScale.y = spectrum[((int)Time.deltaTime % 128)] * 100.0f;

            cubes[i].transform.localScale = prevScale;

            cubes[i].transform.position = new Vector3(
                cubes[i].transform.position.x,
                (prevScale.y / 2),
                cubes[i].transform.position.z);
            */
            

            // destroy cube and remove from list of cubes on reaching z <= -10
            if (cubes[i].transform.position.z <= -10)
            {
                Destroy(cubes[i]);
                cubes.RemoveAt(i);
            }
        }
    }
}
