using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Pngtex2 : MonoBehaviour {

    public GameObject texobject;
    public int pngnum;

    Texture2D PngToTex2D(string path)
    {
        BinaryReader bin = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read));
        byte[] rb = bin.ReadBytes((int)bin.BaseStream.Length);
        bin.Close();
        int pos = 16, width = 0, height = 0;
        for (int i = 0; i < 4; i++) width = width * 256 + rb[pos++];
        for (int i = 0; i < 4; i++) height = height * 256 + rb[pos++];
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(rb);
        return texture;
    }
    // Use this for initialization
    void Start () {

        string pngnumstring = pngnum.ToString();

        if (System.IO.File.Exists("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_coloring_image/" + pngnumstring + ".png") == true) {
            Texture2D texture = PngToTex2D("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_coloring_image/" + pngnumstring + ".png");
            texobject.GetComponent<Renderer>().material.mainTexture = texture;
        }
    }

}
