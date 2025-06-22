using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyAttack : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public int Dame;
    public Image Image;

    public void Start()
    {
        HP=MaxHP;
        Image.fillAmount = HP;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Image.fillAmount= HP/MaxHP;
    }
}
