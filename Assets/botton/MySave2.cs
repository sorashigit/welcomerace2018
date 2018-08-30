using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class MySave2 : MonoBehaviour {
    private static int savenum2 = 1;

    public void MyClick()
    {
        Debug.Log("Save");

        //ScreenCapture.CaptureScreenshot(Application.dataPath + "/savedata.PNG");

        if (PaintController2.drawflag2)
        {
            //start
            Texture2D tex = PaintController2.saveTexture2;

            byte[] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

            //MyCanvas.SetInteractive("Button2", false);

            //string now = DateTime.Now.ToString("HHmmss");
            //File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + now + ".png", pngData);

            string savename = savenum2.ToString();
            File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_coloring_image/" + savename + ".png", pngData);


            savenum2++;
            if (savenum2 > 20)
            {
                savenum2 = 1;
            }
        }
        PaintController2.drawflag2 = false;
        PaintController.drawflag = false;
        PaintController2.mycolor2 = Color.black;
        PaintController.mycolor = Color.black;

       

        SceneManager.LoadScene("opening");
    }
}
