using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float speed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontal < 0 || vertical < 0)
        {
            anim.SetInteger("Anim", 1);
        }
        if(horizontal == 0 || vertical == 0)
        {
            anim.SetInteger("Anim", 0);
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.up * vertical * speed, ForceMode2D.Impulse);
        rb.AddRelativeForce(Vector3.right * horizontal * speed, ForceMode2D.Impulse);
    }
}
