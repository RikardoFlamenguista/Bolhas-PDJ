using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ColliderCheck : MonoBehaviour
{

    public List<GameObject> coracoes = new List<GameObject>();
     

    public GameObject gameoverMenu;
    public GameObject winMenu;

    private int vida = 3;
    private float seconds = 0;
    public Text text;
    private float timer;


    private void Start()
    {
        Time.timeScale = 1;


    }

    private void Update()
    {

      

        seconds += 1 * Time.deltaTime;
        timer = seconds;



        int timerSeconds = Mathf.FloorToInt(timer);
        text.text = timerSeconds.ToString();

        if (seconds >= 20) Win();

    }

    void OnTriggerStay(Collider other)
    {
        

         if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
         {
             other.gameObject.SetActive(false);

            PerderVida();



         }
    }

    private void PerderVida()
    {
        coracoes[vida-1].SetActive(false);
        vida--;

        if (vida <= 0) GameOver();
    }

    public void GameOver()
    {
        gameoverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;

    }


        }
