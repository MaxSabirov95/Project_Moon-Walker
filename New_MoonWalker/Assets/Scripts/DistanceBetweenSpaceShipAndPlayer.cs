using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBetweenSpaceShipAndPlayer : MonoBehaviour
{
    public GameObject Player;
    public float distance;
    public Text distanceText;
    float temp=0;

    void Start()
    {
        BlackBoard.spaceShip = this;
    }

    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, transform.position);
        if(temp != distance)
        {
            distanceText.GetComponent<Text>().text = "" + distance.ToString("f1");
            temp = distance;
            Debug.Log("in");
        }
    }
}
