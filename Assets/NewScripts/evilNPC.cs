using UnityEngine;
using UnityEngine.UI;

public class evilNPC : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private SpriteRenderer enemySpt;
   // [SerializeField] private Animator animator;
    [SerializeField] private float limTime;
    [SerializeField] private int live = 100;
    [SerializeField] private EnmAtk atkcol;
    [SerializeField] private playerSnake pSnake;
    [SerializeField] private UpperScreenUI UICont;
    [SerializeField] private Text upprB;
    [SerializeField] private Text lowB;
    [SerializeField] private string uptext;
    [SerializeField] private string lowtext;
    [SerializeField] private GameObject CanvContrl;
    [SerializeField] private GameObject MainContrl;
    [SerializeField, TextArea(3, 10)] private string[] arrayTexts;

    private int index;
    private int rut;
    private float chronometer;
    private int direction;
    private GameObject target;
    private bool isEvil;
    private bool isCol;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        target = GameObject.Find("snake");
        CanvContrl.SetActive(false);
    }
    //movimiento
    private void FixedUpdate()
    {
        behaviors();
        if(!isEvil && isCol && UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.A))
        {
            ChatController();
        }
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
                    //animator.SetBool("walk", false);
                    break;

                case 1:
                    direction = Random.Range(0, 2);
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
                    }
                    //animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (isEvil)
            {

                if (Vector3.Distance(transform.position, target.transform.position) > 1.1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, walkSpeed * Time.deltaTime);
                    if (transform.position.x < target.transform.position.x)
                    {
                        enemySpt.flipX = false;
                    }
                    else
                    {
                        enemySpt.flipX = true;
                    }
                    //animator.SetBool("attack", false);
                    atkcol.ActDescCol(false);
                }
                else if (Vector3.Distance(transform.position, target.transform.position) < 1.1)
                {
                    //animator.SetBool("walk", false);
                    //animator.SetBool("attack", true);
                    atkcol.ActDescCol(true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isEvil)
            {
                isCol = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isEvil)
            {
                isCol = false;
            }
        }
    }

    public void EnmRestLive(int life)
    {
        live = live - life;

        if (live <= 0)
        {
            //animator.SetBool("isDead", true);
            Destroy(this.gameObject);
        }
    }
    private void ChatController()
    {
        if (index < arrayTexts.Length)
        {
            UICont.ActDisText(true);
            UICont.ShowText(arrayTexts[index]);
            pSnake.isTalking(true);
            MainContrl.SetActive(false);
            index++;
        }
        else if (index >= arrayTexts.Length)
        {
            CanvContrl.SetActive(true);
            lowB.text = lowtext;
            upprB.text = uptext;
            pSnake.isTalking(false);

            UICont.ActDisText(false);
            if (isEvil)
            {
                pSnake.isTalking(false);
                CanvContrl.SetActive(false);
                MainContrl.SetActive(true);
            }
        }
    }
    public void FirstB()
    {
        isEvil = true;
    }
    public void LastB()
    {
        isEvil = false;
    }
}