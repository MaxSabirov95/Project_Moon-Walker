using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBetweenSpaceShipAndPlayer : MonoBehaviour
{
    public GameObject Player;
    public float distance;
    public Text distanceText;

    void Start()
    {
        BlackBoard.spaceShip = this;
    }

    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, transform.position);
        distanceText.GetComponent<Text>().text=""+distance.ToString("f1");
    }
}
