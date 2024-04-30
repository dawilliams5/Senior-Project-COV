using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform leftFirePoint;
    public Transform DoubleFirePoint;
    public Transform DoubleFirePointLeft;
    public Transform firePointTop;
    public Transform firePointBottom;
    public Transform firePointTopLeft;
    public Transform firePointBottomLeft;
    public bullet bulletPrefab;
    public double bulletDamage;
    public float bulletSpeed;
    public Animator animator;
    public bool shootBackwards = false;
    private float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 2;
    public bool doubleshoot = false;
    public bool triShot = false;

    // Update is called once per frame
    void Update()
    {
        checkIfShouldShoot();
    }
    private void Start()
    {
        bulletDamage = 15;
        bulletSpeed = 10;
        
        bulletDamage = bulletPrefab.damage;
        bulletSpeed = bulletPrefab.speed;
    }
    public void UpgradeFireRate(float rate)
    {
        if (timeBetweenShooting > 0)
        {
            timeBetweenShooting -= rate;
        }
        
    }


    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }

    void Shoot()
    {
        if(shootBackwards == false)
        {
            if((animator.GetBool("Face_Left") == false))
            {
                if(triShot == false)
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab, DoubleFirePoint.position, DoubleFirePoint.rotation);
                    }
                    else 
                    { 
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                    }
                }
                else
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTop.position, firePointTop.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottom.position, firePointBottom.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePoint.position, DoubleFirePoint.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTop.position, firePointTop.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottom.position, firePointBottom.rotation);
                    }
                }
              
            }
            else
            {
                if(triShot == false)
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePointLeft.position, DoubleFirePointLeft.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                    }
                }
                else
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePointTopLeft.position, firePointTopLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottomLeft.position, firePointBottomLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePointLeft.position, DoubleFirePointLeft.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTopLeft.position, firePointTopLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottomLeft.position, firePointBottomLeft.rotation);
                    }
                }

            }
        }
        
        else
        {
            if ((animator.GetBool("Face_Left") == false))
            {
                if (triShot == false)
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePoint.position, DoubleFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePointLeft.position, DoubleFirePointLeft.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                    }
                }
                else
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTop.position, firePointTop.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottom.position, firePointBottom.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePoint.position, DoubleFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTop.position, firePointTop.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottom.position, firePointBottom.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                    }
                }

            }
            else
            {
                if (triShot == false)
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePointLeft.position, DoubleFirePointLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePoint.position, DoubleFirePoint.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                    }
                }
                else
                {
                    if (doubleshoot)
                    {
                        Instantiate(bulletPrefab.gameObject, firePointTopLeft.position, firePointTopLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottomLeft.position, firePointBottomLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, DoubleFirePointLeft.position, DoubleFirePointLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                    }
                    else
                    {
                        Instantiate(bulletPrefab.gameObject, leftFirePoint.position, leftFirePoint.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointTopLeft.position, firePointTopLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePointBottomLeft.position, firePointBottomLeft.rotation);
                        Instantiate(bulletPrefab.gameObject, firePoint.position, firePoint.rotation);
                    }
                }

            }
        }
    }
}
