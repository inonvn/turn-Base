
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject HighLight;
    public Transform hero;
    public Rigidbody2D player;

    public TypeSquare pos;
    void Start()
    {

    }
    private void OnMouseDown()
    {
        if (GameManagerFor.Game.InChoose)
        {
            GameManagerFor.Game.chooseHero();
        }
        if (!GameManagerFor.Game.InChoose)
        {
            GameManagerFor.Game.unchoose();
        }
    }


}
