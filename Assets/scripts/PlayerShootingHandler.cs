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
    public AudioSource gunAudio;
    private LineRenderer bulletTrail;
    private float nextFire;
    private int damage;
    private float pitch;

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
                bulletTrail.SetPosition(1, hit.point);

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
                if (hit.transform.gameObject.tag == "PhysicsObject")
                {
                    int force = 15;
                    hit.rigidbody.AddForceAtPosition(force * player.transform.forward, hit.point);
                    hit.transform.gameObject.GetComponent<ObjectPhysicController>().TakeDamage(1);
                }

                
            }
            else
            {
                bulletTrail.SetPosition(1, endPos);
            }
            StartCoroutine(ShotEffect());

        }
    }

    private IEnumerator ShotEffect()
    {
        pitch = Random.Range(0.9f, 1.1f);

        gunAudio.pitch = pitch;
        gunAudio.Play();

        bulletTrail.enabled = true;
        
        yield return shotDuration;

        bulletTrail.enabled = false;
    }
}
