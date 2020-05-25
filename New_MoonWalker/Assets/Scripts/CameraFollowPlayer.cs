using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);

         transform.eulerAngles = new Vector3(0,0, Player.transform.eulerAngles.z);
;
    }
}
