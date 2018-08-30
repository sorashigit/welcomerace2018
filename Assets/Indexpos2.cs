using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Indexpos2 : MonoBehaviour
{

    [SerializeField]
    GameObject m_ProviderObject;

    LeapServiceProvider m_Provider;

    

    //static int framecount=0;

    [SerializeField]
    private GameObject m_object = null;
    public static bool coloringfirsttime=true;
    //public static bool saveflag2 = true;

    //private static int savenum2=1;

    void Start()
    {
        m_Provider = m_ProviderObject.GetComponent<LeapServiceProvider>();
        
    }


    void Update()
    {
        Frame frame = m_Provider.CurrentFrame;


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
        if (rightHand == null) {
             rightHand= leftHand;
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



            //PaintController2.myExt2 = rightHand.Fingers[0].IsExtended & rightHand.Fingers[1].IsExtended & rightHand.Fingers[2].IsExtended & rightHand.Fingers[3].IsExtended & rightHand.Fingers[4].IsExtended;
            if (Convert.ToInt32(rightHand.Fingers[0].IsExtended) + Convert.ToInt32(rightHand.Fingers[1].IsExtended) + Convert.ToInt32(rightHand.Fingers[2].IsExtended) + Convert.ToInt32(rightHand.Fingers[3].IsExtended) + Convert.ToInt32(rightHand.Fingers[4].IsExtended) <=2)
            {
                PaintController2.myExt2 = true;
            }
            else
            {
                PaintController2.myExt2 = false;
            }

            //右手どれか開き
            //Debug.Log(touchScreenPosition);
            m_object.transform.position = touchScreenPosition;//touchWorldPosition;
        }

        
    }
}
