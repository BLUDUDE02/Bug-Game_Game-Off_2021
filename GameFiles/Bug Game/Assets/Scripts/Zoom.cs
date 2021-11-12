using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    //public variables paremeters for Unity inpector inputs
    public float initialFOV;
    public float zoomInFOV;
    public float smooth;
    public bool shouldZoom;

    //private variables for script mod
    private float currentFOV;

    public Exit exit;

    // Use this for initialization
    void Start()
    {
        //set initial FOV at start
        Camera.main.orthographicSize = initialFOV;

    }

    // Update is called once per frame
    void Update()
    { 
        currentFOV = Camera.main.orthographicSize;

        if (exit.triggered == true && shouldZoom)
        {
            ChangeFOV();
            Debug.Log("EXIT!");
        }
    }

    //function to zoom in the FOV
    void ChangeFOV()
    {
        //check that current FOV is different than Zoomed
        if (currentFOV != zoomInFOV)
        {
            //check if current FOV is grater than the Zoomed in FOV input and increment the FOV smoothly
            if (currentFOV > zoomInFOV)
            {
                Camera.main.orthographicSize += (-smooth * Time.deltaTime);
            }
            else
            {
                //then current FOV gets to the same or smaller value than the Zoomed in input
                //set FOV as the Zoomed in input
                if (currentFOV >= zoomInFOV)
                {
                    Camera.main.orthographicSize = zoomInFOV;
                }
            }
        }
    }
}
