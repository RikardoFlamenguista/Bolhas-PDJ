using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchBubble : MonoBehaviour
{

    public GameObject teste;

    void Start()
    {
        
    }


    void Update()
    {
#if UNITY_ANDROID


        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    // Obtenha a posi��o do toque na tela
                    Vector3 touchPositionScreen = new Vector3(touch.position.x, touch.position.y, 0);

                    // Defina a dist�ncia a partir da c�mera (ajuste conforme necess�rio)
                    float distanceFromCamera = 10;

                    // Converta a posi��o do toque em uma posi��o no mundo
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionScreen.x, touchPositionScreen.y, distanceFromCamera));


                    touchPosition.z = -10;

                    // Lance um raio a partir da posi��o do toque na dire��o da c�mera
                    Ray ray = new Ray(touchPosition, Camera.main.transform.forward);

                    // Crie uma vari�vel RaycastHit para armazenar informa��es sobre o objeto atingido
                    RaycastHit hit;



                    
                   
                    // Verifique se o raio atingiu um objeto na cena
                     if (Physics.Raycast(ray, out hit))
                     {
                         Debug.Log("raycast acertou algo");
                         // Verifique se o objeto atingido est� na camada desejada (voc� pode configurar a camada em seu objeto)
                         if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster"))
                         {
                             // Desative o objeto atingido
                             hit.collider.gameObject.SetActive(false);

                             Instantiate(teste, touchPosition, Quaternion.identity);
                         }
                     }
                    Debug.Log(touchPosition);
                }
            }
        }




       /*  if (Input.touchCount > 0)
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

                    Debug.Log("raycast colidiu");
                     // Verifique se o objeto atingido est� na camada desejada (voc� pode configurar a camada em seu objeto)
                     if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster"))
                     {
                         // Desative o objeto atingido
                         hit.collider.gameObject.SetActive(false);
                     }
                 }
                 Debug.Log(touchPosition);
             }

         }*/




        /*if(Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
        }*/


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
