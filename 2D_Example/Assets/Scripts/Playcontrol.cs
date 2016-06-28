using UnityEngine;
using System.Collections;

public class Playcontrol : MonoBehaviour {

    [HideInInspector]
    public bool heroFaceRight = true;
    [HideInInspector]
    public bool heroJump = false;

    public float MoveForce = 100f;
    public float JumpForce = 600f;
    public float MaxSpeed = 5f;
    private bool IsGrounded = false;
    private Transform mGroudCheck;

    private Rigidbody2D Herobody;
    private Animator anim;


	void Awake()
    {
        mGroudCheck = transform.Find("GroundCheck");
        Herobody = GetComponent<Rigidbody2D>();
        anim = transform.root.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        IsGrounded = Physics2D.Linecast(transform.position, mGroudCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            heroJump = true;
        }
        Debug.DrawLine(transform.position, mGroudCheck.position, Color.red, 0.5f);
    }

	// Update is called once per frame
	void FixedUpdate () {
        float fInput = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(fInput));
        if((fInput*Herobody.velocity.x)<MaxSpeed)
        {
            Herobody.AddForce(Vector2.right * fInput * MoveForce);
        }
        if((fInput*Herobody.velocity.x)>MaxSpeed)
        {
            Herobody.velocity = new Vector2(Mathf.Sign(Herobody.velocity.x) * MaxSpeed, Herobody.velocity.y);
        }
        if(fInput>0&& !heroFaceRight)
        {
            flip();
        }
        else if(fInput<0&& heroFaceRight)
        {
            flip();
        }
        if(heroJump)
        {
          //  int i = Random.Range(0, JumpClips.Length);
          //  AudioSource.PlayClipAtPoint(JumpClips[i], transform.position);

            Herobody.AddForce(new Vector2(0f, JumpForce));
            anim.SetTrigger("jump");
            heroJump = false;
        }
	}

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        heroFaceRight = !heroFaceRight;
    }
}
