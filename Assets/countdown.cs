using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class countdown : MonoBehaviour 
{
    public List<GameObject> children = new List<GameObject>();

    void Awake(){
        children[3].SetActive(true);
        System.Threading.Thread.Sleep(1000);
        children[3].SetActive(false);
        children[2].SetActive(true);
        System.Threading.Thread.Sleep(1000);
        children[2].SetActive(false);
        children[1].SetActive(true);
        System.Threading.Thread.Sleep(1000);
        children[1].SetActive(false);
        children[4].SetActive(true);
    }
}