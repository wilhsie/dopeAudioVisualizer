﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour
{
    public GameObject ourTerrain;
    Renderer m_Renderer;

    void Start()
    {
        // Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();

        m_Renderer.material.color = Random.ColorHSV();
    }
}
