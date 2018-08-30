using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBlack : MonoBehaviour {
    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        MyCanvas.SetInteractive("Buttonblack", false);

        PaintController.mycolor = Color.black;
        PaintController2.mycolor2 = Color.black;

        MyCanvas.SetInteractive("Buttoneraser", true);
        MyCanvas.SetInteractive("Buttonred", true);
        MyCanvas.SetInteractive("Buttonblue", true);
        MyCanvas.SetInteractive("Buttonyellow", true);
        MyCanvas.SetInteractive("Buttonsave", true);
        MyCanvas.SetInteractive("Buttonquit", true);


    }
}
