using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontal;
    public float vertical;
    public float speed;
    public Animator anim;
    public SpriteRenderer sprite;
    public float health;
    public GameObject slash;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontal < 0 || vertical < 0 || horizontal > 0 || vertical > 0)
        {
            anim.SetInteger("Anim", 1);
        }
        else if(horizontal == 0 || vertical == 0)
        {
            anim.SetInteger("Anim", 0);
        }
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.up * vertical * speed, ForceMode2D.Impulse);
        rb.AddRelativeForce(Vector3.right * horizontal * speed, ForceMode2D.Impulse);
    }
    IEnumerator Attack()
    {
        slash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        slash.SetActive(false);
    }
}
