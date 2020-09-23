using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public Bars healthBar;
    public Bars oxygenBar;
    public XpBar xpBar;

    public GameObject playerUpgradeBoard;
    bool _playerUpgradeBoard;

    public float playerHP;
    public float playerOxygen;
    public float maxPlayerHP;
    public float maxPlayerOxygen;
    public float playerXp;
    public float maxPlayerXp;
    public int playerLevel;
    public int skillPoints=0;

    public float minusOxygen;
    public float plusOxygen;
    public float plusHP;

    public Text textPlayerLevel;
    public Text textNumberOfSkillPoints;

    private void Awake()
    {
        BlackBoard.playerUI = this;

        playerHP = maxPlayerHP;
        playerOxygen = maxPlayerOxygen;

        healthBar.SetMaxValue(maxPlayerHP);
        oxygenBar.SetMaxValue(maxPlayerOxygen);
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
        if (playerOxygen < maxPlayerOxygen)
        {
            playerOxygen += (plusOxygen * Time.deltaTime);
        }
        if (playerHP < maxPlayerHP)
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
        healthBar.SetValue(playerHP);
        oxygenBar.SetValue(playerOxygen);
        xpBar.SetXp(playerXp);
    }










    public void minusHpButton()
    {
        healthBar.SetValue(playerHP -= 10);
    }

    public void minusOxygenButton()
    {
        oxygenBar.SetValue(playerOxygen -= 10);
    }

    public void plusXpButton()
    {
        xpBar.SetXp(playerXp += 25);
        if (playerXp >= maxPlayerXp)
        {
            playerLevel++;
            textPlayerLevel.GetComponent<Text>().text = "" + playerLevel.ToString("f0");
            skillPoints += 10;
            textNumberOfSkillPoints.GetComponent<Text>().text = "" + skillPoints.ToString("f0");
            playerXp -= maxPlayerXp;
            xpBar.SetXp(playerXp);
            maxPlayerXp *= 1.05f;
            xpBar.slider.maxValue = maxPlayerXp;
        }
    }
}
