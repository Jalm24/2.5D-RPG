using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] private Text moneyVal;
    [SerializeField] private Text liveTotal;
    [SerializeField] private GameObject MainMenuButton;
    [SerializeField] private GameObject LastSaveButton;

    private int totalMoney;

    private void Start ()
    {
        money.moneySum += sumMoney;
    }
    private void sumMoney (int moneys)
    {
        totalMoney += moneys;
        moneyVal.text = totalMoney.ToString();
    }
    public void playerLife(int life)
    {
        liveTotal.text = life.ToString();
    }
    public void OnDead(bool dead)
    {
        MainMenuButton.SetActive(dead);
        LastSaveButton.SetActive(dead);
    }

}