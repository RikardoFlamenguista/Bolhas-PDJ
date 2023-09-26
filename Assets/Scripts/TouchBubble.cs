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
                    // Obtenha a posição do toque na tela
                    Vector3 touchPositionScreen = new Vector3(touch.position.x, touch.position.y, 0);

                    // Defina a distância a partir da câmera (ajuste conforme necessário)
                    float distanceFromCamera = 10;

                    // Converta a posição do toque em uma posição no mundo
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPositionScreen.x, touchPositionScreen.y, distanceFromCamera));


                    touchPosition.z = -10;

                    // Lance um raio a partir da posição do toque na direção da câmera
                    Ray ray = new Ray(touchPosition, Camera.main.transform.forward);

                    // Crie uma variável RaycastHit para armazenar informações sobre o objeto atingido
                    RaycastHit hit;



                    
                   
                    // Verifique se o raio atingiu um objeto na cena
                     if (Physics.Raycast(ray, out hit))
                     {
                         Debug.Log("raycast acertou algo");
                         // Verifique se o objeto atingido está na camada desejada (você pode configurar a camada em seu objeto)
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
                 // Obtenha a posição do toque no mundo
                 Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

                 // Lance um raio a partir da posição do toque na direção da câmera
                 Ray ray = new Ray(touchPosition, Camera.main.transform.forward);

                 // Crie uma variável RaycastHit para armazenar informações sobre o objeto atingido
                 RaycastHit hit;

                 // Verifique se o raio atingiu um objeto na cena
                 if (Physics.Raycast(ray, out hit))
                 {

                    Debug.Log("raycast colidiu");
                     // Verifique se o objeto atingido está na camada desejada (você pode configurar a camada em seu objeto)
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


        /*
        #if UNITY_EDITOR

              if(Input.GetMouseButtonDown(0))
        {

            Vector3 clickPositionScreen = Input.mousePosition;

            float distanceFromCamera = 10;

            Vector3 clickPositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(clickPositionScreen.x, clickPositionScreen.y, distanceFromCamera));



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
