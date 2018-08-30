using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyQuit : MonoBehaviour {
    

    public void MyClick()
    {
        //Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        //MyCanvas.SetInteractive("Button", false);
        PaintController2.drawflag2 = false;
        PaintController.drawflag = false;
        PaintController2.mycolor2 = Color.black;
        PaintController.mycolor = Color.black;

       

        SceneManager.LoadScene("opening");

    }
}
