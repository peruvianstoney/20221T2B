using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float velocityX = 9;
    public float jumpforce = 40;
    float nextfire = 2;
    public float firerate = 2;
    float nextfireB = 4;
    public float firerateB = 2;
    public GameObject rightBall;
    public GameObject leftBall;
    public GameObject rightBallMed;
    public GameObject leftBallMed;
    public GameObject rightBallBig;
    public GameObject leftBallBig;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator _animator;
    
    
    
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            _animator.SetInteger("Estado",0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity=new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity=new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
                _animator.SetInteger("Estado",2);
                
            }
            if (Input.GetKey((KeyCode.RightArrow))&&(Input.GetKey(KeyCode.C)))
            {
                rb.velocity=new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                _animator.SetInteger("Estado", 3);
                
            }

            if (Input.GetKey((KeyCode.LeftArrow))&&(Input.GetKey(KeyCode.C)))
            {
                rb.velocity=new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                _animator.SetInteger("Estado", 3);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                _animator.SetInteger("Estado", 4);
                
            }
            
            if (Input.GetKeyDown(KeyCode.X)  )
            {
                Debug.Log("bala chica");
                var bullet = sr.flipX ? leftBall : rightBall;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBall.transform.rotation;
                Instantiate(bullet, position, rotation);
                
            }
            
            if (Input.GetKeyUp(KeyCode.Z)&& Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                Debug.Log("bala mediana");
                var bullet = sr.flipX ? leftBallMed : rightBallMed;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBallMed.transform.rotation;
                Instantiate(bullet, position, rotation);
                
            }
            
            if (Input.GetKeyUp(KeyCode.V)&& Time.time > nextfireB)
            {
                nextfireB = Time.time + firerateB;
                Debug.Log("bala grande");
                var bullet = sr.flipX ? leftBallBig : rightBallBig;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBallBig.transform.rotation;
                Instantiate(bullet, position, rotation);
                
            }
            
        }
    }
}