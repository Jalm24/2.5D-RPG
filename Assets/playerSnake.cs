using UnityEngine;
using UnityEngine.N3DS;
public class playerSnake : MonoBehaviour {
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float speed = 5f;
	[SerializeField] private float gravityMultiplier = 9.8f;
	[SerializeField] public int live = 100;
	[SerializeField] UIController ui;
    [SerializeField] private SpriteRenderer PlayerSpt;
	[SerializeField] UpperScreenUI upUI;
	[SerializeField] GameObject AtkBox;

    private Animator animator;
	private bool imtalking;

	// Update is called once per frame
	private void FixedUpdate () {
		//float hor = Input.GetAxis("Horizontal");
		float hor = GamePad.CirclePad.x;
		//float vert = Input.GetAxis("Vertical");
		float vert = GamePad.CirclePad.y;

		if (!imtalking)
		{
			if (live > 0)
			{
				rb.velocity = new Vector3(hor, 0, vert) * speed;
				animator.SetFloat("walkin", Mathf.Abs(rb.velocity.magnitude));
				rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
			}
		}
		if (live > 0)
		{

			if (hor > 0)
			{
				PlayerSpt.flipX = false;
				AtkBox.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
			}
			if (hor < 0)
			{
				PlayerSpt.flipX = true;
				AtkBox.GetComponent<BoxCollider>().center = new Vector3(-2.15f, 0, 0);
			}
			/*
			if (Input.GetKeyDown(KeyCode.K))
			{
				AtkBox.GetComponent<BoxCollider>().enabled = true;
			}
			else
			{
				AtkBox.GetComponent<BoxCollider>().enabled = false;
			}
			*/
			 if (GamePad.GetButtonHold(N3dsButton.Y))
			 {
				 AtkBox.GetComponent<BoxCollider>().enabled = true;
			 }
			 if (GamePad.GetButtonRelease(N3dsButton.Y))
			 {
				 AtkBox.GetComponent<BoxCollider>().enabled = false;
			 }
		}
    }
	private void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	public void restLife(int lifes)
	{
        if (live > 0)
        {
			live = live - lifes;
            ui.playerLife(live);
        }
		if (live <= 0)
		{
			upUI.DeadScreen(true);
			ui.OnDead(true);
		}
    }
	public void isTalking(bool isTalking)
	{
		imtalking = isTalking;
	}
}