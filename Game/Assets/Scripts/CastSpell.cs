using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 200f;

    public Camera fpsCam;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    Color currentColor;

    // Update is called once per frame
    void Update () {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            AIattack target = hit.transform.GetComponent<AIattack>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            /*
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            */

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 3f);

            //Burn object
            if (hit.transform.tag == "Reactable")
            {
                currentColor = hit.transform.gameObject.GetComponentInChildren<Renderer>().material.color;
                hit.transform.gameObject.GetComponentInChildren<Renderer>().material.color = Color.Lerp(currentColor, Color.black, 0.1f);
            }
        }
    }
}
