using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Colidiu com algo"); //*

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                other.gameObject.SetActive(false);
            }
        }

         if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
         {
             other.gameObject.SetActive(false);



         }
    }
        }
