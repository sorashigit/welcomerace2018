using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController : MonoBehaviour
{
    public GameObject Pen;
    public GameObject MyEraser;
    Texture2D drawTexture;
    Color[] buffer;
    public static Color mycolor =Color.black;
    public static int paintsize = 5;

    public static Vector2 beforep = Vector2.zero;

    public static Texture2D saveTexture;

    public GameObject myRight;
    public static bool myExt = false;
    public static bool drawflag=false;
    private static Vector3 space=new Vector3(0f, 16f, -10f) ;

    void Start()
    {
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
       
    }

    public void Draw(Vector2 p)
    {

        Vector2 copyp = p;

        if ((copyp - beforep).magnitude <2) {
            //beforep = p;
            return;
        }
        
        //Debug.Log(p);
        //Debug.Log(beforep);
        //Debug.Log(beforep);

        if ((copyp - beforep).magnitude > paintsize && beforep != Vector2.zero)
        {
            Debug.Log("in");
            int kugiri = (int)(copyp - beforep).magnitude / paintsize;
            for (int z = 1; z <= kugiri; z++)
            {
                p = beforep + (copyp - beforep) * z / kugiri;

                int texx = (int)p.x;
                int texy = (int)p.y;

                for (int x = texx - (paintsize + 1); x < texx + (paintsize + 1); x++)
                {
                    if (x >= 0 & x < 256)
                    {
                        for (int y = texy - (paintsize + 1); y < texy + (paintsize + 1); y++)
                        {
                            if (y >= 0 & y < 256)
                            {
                                if ((p - new Vector2(x, y)).magnitude < paintsize)
                                {
                                    
                                        buffer.SetValue(mycolor/*Color.black*/, x + 256 * y);
                                    
                                }
                            }
                        }
                    }
                }

            }
        }
        else
        {

            int texx = (int)p.x;
            int texy = (int)p.y;

            for (int x = texx - (paintsize + 1); x < texx + (paintsize + 1); x++)
            {
                if (x >= 0 & x < 256)
                {
                    for (int y = texy - (paintsize + 1); y < texy + (paintsize + 1); y++)
                    {
                        if (y >= 0 & y < 256)
                        {
                            if ((p - new Vector2(x, y)).magnitude < paintsize)
                            {

                                buffer.SetValue(mycolor/*Color.black*/, x + 256 * y);

                            }
                        }
                    }
                }
            }
        }


        //aaa
        //int texx = (int)p.x;
        //int texy = (int)p.y;

        //for (int x=texx-5;x<texx+5;x++) {
        //    if (x>=0&&x<256) {
        //        for (int y = texy - 5; y < texy + 5; y++) {
        //            if (y >= 0 && y < 256) {
        //                if ((p - new Vector2(x, y)).magnitude < paintsize){

        //                    buffer.SetValue(mycolor/*Color.black*/, x + 256 * y);

        //                }
        //            }
        //        }
        //    }
        //}
        //aaa
        //bbb
        //for (int x = 0; x < 256; x++)
        //{
        //    for (int y = 0; y < 256; y++)
        //    {
        //        if ((p - new Vector2(x, y)).magnitude < paintsize)
        //        {
        //            buffer.SetValue(mycolor/*Color.black*/, x + 256 * y);
        //            //Pen.transform.position =new Vector3(x,y,0);

        //        }
        //    }
        //}
        //bbb

        beforep = p;
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(Camera.main.WorldToViewportPoint(myRight.transform.position));//ScreenPointToRay//WorldToScreenPoint
        //Debug.Log(myRight.transform.position.z);
        //Debug.Log(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {

            //if (mycolor == Color.black)
            //{
            //    Pen.transform.position = hit.point;// -(ray.direction)*5f; // +hit.nhormal;
            //MyEraser.transform.position = space;
            //}


        if (mycolor == Color.white)
        {
            MyEraser.transform.position = hit.point;
            Pen.transform.position = space;
            }
            else
            {
                Pen.transform.position = hit.point;// -(ray.direction)*5f; // +hit.nhormal;
                MyEraser.transform.position = space;

            }

            //Debug.Log(hit.textureCoord * 256);

            if (myExt) {
                Draw(hit.textureCoord * 256);


                MyCanvas.SetInteractive("Button2", true);
                //Indexpos.saveflag = true;//save可能
                drawflag = true;//何か書いた

            }
            else
            {
                beforep = Vector2.zero;
            }
            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            saveTexture = drawTexture;
            GetComponent<Renderer>().material.mainTexture = drawTexture;


        }

        //if (myExt)//クリック
        //{
           
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        Draw(hit.textureCoord * 256);
                

        //        MyCanvas.SetInteractive("Button2", true);
        //        Indexpos.saveflag = true;
        //        drawflag = true;
        //    }

        //    drawTexture.SetPixels(buffer);
        //    drawTexture.Apply();
        //    saveTexture = drawTexture;
        //    GetComponent<Renderer>().material.mainTexture = drawTexture;
        //}
        //else {
        //    beforep = Vector2.zero;
        //}
    }
}