using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MySlider : MonoBehaviour
{

    private Slider slider;
    private int level;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        level = (int)slider.value;
    }

    void Update()
    {
        level = (int)slider.value;
        PaintController.paintsize = level;
        PaintController2.paintsize2 = level;
    }
   

}
