using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
    private int totalCoins;
    [SerializeField] private Text coinVal;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonApagao;
    [SerializeField] private GameObject cajaTexto;
    [SerializeField] private Text textoDialogo;
    private void Start ()
    {
        coins.sumaCoins += SumarMonedas;
    }
    private void SumarMonedas(int coin)
    {
        totalCoins += coin;
        coinVal.text = totalCoins.ToString();
    }
    public void restaCorazon(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonApagao;
    }
    public void ActDesactCajaTexto(bool activado)
    {
        cajaTexto.SetActive(activado);
    }
    public void MostrarTextos(string texto)
    {
        textoDialogo.text = texto.ToString();
    }
}