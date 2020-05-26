using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    int hpCost=1;
    int oxygenCost=1;
    int plusOneBulletCoast=5;
    int minusReloadTime=5;

    public Text textHpCoast;
    public Text textOxygenCost;
    public Text textPlusOneBulletCoast;
    public Text textMinusReloadTime;

    private void Start()
    {
        Prices();
    }

    public void HpUpgrade()
    {
        if(BlackBoard.playerUI.skillPoints>= hpCost)
        {
            BlackBoard.playerUI.skillPoints -= hpCost;
            hpCost++;
            Prices();
        }
    }

    public void OxygenUpgrade()
    {
        if (BlackBoard.playerUI.skillPoints >= oxygenCost)
        {
            BlackBoard.playerUI.skillPoints -= oxygenCost;
            oxygenCost++;
            Prices();
        }
    }

    public void PlusBulletUpgrade()
    {
        if (BlackBoard.playerUI.skillPoints >= plusOneBulletCoast)
        {
            BlackBoard.playerUI.skillPoints -= plusOneBulletCoast;
            plusOneBulletCoast++;
            Prices();
        }
    }

    public void ReloadTimeUpgrade()
    {
        if (BlackBoard.playerUI.skillPoints >= minusReloadTime)
        {
            BlackBoard.playerUI.skillPoints -= minusReloadTime;
            minusReloadTime++;
            Prices();
        }
    }

    void Prices()
    {
        textHpCoast.GetComponent<Text>().text = "Cost " + hpCost.ToString();
        textOxygenCost.GetComponent<Text>().text = "Cost " + oxygenCost.ToString();
        textPlusOneBulletCoast.GetComponent<Text>().text = "Cost " + plusOneBulletCoast.ToString();
        textMinusReloadTime.GetComponent<Text>().text = "Cost " + minusReloadTime.ToString();
    }
}
