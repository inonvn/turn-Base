
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseZone : MonoBehaviour
{
    public GameObject HighLight;
    public GameObject MoveToThatPlace;
    public Transform obj;


    private void OnMouseEnter()
    {
        HighLight.SetActive(true);
    }
    private void OnMouseExit()
    {
        HighLight.SetActive(false);
    }
}
