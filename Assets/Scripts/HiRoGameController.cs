using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiRoGameController : MonoBehaviour
{

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private float timer;
    private int count;

    public GameObject explosion;
    public Text startText;
    public Text endText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        startText.text = "Shoot The Moon!";
        endText.text = "";
        count = 0;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 10 && count < 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.Play();
        if (other.gameObject.CompareTag("HiRoBall"))
        {
            GameObject.Find("HiRoMoon").transform.localScale = new Vector3(0, 0, 0);
            Instantiate(explosion, transform.position, transform.rotation);
            count = 10;
            // GameLoader wouldn't work for me, so I commented it out for now. Uncomment it, if needed.
            //GameLoader.AddScore(10);
            endText.text = "You Win! :)";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // GameLoader wouldn't work for me, so I commented it out for now. Uncomment it, if needed.
        //GameLoader.gameOn = false;
    }
}
