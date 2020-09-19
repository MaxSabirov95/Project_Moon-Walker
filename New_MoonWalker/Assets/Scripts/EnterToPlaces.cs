using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterToPlaces : MonoBehaviour
{
    public enum placesToEnter {Cave1, Cave2 , Cave3 , Cave4, SpaceShip };
    public placesToEnter enterPlace;
    public Animator playerSleepMode;

    public GameObject player;
    public Text enterSpaceShip;
    public Text exitSpaceShip;
    public Text enterTheCave;

    public bool inSpaceShip;
    bool canEnter=false;

    private void Start()
    {
        BlackBoard.enterToPlaces = this;
        inSpaceShip = false;
        enterSpaceShip.gameObject.SetActive(false);
        exitSpaceShip.gameObject.SetActive(false);
        enterTheCave.gameObject.SetActive(false);
    }
    void Update()
    {
        if (inSpaceShip)
        {
            playerSleepMode.SetBool("InSpaceShip",true);
            BlackBoard.playerUI.InSpaceShip();
        }

        if (canEnter)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (enterPlace)
                {
                    case placesToEnter.Cave1:
                        player.SetActive(false);
                        enterTheCave.gameObject.SetActive(false);
                        //BlackBoard.playerUI.SavePlayerData();
                        BlackBoard.scenesLoad.loadLevel(1);
                        break;

                    case placesToEnter.SpaceShip:
                        if (!inSpaceShip)
                        {
                            inSpaceShip = true;
                            player.SetActive(false);
                            enterSpaceShip.gameObject.SetActive(false);
                            exitSpaceShip.gameObject.SetActive(true);
                        }
                        else
                        {
                            playerSleepMode.SetBool("InSpaceShip", false);
                            inSpaceShip = false;
                            player.SetActive(true);
                            enterSpaceShip.gameObject.SetActive(true);
                            exitSpaceShip.gameObject.SetActive(false);
                        }
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            switch (enterPlace)
            {
                case placesToEnter.Cave1:
                    enterTheCave.gameObject.SetActive(true);
                    break;
                case placesToEnter.SpaceShip:
                    enterSpaceShip.gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            enterTheCave.gameObject.SetActive(false);
            enterSpaceShip.gameObject.SetActive(false);
            if (inSpaceShip)
            {
                canEnter = true;
            }
            else
            {
                canEnter = false;
            }
        }
    }
}
