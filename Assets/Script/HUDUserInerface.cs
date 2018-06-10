using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDUserInerface : MonoBehaviour {

    public Unit player;
    public Image healthBar;
    public Text healthLabe;
    void Update()
    {
        healthBar.fillAmount = (float)player.GetCurHealth() / (float)player.health;
        if (player.GetCurHealth() <=50)
        {
            healthLabe.text = "0";
            healthBar.fillAmount = 0;
        }
            
        else
        healthLabe.text = player.GetCurHealth().ToString();
    }
}
