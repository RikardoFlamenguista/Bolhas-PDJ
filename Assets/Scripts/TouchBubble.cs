using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchBubble : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
#if UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Obtenha a posi��o do toque no mundo
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

                // Lance um raio a partir da posi��o do toque na dire��o da c�mera
                Ray ray = new Ray(touchPosition, Camera.main.transform.forward);

                // Crie uma vari�vel RaycastHit para armazenar informa��es sobre o objeto atingido
                RaycastHit hit;

                // Verifique se o raio atingiu um objeto na cena
                if (Physics.Raycast(ray, out hit))
                {
                    // Verifique se o objeto atingido est� na camada desejada (voc� pode configurar a camada em seu objeto)
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster"))
                    {
                        // Desative o objeto atingido
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }


#endif



/*#if UNITY_EDITOR

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objetoColidido = hit.collider.gameObject;
                gameObject.SetActive(false);
            }
        }

#endif*/



    }
}
