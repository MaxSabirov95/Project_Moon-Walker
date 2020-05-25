using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFlip : MonoBehaviour
{
    public GameObject Player;
    public GameObject playerGraphics;
    public Transform startFirePosition;
    public GameObject bullet;
    public Camera cam;

    public int maxWeaponBullets;
    public float currentBulletsInWeapon;
    bool canShoot;
    public Text textBulletsWeapon;

    private void Start()
    {
        currentBulletsInWeapon = maxWeaponBullets;
        canShoot = true;
        textBulletsWeapon.GetComponent<Text>().text = "" + currentBulletsInWeapon.ToString("f0") + "/" + maxWeaponBullets.ToString("f0");
    }
    void Update()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);
        Vector3 mouseRelative = Player.transform.InverseTransformPoint(cam.ScreenToWorldPoint(Input.mousePosition));

        if (mouseRelative.x > 0)
        {
            playerGraphics.transform.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerGraphics.transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = new Vector3(-1, -1, 1);
        }

        if (Input.GetMouseButtonDown(0) && canShoot && currentBulletsInWeapon>=1)
        {
            StartCoroutine(Shooting());
        }
    }
    private void FixedUpdate()
    {
        if (currentBulletsInWeapon < maxWeaponBullets)
        {
            currentBulletsInWeapon += (Time.deltaTime/3);
            textBulletsWeapon.GetComponent<Text>().text = "" + ((int)currentBulletsInWeapon).ToString("f0") + "/" + maxWeaponBullets.ToString("f0");
        }
        if(currentBulletsInWeapon <= 0)
        {
            currentBulletsInWeapon = 0;
        }
    }
    IEnumerator Shooting()
    {
        GameObject shoot = Instantiate(bullet, startFirePosition.transform.position, startFirePosition.transform.rotation);
        currentBulletsInWeapon--;
        canShoot = false;
        textBulletsWeapon.GetComponent<Text>().text = "" + currentBulletsInWeapon.ToString("f0") + "/" + maxWeaponBullets.ToString("f0");
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
