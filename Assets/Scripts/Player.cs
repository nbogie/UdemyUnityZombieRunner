using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool doRespawn;

    [Header("Wiring")]
    public Transform spawnPoint;
    public GameObject signalObject;
    public ClearingDetector clearingDetector;
    public GameObject flarePrefab;
    public GameObject landingAreaPrefab;
    public AudioSource voiceAudioSource;

    [Header("Sounds")]
    public AudioClip callHeliSound;
    public AudioClip foundClearingSound;
    public AudioClip whatHappenedSound;

    public ZombieSpawner zombieSpawner;

    private Rigidbody rb;
    private bool alreadyFoundClearing;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        clearingDetector = GetComponentInChildren<ClearingDetector>();
        AssignSpawnPoint();
        voiceAudioSource.clip = whatHappenedSound;
        voiceAudioSource.Play();
        alreadyFoundClearing = false;
    }

    public void ReSpawn()
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void AssignSpawnPoint()
    {
        GameObject container = GameObject.Find("Player Spawn Points");
        spawnPoint = container.transform.GetChild(Random.Range(0, container.transform.childCount));
    }
    private bool lastToggle;

    void Update()
    {
        if (clearingDetector.ClearDuration() > 3f && Time.timeSinceLevelLoad > 10f)
        {
            if (!alreadyFoundClearing)
            {
                DoFoundClearing();

            }
        }
        else
        {
            signalObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (lastToggle != doRespawn)
        {
            RespawnSomewhereMaybeNew();
            doRespawn = false;
        }
        else
        {
            lastToggle = doRespawn;
        }
        if (Input.GetButtonDown("LaunchFlare"))
        {
            LaunchAFlare();
        }
        if (Input.GetButtonDown("Respawn"))
        {
            ReSpawn();
        }
        if (Input.GetButtonDown("RespawnMaybeNewPlace"))
        {
            RespawnSomewhereMaybeNew();
        }
        if (Input.GetButtonDown("CallHeli"))
        {
            CallHeli();
        }
    }

    private void DoFoundClearing()
    {
        signalObject.GetComponent<Renderer>().material.color = Color.green;
        alreadyFoundClearing = true;
        voiceAudioSource.clip = foundClearingSound;
        voiceAudioSource.Play();
        LaunchAFlare();
        Invoke("SetLandingArea", 3f);
    }

    public void SetLandingArea()
    {
        GameObject landingArea = Instantiate(landingAreaPrefab, transform.position, transform.rotation);
        GameObject heli = GameObject.Find("Helicopter");
        heli.GetComponent<Helicopter>().SetLandingArea(landingArea);
    }

    void LaunchAFlare()
    {
        Instantiate(flarePrefab, transform.position + 1*Vector3.up, Quaternion.identity);
        zombieSpawner.SpawnManyZombies(transform.position, transform);
    }

    void CallHeli()
    {
        voiceAudioSource.clip = callHeliSound;
        voiceAudioSource.Play();

    }

    private void RespawnSomewhereMaybeNew()
    {
        AssignSpawnPoint();
        ReSpawn();
    }
}
