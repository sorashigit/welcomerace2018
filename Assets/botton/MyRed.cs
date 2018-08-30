using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyRed : MonoBehaviour {
    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        MyCanvas.SetInteractive("Buttonred", false);

        PaintController.mycolor = Color.red;
        PaintController2.mycolor2 = Color.red;

        MyCanvas.SetInteractive("Buttoneraser", true);
        MyCanvas.SetInteractive("Buttonblack", true);
        MyCanvas.SetInteractive("Buttonblue", true);
        MyCanvas.SetInteractive("Buttonyellow", true);
        MyCanvas.SetInteractive("Buttonsave", true);
        MyCanvas.SetInteractive("Buttonquit", true);
    }
}
