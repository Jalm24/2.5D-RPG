using UnityEngine;

public class EnmAtk : MonoBehaviour {
	[SerializeField] private CapsuleCollider enmAtk;
	[SerializeField] private int atk = 15;

    private void Awake()
    {
        enmAtk = GetComponent<CapsuleCollider>();
    }

	public void ActDescCol(bool act)
	{
		if (act)
		{
			enmAtk.GetComponent<CapsuleCollider>().enabled = true;
		}
		else
		{
            enmAtk.GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<playerSnake>().restLife(atk);
		}
	}
}