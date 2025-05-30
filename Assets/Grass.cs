using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : TypeSquare
{
    public Color color1,color2;

    public override void e(float x, float y)
    {
        
        if ((x % 2 != 0 && y % 2 == 0) || (x % 2 == 0 && y % 2 != 0))
        {
            BaseColor.color = color1;
            itWall = false;
        }
        else
        {BaseColor.color = color2;
        }
        
    }
   

    void OnMouseEnter()
    {
        HighLight.SetActive(true);
    }
    void OnMouseExit()
    {
        HighLight.SetActive(false);

    }
}
