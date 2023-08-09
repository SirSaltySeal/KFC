/*
 * Author: Tanucan Cliford Baguio
 * Date: 2/08/2023
 * Description: Muzzle Fire and Damage
 */
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    public Camera fpsCam;
    public VisualEffect muzzleFlash;
    private object hit;
    public GameObject impactEffect;
    public float impactForce = 50f;
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        //nexttimetofire += time.deltatime;
        //if (nexttimetofire > 1f)
        //{
        //    nexttimetofire -= 1f;
        //}
    }

    void Shoot()
    {

        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
               target.TakeDamage(damage);
            }


            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * impactForce);

            }


        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
    }
}