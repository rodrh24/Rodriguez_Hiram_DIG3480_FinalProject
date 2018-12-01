using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiRoPlayerController : MonoBehaviour {

    public GameObject ball;
    public Transform ballSpawn;
    public float fireRate;

    private float nextFire;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
        }
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
            audioSource.Play();
        }
    }
}
