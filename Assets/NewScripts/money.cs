using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour {
	public delegate void MoneySum(int money);
	public static event MoneySum moneySum;

	[SerializeField] private int MoneyCount;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if(moneySum != null)
			{
                moneySum(MoneyCount);
				Destroy(this.gameObject);
            }
		}
	}
}