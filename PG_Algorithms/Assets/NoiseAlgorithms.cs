﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseAlgorithms : MonoBehaviour
{
    // Width and height of the texture in pixels
    public int pixWidth;
    public int pixHeight;

    // The origin of the sampled area in the plane
    public float xOrg;
    public float yOrg;

    // The number of cycles of the basic noise pattern that are repeated over the width and height of the texture
    public float scale = 1.0f;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
    }

    void CalcPerlinNoise()
    {
        // For each pixel in the texture
        float y = 0.0f;

        while(y < noiseTex.height)
        {
            float x = 0.0f;
            while(x < noiseTex.width)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }

        // Copy the pixel data to the texture and load it into the GPU
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "perlin")
        {
            CalcPerlinNoise();
        }
    }
}