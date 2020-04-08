using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float hitForce = 30f;
    public int maxAmmo = 10;
    //reload time in seconds
    public float reloadTime = 1f;

    public Camera playerCamera;
    public Image bulletModeImage;
    public Text ammoCounter;

    private float nextTimeToFire = 0f;
    private bool isAutoFire = true;
    private int currentAmmo;
    private bool isReloading;

    void Start()
    {
        currentAmmo = maxAmmo;
        updateAmmoCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloading && currentAmmo > 0)
        {
            if (isAutoFire)
            {
                if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            isAutoFire = !isAutoFire;
            bulletModeImage.GetComponent<BulletMode>().ToggleMode();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            ammoCounter.text = string.Format(".../{0}", maxAmmo);
            StartCoroutine(Reload());
            print("reloading");
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        updateAmmoCounter();
        print("reloaded");
    }

    void Shoot()
    {
        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        updateAmmoCounter();
    }

    private void updateAmmoCounter()
    {
        if (currentAmmo <= (maxAmmo / 100f * 20f))
            ammoCounter.color = Color.red;
        else
            ammoCounter.color = Color.black;
        ammoCounter.text = string.Format("{0}/{1}", currentAmmo, maxAmmo);
    }
}
