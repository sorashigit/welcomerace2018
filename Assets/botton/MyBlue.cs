using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBlue : MonoBehaviour {
    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        MyCanvas.SetInteractive("Buttonblue", false);

        PaintController.mycolor = Color.blue;
        PaintController2.mycolor2 = Color.blue;

        MyCanvas.SetInteractive("Buttoneraser", true);
        MyCanvas.SetInteractive("Buttonred", true);
        MyCanvas.SetInteractive("Buttonblack", true);
        MyCanvas.SetInteractive("Buttonyellow", true);
        MyCanvas.SetInteractive("Buttonsave", true);
        MyCanvas.SetInteractive("Buttonquit", true);
    }
}
