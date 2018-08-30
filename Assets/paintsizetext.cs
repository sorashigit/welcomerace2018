using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paintsizetext : MonoBehaviour
{
    private Text targetText; // <---- 追加2

    void Update()
    {
        this.targetText = this.GetComponent<Text>(); // <---- 追加3
        this.targetText.text = PaintController.paintsize.ToString();
    }

}
