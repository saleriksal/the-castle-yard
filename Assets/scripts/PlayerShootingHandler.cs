using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingHandler : MonoBehaviour
{
    public int gunDamage;
    public int weaponRange;
    public float fireRate;
    public float hitForce;
    public Transform gunEnd;
    public GameObject player;
    public GameObject particlePrefab;

    private WaitForSeconds shotDuration;
    private AudioSource gunAudio;
    private LineRenderer bulletTrail;
    private float nextFire;
    private int damage;
    

    void Start()
    {
        gunDamage = 1;
        fireRate = 0.25f;
        weaponRange = 20;
        hitForce = 100f;
        shotDuration = new WaitForSeconds(0.07f);

        bulletTrail = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        player = this.gameObject;
        damage = 1;
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Vector3 endPos = gunEnd.transform.position + player.transform.forward * weaponRange;
            RaycastHit hit;
            bulletTrail.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(gunEnd.transform.position, player.transform.forward, out hit, weaponRange))
            {
                Debug.Log(hit.transform.name + " was hit");
                bulletTrail.SetPosition(1, hit.point);
                Debug.Log(hit.point);

                GameObject particleSystemObj = Instantiate(particlePrefab, hit.point, Quaternion.identity);

                ParticleSystem particleSystem = particleSystemObj.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    Destroy(particleSystemObj, particleSystem.main.duration);
                }

                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyDataHandler>().TakeDamage(damage);
                }

                
            }
            else
            {
                Debug.Log("Did not hit anything");
                bulletTrail.SetPosition(1, endPos);
            }
            StartCoroutine(ShotEffect());

        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();

        bulletTrail.enabled = true;
        
        yield return shotDuration;

        bulletTrail.enabled = false;
    }
}
