using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperScreenUI : MonoBehaviour {
	[SerializeField] private Text UpperText;
	[SerializeField] private GameObject TextBox;
	[SerializeField] private GameObject DeadSc;

	public void ShowText(string text)
	{
		UpperText.text = text.ToString();
	}
	public void ActDisText(bool Actex)
	{
		TextBox.SetActive(Actex);
	}
	public void DeadScreen(bool Dead)
	{
		TextBox.SetActive(false);
		DeadSc.SetActive(Dead);
	}
}