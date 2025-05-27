using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseZone : MonoBehaviour
{
    public GameObject HighLight;
    public GameObject MoveToThatPlace;
    public Transform obj;

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameManagerFor.Game.InChoose == true)
        {
            
           print ($"{transform.position.x},{transform.position.y}");
            GameManagerFor.Game.GoToHere(obj.position.x, obj.position.y);
            MoveToThatPlace.SetActive (true);

            GameManagerFor.Game.UnChoose();
        }
    }
    private void OnMouseEnter()
    {
        HighLight.SetActive(true);
    }
    private void OnMouseExit()
    {
        HighLight.SetActive(false);
    }
}
