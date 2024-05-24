using UnityEngine;

public class ChatNPC : MonoBehaviour {
    [SerializeField] private playerSnake pSnake;
    [SerializeField] private UpperScreenUI UICont;
    [SerializeField, TextArea(3, 10)] private string[] arrayTexts;

    private bool isCol;
    private int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCol = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCol = false;
        }
    }

    private void Update()
    {
        if(isCol && Input.GetKeyDown("t"))
        {
            TextController();
        }
    }
    private void TextController()
    {
        if (index < arrayTexts.Length)
        {
            UICont.ActDisText(true);
            UICont.ShowText(arrayTexts[index]);
            pSnake.isTalking(true);
            index++;
        }
        else if (index >= arrayTexts.Length)
        {
            pSnake.isTalking(false);
            UICont.ActDisText(false);
        }
    }
}