using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletActiveTime = 3;
    public float bulletPower = 10;
    public float bulletTime = 0;

    public GameObject firepoint;

    public float maxAmmo = 20;
    public TextMeshProUGUI ammoText;
    public float reloadTime = 3f;

    private float ammoCount;
    float nextShotTime;

    bool reloading;
    AudioSource aud;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ammoCount = maxAmmo;
        ammoText.text = $"Ammo: {ammoCount}";
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && ammoCount > 0 && Time.time >= nextShotTime)
        {
            // ADD CODE HERE
            GameObject instance;
            instance = Instantiate(bulletPrefab, firepoint.transform.position, firepoint.transform.rotation);
            Vector3 fireDir = transform.forward;
            if(Input.GetButton("Fire2"))
            {
                fireDir = Camera.main.transform.forward;
            }
            instance.GetComponent<BulletScript>().FireBullet(fireDir, bulletPower);
            ammoCount -= 1;
            // END OF CODE
            ammoText.text = $"Ammo: {ammoCount}";
            nextShotTime = Time.time + bulletTime;
        }
        if(ammoCount <= 0 && !reloading)
        {
            StartCoroutine(Reloading());
        }


    }

    private void FireBullet(BulletScript bullet)
    {
        bullet.transform.position = firepoint.transform.position;
        bullet.FireBullet(this.transform.forward, bulletPower);
    }

    public IEnumerator Reloading()
    {
        reloading = true;
        print("RELOADING!!!");
        aud.Play();
        yield return new WaitForSeconds(reloadTime);
        ammoCount = maxAmmo;
        reloading = false;
    }
}
