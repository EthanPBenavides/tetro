using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNext : MonoBehaviour
{
    public List<GameObject> next = new List<GameObject>();
    public Spawner sp;
    public Transform parent;
    int count;
    public bool Start = false;


    void Update()
    {
        if (Start == true){
            changePiece(checkPiece());
        }
    }

    int checkPiece(){
        string name = sp.groups[sp.next].name;
        switch (name) {
            case "i":
                return 0;
            case "j":
                return 1;
            case "l":
                return 2;
            case "o":
                return 3;
            case "s":
                return 4;
            case "z":
                return 5;
            case "t":
                return 6;
            default 
        }
    }

    void changePiece(int i){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        Instantiate(next[i], transform.position, Quaternion.identity, parent);
    }
}
