using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypeSquare : MonoBehaviour
{
   
    public  SpriteRenderer BaseColor;
    public GameObject HighLight;
    public bool itWall;
    public Vector2Int locationV2;
    public TypeSquare Part;
    public int G, H;

    public int F { get { return G + H; } }
    [SerializeField] public virtual void e (float x,float y)
    {

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
