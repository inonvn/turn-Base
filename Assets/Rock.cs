using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : TypeSquare
{
    public Color color1;
    public override void e(float x, float y)
    {
        BaseColor.color = color1;
        itWall = true;
    }

  
}
