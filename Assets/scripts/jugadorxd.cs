using UnityEngine;
using UnityEngine.N3DS;

public class jugadorxd:MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float gravityMultiplier = 9.8f; // Multiplicador de gravedad que puedes ajustar
    [SerializeField] private BoxCollider atkrat;

    private Rigidbody rb;
    private Animator animator;
    private SpriteRenderer personaje;
    private float ratcenter = 0.8f;
    private bool estoyHablando;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        personaje = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }
    public void checarsiHablo(bool hablando)
    {
        estoyHablando = hablando;
    }
    private void Update()
    {

        if (GamePad.GetButtonHold(N3dsButton.Y) && estoyHablando == false)
        {
            animator.SetTrigger("ataque");
        }
    }

    private void Movimiento()
    {
        float hor = Input.GetAxis("Horizontal");
        //float hor = GamePad.CirclePad.x;
        float vert = Input.GetAxis("Vertical");
        //float vert = GamePad.CirclePad.y;

        if (!estoyHablando)
        {
            rb.velocity = new Vector3(hor, 0, vert) * speed;
            animator.SetFloat("caminar", Mathf.Abs(rb.velocity.magnitude));

            // Aplica la gravedad adicional
            rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        }


        if (hor > 0)
        {
            personaje.flipX = false;
            atkrat.center = new Vector3(ratcenter, 0, 0);
        }
        else if (hor < 0)
        {
            personaje.flipX = true;
            atkrat.center = new Vector3(-ratcenter, 0, 0);

        }
    }

}