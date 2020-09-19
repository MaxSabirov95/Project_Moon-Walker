using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public HpBar healthBar;
    public OxygenBar oxygenBar;
    public XpBar xpBar;

    public GameObject playerUpgradeBoard;
    bool _playerUpgradeBoard;

    public float playerHP;
    public float playerOxygen;
    public float playerXp;
    public int playerLevel;
    public int skillPoints=0;

    public float minusOxygen;
    public float plusOxygen;
    public float plusHP;

    public Text textPlayerLevel;
    public Text textNumberOfSkillPoints;

    public int speedUpHpAndEnergy;

    private void Awake()
    {
        BlackBoard.playerUI = this;

        playerHP = playerStats.maxPlayerHP;
        playerOxygen = playerStats.maxPlayerOxygen;

        healthBar.SetMaxValue(playerStats.maxPlayerHP);
        oxygenBar.SetMaxValue(playerStats.maxPlayerOxygen);
        xpBar.SetXp(playerXp);

        playerLevel = 1;
    }
    void Start()
    {
        playerUpgradeBoard.SetActive(_playerUpgradeBoard);
        textPlayerLevel.GetComponent<Text>().text = "" + playerLevel.ToString("f0");
        textNumberOfSkillPoints.GetComponent<Text>().text = "" + skillPoints.ToString("f0");
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Moon"))
        //{
        //    LoadPlayerData();
        //}

        //else
        //{
        //    LoadPlayerUIData();
        //}
    }

    void Update()
    {
        textPlayerLevel.GetComponent<Text>().text = "" + playerLevel.ToString("f0");

        if (!BlackBoard.enterToPlaces.inSpaceShip)
        {
            OutSpaceShip();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _playerUpgradeBoard = !_playerUpgradeBoard;
            playerUpgradeBoard.SetActive(_playerUpgradeBoard);
        }
    }

    public void InSpaceShip()
    {
        if (playerOxygen < playerStats.maxPlayerOxygen)
        {
            playerOxygen += (plusOxygen * Time.deltaTime);
        }
        if (playerHP < playerStats.maxPlayerHP)
        {
            playerHP += (plusHP * Time.deltaTime);
        }
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

    //public void SavePlayerData()
    //{
    //    SaveSystem.SaveData(this);
    //}

    //public void LoadPlayerData()
    //{
    //    GameData data = SaveSystem.LoadData();

    //    Vector2 position;
    //    position.x=data.playerPosition[0];
    //    position.y=data.playerPosition[1];
    //    transform.position = new Vector2(position.x, position.y);

    //    LoadPlayerUIData();
    //}
    //public void LoadPlayerUIData()
    //{
    //    GameData data = SaveSystem.LoadData();
    //    playerHP = data.playerHP;
    //    playerEnergy = data.playerEnergy;
    //    playerOxygen = data.playerOxygen;
    //    playerXp = data.playerXp;
    //    playerLevel = data.playerLevel;

    //    Bars();
    //}

    public void Bars()
    {
        healthBar.SetHealth(playerHP);
        oxygenBar.SetOxygen(playerOxygen);
        xpBar.SetXp(playerXp);
    }










    public void minusHpButton()
    {
        healthBar.SetHealth(playerHP -= 10);
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
            skillPoints += 10;
            textNumberOfSkillPoints.GetComponent<Text>().text = "" + skillPoints.ToString("f0");
            playerXp -= playerStats.maxPlayerXP;
            xpBar.SetXp(playerXp);
            playerStats.maxPlayerXP *= 1.05f;
            xpBar.slider.maxValue = playerStats.maxPlayerXP;
        }
    }
}
