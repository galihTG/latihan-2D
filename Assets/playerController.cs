using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour{
    private float maxSpeed = 5f;
    private bool facingLeft = false;
    private Rigidbody2D rb;
    private Animator anim;



    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * maxSpeed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (h < 0 && !facingLeft)
            reverseImage();
        else if (h > 0 && facingLeft)
            reverseImage();
    }

    void reverseImage()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = rb.transform.localScale;
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }
}
