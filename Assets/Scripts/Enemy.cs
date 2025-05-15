using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameManager gm;
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float health = 2;
    public bool isInRange;
    public float range;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce((player.transform.position * speed).normalized, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Slash"))
        {
            health -= 1;
        }
    }
}
