using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;
    Animator animator;
    Vector3 charPos;
    SpriteRenderer SpriteRenderer;
    [SerializeField] private GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        charPos = transform.position;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        speed = 1;



}

//unitynin fizik fonksiyonlarý kullanýlýyorsa FixedUpdate altýnda yazýlýr. 
private void FixedUpdate()
    {
        //Fizik kullanarak haraket ettirme
      //rb2D.velocity = new Vector2(speed,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        //fizik kullanmadan karakteri haraket ettirme
        charPos = new Vector3(charPos.x+(Input.GetAxis("Horizontal") * speed*Time.deltaTime),charPos.y);
        transform.position = charPos;

        if (Input.GetAxis("Horizontal")==0.0f)
        {
            animator.SetFloat("speed", 0.0f);
        }
        else 
        {
            animator.SetFloat("speed", 1.0f);
        }
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            SpriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            SpriteRenderer.flipX = true;
        } 


    }

    private void LateUpdate()
    {
        MainCamera.transform.position = new Vector3 (charPos.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
    }
}
