using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAtk : MonoBehaviour {
    [SerializeField] private BoxCollider atk;
    [SerializeField] public int damage = 5;

    private void Awake() 
    { 
        atk = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<enemy>().EnmRestLive(damage);
        }
    }
}