using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public HpBar healthBar;
    public EnergyBar energyBar;
    public OxygenBar oxygenBar;
    public XpBar xpBar;

    public float playerEnergy;
    public float playerHP;
    public float playerOxygen;
    public float playerXp;
    public int playerLevel;

    public float minusOxygen;
    public float plusOxygen;
    public float plusHP;

    public Text textPlayerLevel;

    public int speedUpHpAndEnergy;

    private void Awake()
    {
        BlackBoard.playerUI = this;

        playerHP = playerStats.maxPlayerHP;
        playerEnergy = playerStats.maxPlayerEnergy;
        playerOxygen = playerStats.maxPlayerOxygen;

        healthBar.SetMaxValue(playerStats.maxPlayerHP);
        energyBar.SetMaxValue(playerStats.maxPlayerEnergy);
        oxygenBar.SetMaxValue(playerStats.maxPlayerOxygen);
        xpBar.SetXp(playerXp);

        playerLevel = 1;

    }
    void Start()
    {
        textPlayerLevel.GetComponent<Text>().text = "" + playerLevel.ToString("f0");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Moon"))
        {
            LoadPlayerData();
        }

        else
        {
            LoadPlayerUIData();
        }
    }

    void Update()
    {
        textPlayerLevel.GetComponent<Text>().text = "" + playerLevel.ToString("f0");
        if (playerEnergy < playerStats.maxPlayerEnergy)
        {
            playerEnergy += (Time.deltaTime / speedUpHpAndEnergy);
            Bars();
        }

        if (!BlackBoard.enterToPlaces.inSpaceShip)
        {
            OutSpaceShip();
        }
    }

    public void InSpaceShip()
    {
        playerOxygen += (plusOxygen * Time.deltaTime);
        playerHP += (plusHP * Time.deltaTime);
        Bars();
    }

    void OutSpaceShip()
    {
        playerOxygen -= (minusOxygen * Time.deltaTime);
        if (playerOxygen <= 0)
        {
                playerOxygen = 0;
                playerHP -= Time.deltaTime;
        }
        Bars();
    }

    public void SavePlayerData()
    {
        SaveSystem.SaveData(this);
    }
    public void LoadPlayerData()
    {
        GameData data = SaveSystem.LoadData();

        Vector2 position;
        position.x=data.playerPosition[0];
        position.y=data.playerPosition[1];
        transform.position = new Vector2(position.x, position.y);

        LoadPlayerUIData();
    }
    public void LoadPlayerUIData()
    {
        GameData data = SaveSystem.LoadData();
        playerHP = data.playerHP;
        playerEnergy = data.playerEnergy;
        playerOxygen = data.playerOxygen;
        playerXp = data.playerXp;
        playerLevel = data.playerLevel;

        Bars();
    }

    void Bars()
    {
        energyBar.SetEnergy(playerEnergy);
        healthBar.SetHealth(playerHP);
        energyBar.SetEnergy(playerEnergy);
        oxygenBar.SetOxygen(playerOxygen);
        xpBar.SetXp(playerXp);
    }










    public void minusHpButton()
    {
        healthBar.SetHealth(playerHP -= 10);
    }

    public void minusEnergyButton()
    {
        energyBar.SetEnergy(playerEnergy -= 10);
    }

    public void minusOxygenButton()
    {
        oxygenBar.SetOxygen(playerOxygen -= 10);
    }

    public void plusXpButton()
    {
        xpBar.SetXp(playerXp += 25);
        if (playerXp >= playerStats.maxPlayerXP)
        {
            playerLevel++;
            playerXp -= playerStats.maxPlayerXP;
            xpBar.SetXp(playerXp);
            playerStats.maxPlayerXP *= 1.05f;
            xpBar.slider.maxValue = playerStats.maxPlayerXP;
        }
    }
}
