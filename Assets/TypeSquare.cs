using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypeSquare : MonoBehaviour
{
   
    public  SpriteRenderer BaseColor;
    public GameObject HighLight;
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
