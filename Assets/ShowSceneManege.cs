using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
//using UnityEditor;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ShowSceneManege : MonoBehaviour {

    public void Update()
    {
        if (/*Input.GetKey(KeyCode.Return)*/Input.GetMouseButtonDown(0)| Input.GetMouseButtonDown(1)| Input.GetMouseButtonDown(2))
        {
            SceneManager.LoadScene("opening");
        }
    }
   
}
