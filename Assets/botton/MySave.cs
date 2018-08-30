using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class MySave : MonoBehaviour {
    private static int savenum = 1;

    public void MyClick()
    {
        Debug.Log("Save");

        //ScreenCapture.CaptureScreenshot(Application.dataPath + "/savedata.PNG");

        if (PaintController.drawflag) {
            //start
            Texture2D tex = PaintController.saveTexture;

            byte[] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

            //MyCanvas.SetInteractive("Button2", false);

            //string now = DateTime.Now.ToString("HHmmss");
            //File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + now + ".png", pngData);

            string savename = savenum.ToString();
            File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + savename + ".png", pngData);


            savenum++;
            if (savenum > 20)
            {
                savenum = 1;
            }
        }
        PaintController2.drawflag2 = false;
        PaintController.drawflag = false;

        PaintController2.mycolor2 = Color.black;
        PaintController.mycolor = Color.black;

        SceneManager.LoadScene("opening");
    }
}
