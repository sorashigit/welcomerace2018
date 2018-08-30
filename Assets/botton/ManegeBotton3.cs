using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ManegeBotton3 : MonoBehaviour {
    public static Texture2D mytexture;

    public void MyClick()
    {
        Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        //MyCanvas.SetInteractive("Button", false);
        int num = UnityEngine.Random.Range(1, 4);
        BinaryReader bin = new BinaryReader(new FileStream("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/coloring_sample/" + num.ToString() + ".png", FileMode.Open, FileAccess.Read));
        byte[] rb = bin.ReadBytes((int)bin.BaseStream.Length);
        bin.Close();
        int pos = 16, width = 0, height = 0;
        for (int i = 0; i < 4; i++) width = width * 256 + rb[pos++];
        for (int i = 0; i < 4; i++) height = height * 256 + rb[pos++];
        mytexture = new Texture2D(width, height);
        mytexture.LoadImage(rb);

        SceneManager.LoadScene("coloring");

    }

}
