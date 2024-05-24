using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk : MonoBehaviour {
    [SerializeField]private BoxCollider atkrat;

    private void Awake()
    {
        atkrat = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Destroy(other.gameObject);
        }
    }

}