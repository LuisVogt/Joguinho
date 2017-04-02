﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public Texture2D fadeoutTexture;
    public float fadeSpeed;
    public int drawDepth = -1000;
    public float alpha = 1;
    private int fadeDir = -1;

    void OnGui()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }

}
