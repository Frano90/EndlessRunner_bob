﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{ 
    public int resWidth = 1080; 
    public int resHeight = 1080;

    [SerializeField] private Camera snapCam;
    private bool takeHiResShot = false;
    private NativeShare shareTool;

    private void Awake()
    {
        shareTool = new NativeShare();
    }

    public static string ScreenShotName(int width, int height) {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png", 
            Application.dataPath, 
            width, height, 
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void TakeHiResShot() {
        takeHiResShot = true;
    }

    void LateUpdate() {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot) {
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            snapCam.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.ARGB32, false);
            snapCam.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            snapCam.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            Share(filename);
            takeHiResShot = false;
        }
    }

    private void Share(string path)
    {
        shareTool.SetTitle("ShareTest");
        shareTool.AddFile(path);
    }
}