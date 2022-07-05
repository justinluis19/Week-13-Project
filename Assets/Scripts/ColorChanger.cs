using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public MeshRenderer myRenderer;

    public Color anotherColor; // Allows you to control the color from the inspector

    //private Color newColor = new Color(0.5f, 0.2f, 0.4f, 1f); // Add new color on object

    private Color startColor;

    public float totalDuration;

    private float currentDuration;

    public Color[] newColors;

    private int colorIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START GAME");

        startColor =  myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Check whether current duration has met total duration
        // If it hasn't, run the code in the curly braces
        if (currentDuration < totalDuration)
        {
            // Get the amount of time passed relative to the total duration
            float changePercent = currentDuration / totalDuration;
            Debug.Log(changePercent);
            // Use the lerp function to get a Color between startColor and anotherColor
            // Pass in changePercent to set how far along the Lerp to get a Color from.
            myRenderer.material.color = Color.Lerp(startColor, newColors[colorIndex], changePercent);

            // Add Time.deltaTime to currentDuration every frame.
            currentDuration += Time.deltaTime;

        }
        // Else, reset currentDuration and increase colorIndex
        else
        {
            ++colorIndex;
            if (colorIndex >= newColors.Length)
            {
                colorIndex = 0;
            }

            currentDuration = 0f;
            startColor = myRenderer.material.color;
        }

        //myRenderer.material.color = anotherColor;
        
    }
}
