using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    public delegate void SumaCoins(int coin);
    public static event SumaCoins sumaCoins;

    [SerializeField]private int coinCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(sumaCoins != null)
            {
                SumarMoneda();
                Destroy(this.gameObject);
            }
        }
    }
    private void SumarMoneda()
    {
        sumaCoins(coinCount);
    }
}