using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController2 : MonoBehaviour
{
    public GameObject Pen2;
    public GameObject MyEraser2;
    public GameObject myplane;
    Texture2D drawTexture;
    Color[] buffer;
    public static Color mycolor2 =Color.black;
    public static int paintsize2 = 5;

    public static Vector2 beforep2 = Vector2.zero;

    public static Texture2D saveTexture2;

    public GameObject myRight2;
    public static bool myExt2 = false;
    public static bool drawflag2=false;
    private static Vector3 space2=new Vector3(0f, 16f, -10f) ;

    void Start()
    {
        myplane.GetComponent<Renderer>().material.mainTexture = ManegeBotton3.mytexture;
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

        if ((copyp - beforep2).magnitude <2) {
            //beforep = p;
            return;
        }
        
        //Debug.Log(p);
        //Debug.Log(beforep);
        //Debug.Log(beforep);

        if ((copyp - beforep2).magnitude > paintsize2 && beforep2 != Vector2.zero)
        {
            Debug.Log("in");
            int kugiri = (int)(copyp - beforep2).magnitude / paintsize2;
            for (int z = 1; z <= kugiri; z++)
            {
                p = beforep2 + (copyp - beforep2) * z / kugiri;

                int texx = (int)p.x;
                int texy = (int)p.y;

                for (int x = texx - (paintsize2 + 1); x < texx + (paintsize2 + 1); x++)
                {
                    if (x >= 0 & x < 256)
                    {
                        for (int y = texy - (paintsize2 + 1); y < texy + (paintsize2 + 1); y++)
                        {
                            if (y >= 0 & y < 256)
                            {
                                if ((p - new Vector2(x, y)).magnitude < paintsize2)
                                {
                                    //Debug.Log("if");
                                    if (buffer[x + 256 * y].r > 0.2 || buffer[x + 256 * y].r < 0.19/*|| buffer[x + 256 * y].g != 100/256.0|| buffer[x + 256 * y].b != 100/256.0*/) {
                                        buffer.SetValue(mycolor2/*Color.black*/, x + 256 * y);
                                    }
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

            for (int x = texx - (paintsize2 + 1); x < texx + (paintsize2 + 1); x++)
            {
                if (x >= 0 & x < 256)
                {
                    for (int y = texy - (paintsize2 + 1); y < texy + (paintsize2 + 1); y++)
                    {
                        if (y >= 0 & y < 256)
                        {
                            if ((p - new Vector2(x, y)).magnitude < paintsize2)
                            {
                                //Debug.Log("if");
                                if (buffer[x + 256 * y].r > 0.2 || buffer[x + 256 * y].r < 0.19/*|| buffer[x + 256 * y].g != 100/256.0 || buffer[x + 256 * y].b != 100/256.0*/)
                                {
                                    buffer.SetValue(mycolor2/*Color.black*/, x + 256 * y);
                                }
                            }
                        }
                    }
                }
            }
        }




        beforep2 = p;
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(Camera.main.WorldToViewportPoint(myRight2.transform.position));//ScreenPointToRay//WorldToScreenPoint
        //Debug.Log(myRight.transform.position.z);
        //Debug.Log(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {

            //if (mycolor2 == Color.black)
            //{
            //    Pen2.transform.position = hit.point;// -(ray.direction)*5f; // +hit.nhormal;
            //MyEraser2.transform.position = space2;
            //}


            if (mycolor2 == Color.white)
            {
                MyEraser2.transform.position = hit.point;
                Pen2.transform.position = space2;
            }
            else {
                Pen2.transform.position = hit.point;// -(ray.direction)*5f; // +hit.nhormal;
                MyEraser2.transform.position = space2;

            }

            //Debug.Log(hit.textureCoord * 256);

            if (myExt2) {
                Draw(hit.textureCoord * 256);


                MyCanvas.SetInteractive("Button2", true);
                //Indexpos2.saveflag2 = true;//save可能
                drawflag2 = true;//何か書いた

            }
            else {
                beforep2 = Vector2.zero;
            }
            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            saveTexture2 = drawTexture;
            GetComponent<Renderer>().material.mainTexture = drawTexture;


        }

    }
}