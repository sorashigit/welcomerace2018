using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Indexpos : MonoBehaviour
{

    [SerializeField]
    GameObject m_ProviderObject;

    LeapServiceProvider m_Provider;

    //static int framecount=0;

    [SerializeField]
    private GameObject m_object = null;

    //public static bool saveflag = true;

    //private static int savenum=1;

    void Start()
    {
        m_Provider = m_ProviderObject.GetComponent<LeapServiceProvider>();
    }


    void Update()
    {
        Frame frame = m_Provider.CurrentFrame;

        //keysave
        //if (Input.GetKey(KeyCode.S)&&saveflag==true)
        //{
        //    if (!PaintController.drawflag)
        //    {
        //        Debug.Log("draw");

        //    }
        //    else
        //    {
        //        Debug.Log("Save");

        //        //ScreenCapture.CaptureScreenshot(Application.dataPath + "/savedata.PNG");


        //        //start
        //        Texture2D tex = PaintController.saveTexture;

        //        byte[] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

        //        MyCanvas.SetInteractive("Button2", false);

        //        //string now = DateTime.Now.ToString("HHmmss");
        //        //File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + now + ".png", pngData);

        //        string savename = savenum.ToString();
        //        File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + savename + ".png", pngData);

        //        saveflag =false;

        //        savenum++;
        //        if (savenum > 20) {
        //            savenum = 1;
        //        }

        //        SceneManager.LoadScene("opening");

        //    }
        //}




        //framecount++;
        //if (framecount <= 5)
        //{
        //    return;
        //}
        //else {
        //    framecount = 0;
        //}

        //// 右手を取得する
        //Hand rightHand = null;
        //foreach (Hand hand in frame.Hands)
        //{
        //    if (hand.IsRight)
        //    {
        //        Debug.Log("find right hand");
        //        rightHand = hand;
        //        break;
        //    }
        //}
        ////左手取得
        //Hand leftHand = null;
        //foreach (Hand hand in frame.Hands)
        //{
        //    if (hand.IsLeft)
        //    {
        //        Debug.Log("find l hand");
        //        leftHand = hand;
        //        break;
        //    }
        //}
        //if (rightHand == null && leftHand == null)
        //{
        //    return;
        //}

        // 右手を取得する
        Hand rightHand = null;
        //左手取得
        Hand leftHand = null;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsRight)
            {
                Debug.Log("find right hand");
                rightHand = hand;
                break;
            }

            if (hand.IsLeft)
            {
                Debug.Log("find l hand");
                leftHand = hand;
                break;
            }

        }

        if (rightHand == null && leftHand == null)
        {
            return;
        }
        if (rightHand == null)
        {
            rightHand = leftHand;
        }

        if (rightHand != null)
        {
            if (rightHand.Fingers[0].IsExtended)
            {
                MyCanvas.SetInteractive("ButtonR1", false);
            }
            else
            {
                MyCanvas.SetInteractive("ButtonR1", true);
            }
            if (rightHand.Fingers[1].IsExtended)
            {
                MyCanvas.SetInteractive("ButtonR2", false);
            }
            else
            {
                MyCanvas.SetInteractive("ButtonR2", true);
            }
            if (rightHand.Fingers[2].IsExtended)
            {
                MyCanvas.SetInteractive("ButtonR3", false);
            }
            else
            {
                MyCanvas.SetInteractive("ButtonR3", true);
            }
            if (rightHand.Fingers[3].IsExtended)
            {
                MyCanvas.SetInteractive("ButtonR4", false);
            }
            else
            {
                MyCanvas.SetInteractive("ButtonR4", true);
            }
            if (rightHand.Fingers[4].IsExtended)
            {
                MyCanvas.SetInteractive("ButtonR5", false);
            }
            else
            {
                MyCanvas.SetInteractive("ButtonR5", true);
            }


            Vector3 touchScreenPosition = rightHand.StabilizedPalmPosition.ToVector3();//rightHand.PalmPosition.ToVector3(); //rightHand.Fingers[1].bones[3].NextJoint.ToVector3();



            //Debug.Log("x"+touchScreenPosition.x+"z"+ touchScreenPosition.z);

            //touchScreenPosition.x = (touchScreenPosition.x+0.1f)/0.2f * Screen.width;
            //touchScreenPosition.z = (touchScreenPosition.z-0.2f)/0.2f * Screen.height;


            //touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0f, Screen.width);
            //touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.z, 0f, Screen.height);
            ////touchScreenPosition.y = Screen.height - touchScreenPosition.y;

            //touchScreenPosition.z = 1.0f;

            //Camera gameCamera = Camera.main;
            //Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);


            //PaintController.myExt = rightHand.Fingers[0].IsExtended & rightHand.Fingers[1].IsExtended & rightHand.Fingers[2].IsExtended & rightHand.Fingers[3].IsExtended & rightHand.Fingers[4].IsExtended;
            if (Convert.ToInt32(rightHand.Fingers[0].IsExtended) + Convert.ToInt32(rightHand.Fingers[1].IsExtended) + Convert.ToInt32(rightHand.Fingers[2].IsExtended) + Convert.ToInt32(rightHand.Fingers[3].IsExtended) + Convert.ToInt32(rightHand.Fingers[4].IsExtended) <=2)
            {
                PaintController.myExt = true;
            }
            else {
                PaintController.myExt = false;
            }

            //右手どれか開き
            //Debug.Log(touchScreenPosition);
            m_object.transform.position = touchScreenPosition;//touchWorldPosition;
        }


        //if (leftHand != null && !(leftHand.Fingers[0].IsExtended || leftHand.Fingers[1].IsExtended || leftHand.Fingers[2].IsExtended || leftHand.Fingers[3].IsExtended || leftHand.Fingers[4].IsExtended))
        //{//左手全部閉じ
        //    PaintController.mycolor = Color.white;
        //    PaintController.paintsize = 8;
        //    MyCanvas.SetInteractive("Button", false);

        //}
        //else
        //{
        //    PaintController.mycolor = Color.black;
        //    PaintController.paintsize = 5;
        //    MyCanvas.SetInteractive("Button", true);
        //}

        //save
        //if (/*PaintController.drawflag &&*/ saveflag && leftHand!=null && (!(leftHand.Fingers[0].IsExtended) & leftHand.Fingers[1].IsExtended & leftHand.Fingers[2].IsExtended & !(leftHand.Fingers[3].IsExtended) & !(leftHand.Fingers[4].IsExtended))) {

        //    if (!PaintController.drawflag)
        //    {
        //        Debug.Log("draw");

        //    }
        //    else
        //    {
        //        Debug.Log("Save");

        //        //ScreenCapture.CaptureScreenshot(Application.dataPath + "/savedata.PNG");


        //        //start
        //        Texture2D tex = PaintController.saveTexture;

        //        byte[] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

        //        MyCanvas.SetInteractive("Button2", false);

        //        string now = DateTime.Now.ToString("HHmmss");
        //        File.WriteAllBytes("C:/Users/sens/Desktop/leapmotion_2017_3 _2/Assets/output_image/" + now + ".png", pngData);
        //        saveflag = false;
        //    }
        //}
        
    }
}
