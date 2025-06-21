
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static eventFor;

public abstract class TypeSquare : MonoBehaviour
{

    public SpriteRenderer BaseColor;
    public GameObject HighLight;

    public bool itWall;
    public Vector2Int locationV2;
    public Vector2Int locationV2copy { get { return new Vector2Int(locationV2.x, locationV2.y); } }
    public TypeSquare Part;
    public int G, H;
    public key randomEvent;


    public int F { get { return G + H; } }
    [SerializeField]
    public virtual void e(float x, float y)
    {

    }

    public virtual void show()
    {


    }
    public virtual void hide()
    {


    }
    public virtual void eventrand()
    {

    }
}
