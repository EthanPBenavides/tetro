using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausestart : MonoBehaviour
{
    public List<Button> btn = new List<Button>();
    public List<GameObject> children = new List<GameObject>();
    private GameObject current;
    private int timeLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        btn[0].onClick.AddListener(startGame);
        btn[1].onClick.AddListener(pause);
        btn[2].onClick.AddListener(resume);
    }

    void pause(){
        current = GameObject.FindGameObjectWithTag("current"); 
        current.GetComponent<Group>().pause = true;
    }
    void startGame(){
        InvokeRepeating("count", 0.0f, 1.0f);
    }
    void resume(){
        timeLeft = 3;
        InvokeRepeating("count", 0.0f, 1.0f);
        Invoke("unpause", 3.0f);
    }
    void unpause(){
        current = GameObject.FindGameObjectWithTag("current");
        current.GetComponent<Group>().pause = false;
    }

    void count()
    {
        if (timeLeft == 3){
            children[0].SetActive(true);
        }
        if (timeLeft == 2){
            children[0].SetActive(false);
            children[1].SetActive(true);
        }
        if (timeLeft == 1){
            children[1].SetActive(false);
            children[2].SetActive(true);
        }
        if (timeLeft == 0){
            children[2].SetActive(false);
            timeLeft = 3;
            children[3].SetActive(true);
            CancelInvoke("count");
        }
        timeLeft--;
    }
}
