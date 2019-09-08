﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZoom : MonoBehaviour
{
    public float scale;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float change = Input.mouseScrollDelta.y* scale * -1f;
        camera.orthographicSize += change;
    }
}
