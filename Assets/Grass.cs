
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static eventFor;

public class Grass : TypeSquare
{
    public Color color1, color2;

    public override void e(float x, float y)
    {

        if ((x % 2 != 0 && y % 2 == 0) || (x % 2 == 0 && y % 2 != 0))
        {
            BaseColor.color = color1;
            itWall = false;
        }
        else
        {
            BaseColor.color = color2;
        }

    }



    public override void show()
    {

        HighLight.SetActive(true);
    }
    public override void hide()
    {

        HighLight.SetActive(false);
    }
    public override void eventrand()
    {

    }
}
