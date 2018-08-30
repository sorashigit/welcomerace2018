using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyYellow : MonoBehaviour {
    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        MyCanvas.SetInteractive("Buttonyellow", false);

        PaintController.mycolor = Color.yellow;
        PaintController2.mycolor2 = Color.yellow;

        MyCanvas.SetInteractive("Buttoneraser", true);
        MyCanvas.SetInteractive("Buttonblack", true);
        MyCanvas.SetInteractive("Buttonblue", true);
        MyCanvas.SetInteractive("Buttonred", true);
        MyCanvas.SetInteractive("Buttonsave", true);
        MyCanvas.SetInteractive("Buttonquit", true);
    }
}
