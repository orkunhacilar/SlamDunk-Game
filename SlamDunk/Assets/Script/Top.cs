using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{

    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            _GameManager.Basket();
        }else if (other.CompareTag("OyunBitti"))
        {
            _GameManager.Kaybettin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _GameManager.sesler[1].Play();
    }
}
