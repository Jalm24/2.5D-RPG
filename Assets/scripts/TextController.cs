using UnityEngine;
using UnityEngine.N3DS;

public class TextController : MonoBehaviour {
    [SerializeField, TextArea(3, 10)] private string [] arrayTextos;
    [SerializeField]private uiManager uiManager;
    [SerializeField]private jugadorxd personaje;
    private int indice;
    private bool colPlayer;

    private void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("NPC").GetComponent<jugadorxd>();

    }
    private void OnTriggerEnter(Collider other)
    {
        colPlayer = true;
    }
    private void OnTriggerExit(Collider other)
    {
        colPlayer=false;
    }
    private void Update()
    {
        if (colPlayer && Input.GetKeyDown("t"))
        {
            float distancia = Vector3.Distance(this.gameObject.transform.position, personaje.transform.position);
            if (distancia <= 2)
            {
                uiManager.ActDesactCajaTexto(true);
                personaje.checarsiHablo(true);
                ActivarCartel();
            }
        }
    }
    void ActivarCartel()
    {
        if(indice < arrayTextos.Length)
        {
            uiManager.MostrarTextos(arrayTextos[indice]);
            indice++;
        }
        else if (indice >= arrayTextos.Length)
        {
            uiManager.ActDesactCajaTexto(false);
            personaje.checarsiHablo(false);
        }
    }
}