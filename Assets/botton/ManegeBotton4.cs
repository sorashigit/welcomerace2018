﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegeBotton4 : MonoBehaviour {

    public void MyClick()
    {
        Debug.Log("Button click!");
        // 非表示にする
        //gameObject.SetActive(false);
        //MyCanvas.SetInteractive("Button", false);

        SceneManager.LoadScene("show2");

    }
}
