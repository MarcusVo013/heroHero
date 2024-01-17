using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability1")]
    public Image ability1Image;
    public float cooldown1 = 0.2f;
    bool iscooldown = false;
    [Header("Ability2")]
    public Image ability2Image;
    public float cooldown2 = 0.2f;
    bool iscooldown2 = false;


    private void Start()
    {
        ability1Image.fillAmount = 0;
    }
    private void Update()
    {
        Ability1();
        Ability2();
    }
    void Ability1()
    {
        if(Input.GetButtonDown("Fire1") && iscooldown == false)
        {
            iscooldown = true;
            ability1Image.fillAmount = 1;
        }
        if(iscooldown)
        {
            ability1Image.fillAmount -=1 /cooldown1 * Time.deltaTime;
            if(ability1Image.fillAmount <=0)
            {
                ability1Image.fillAmount = 0;
                iscooldown=false;
            } 
        }
    }
    void Ability2()
    {
        
        if (Input.GetButtonDown("Fire2") && iscooldown == false )
        {
            iscooldown2 = true;
            ability2Image.fillAmount = 1;
        }
        if (iscooldown2)
        {
            ability2Image.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (ability2Image.fillAmount <= 0)
            {
                ability2Image.fillAmount = 0;
                iscooldown2 = false;
            }
        }
    }

}
