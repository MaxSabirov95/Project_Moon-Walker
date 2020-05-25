using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterToPlaces : MonoBehaviour
{
    public enum placesToEnter {Cave1, Cave2 , Cave3 , Cave4, SpaceShip };
    public placesToEnter enterPlace;

    public GameObject player;
    public Text enterSpaceShip;
    public Text exitSpaceShip;
    public Text enterTheCave;

    public bool inSpaceShip;

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
            BlackBoard.playerUI.InSpaceShip();
            if (Input.GetKeyDown(KeyCode.E))
            {
                inSpaceShip = false;
                player.SetActive(true);
                enterSpaceShip.gameObject.SetActive(true);
                exitSpaceShip.gameObject.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (enterPlace)
                {
                    case placesToEnter.Cave1:
                        player.SetActive(false);
                        enterTheCave.gameObject.SetActive(false);
                        BlackBoard.playerUI.SavePlayerData();
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
                        break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            enterTheCave.gameObject.SetActive(false);
            enterSpaceShip.gameObject.SetActive(false);
        }
    }
}
