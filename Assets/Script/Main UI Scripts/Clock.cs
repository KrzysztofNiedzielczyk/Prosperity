﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = Time.time.ToString("F0");
    }
}
