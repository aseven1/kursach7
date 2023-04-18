using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageOpacityChanger : MonoBehaviour
{
    // Start is called before the first frame update
public Image image;
    public float opacityChangeInterval = 2.0f;
    public float minOpacity = 0.2f;
    public float maxOpacity = 1.0f;

    private float timeSinceLastChange;
    private bool isIncreasingOpacity;

    void Start()
    {
        timeSinceLastChange = opacityChangeInterval;
        isIncreasingOpacity = false;
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        if (timeSinceLastChange >= opacityChangeInterval)
        {
            float opacity = image.color.a;
            
            if (isIncreasingOpacity)
            {
                opacity += 0.1f;
                if (opacity >= maxOpacity)
                {
                    opacity = maxOpacity;
                    isIncreasingOpacity = false;
                }
            }
            else
            {
                opacity -= 0.1f;
                if (opacity <= minOpacity)
                {
                    opacity = minOpacity;
                    isIncreasingOpacity = true;
                }
            }

            Color newColor = image.color;
            newColor.a = opacity;
            image.color = newColor;

            timeSinceLastChange = 0.0f;
        }
    }
}