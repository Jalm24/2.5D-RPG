using UnityEngine;


public class enemy : MonoBehaviour {
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private SpriteRenderer enemySpt;
    [SerializeField] private Animator animator;
    [SerializeField] private float limTime;
    [SerializeField] private int live = 100;
    [SerializeField] private EnmAtk atkcol;

    private int rut;
    private float chronometer;
    private int direction;
    private GameObject target;

    private void Start ()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("snake");
    }
    //movimiento
    private void FixedUpdate()
    {
        behaviors();
    }
    private void behaviors()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= limTime)
            {
                rut = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (rut)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;

                case 1:
                    direction = Random.Range(0, 6);
                    rut++;
                    break;

                case 2:
                    switch (direction)
                    {
                        case 0:
                            enemySpt.flipX = false;
                            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                            break;
                        case 1:
                            enemySpt.flipX = true;
                            transform.Translate((Vector3.right * -1) * walkSpeed * Time.deltaTime);
                            break;
                        case 2:
                            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
                            break;
                        case 3:
                            transform.Translate((Vector3.back * -1) * walkSpeed * Time.deltaTime);
                            break;
                        case 4:
                            enemySpt.flipX = false;
                            transform.Translate((Vector3.back + Vector3.right) * walkSpeed * Time.deltaTime);
                            break;
                        case 5:
                            enemySpt.flipX = true;
                            transform.Translate(((Vector3.right + Vector3.back) * -1) * walkSpeed * Time.deltaTime);
                            break;
                    }
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1.1 )
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
                if (transform.position.x < target.transform.position.x)
                {
                    enemySpt.flipX = false;
                }
                else
                {
                    enemySpt.flipX = true;
                }
                animator.SetBool("attack", false);
                atkcol.ActDescCol(false);
            }
            else if(Vector3.Distance(transform.position, target.transform.position) < 1.1)
            {
                animator.SetBool("walk", false);
                animator.SetBool("attack", true);
                atkcol.ActDescCol(true);
            }
        }
    }
    public void EnmRestLive(int life)
    {
        live = live - life;

        if (live <= 0)
        {
            animator.SetBool("isDead", true);
            Destroy(this.gameObject);
        }
    }
}