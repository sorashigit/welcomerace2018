using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyEraser : MonoBehaviour {
    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        MyCanvas.SetInteractive("Buttoneraser", false);

        PaintController.mycolor = Color.white;
        PaintController2.mycolor2 = Color.white;

        MyCanvas.SetInteractive("Buttonblack", true);
        MyCanvas.SetInteractive("Buttonred", true);
        MyCanvas.SetInteractive("Buttonblue", true);
        MyCanvas.SetInteractive("Buttonyellow", true);
        MyCanvas.SetInteractive("Buttonsave", true);
        MyCanvas.SetInteractive("Buttonquit", true);
    }
}
