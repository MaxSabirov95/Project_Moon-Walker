using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPlace : MonoBehaviour
{
    private int sceneToCountinue;
    public enum PlaceKind {Cave};
    public PlaceKind placeKind;
    public GameObject player;
    public Text exitCave;

    void Start()
    {
        exitCave.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            switch (placeKind)
            {
                case PlaceKind.Cave:
                    exitCave.gameObject.SetActive(true);
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
                switch (placeKind)
                {
                    case PlaceKind.Cave:
                        player.SetActive(false);
                        StartCoroutine(LoadLevel());
                        BlackBoard.scenesLoad.loadLevel(0);
                        break;
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D Place)
    {
        if (Place.CompareTag("Player"))
        {
            exitCave.gameObject.SetActive(false);
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
        BlackBoard.playerUI.LoadPlayerData();
        //-- For animation between scenes
    }

}
