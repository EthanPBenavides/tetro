using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Group : MonoBehaviour
{
    float lastFall = 0;
    bool down = false;
    bool up = false;
    public bool pause = false;
    //public float t;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag="current";
        if (!isValidGridPos()) 
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
    void Update() 
    {
        while (up == true)
        {
            transform.position = transform.position + new Vector3(0,-1,0);
            if (isValidGridPos()) {
                updateGrid();
            } else {
                transform.position = transform.position + new Vector3(0,1,0);
                up = false;
            }
        }

        if (down == true || Time.time-lastFall >= info.t && pause == false) 
        {
            transform.position = transform.position + new Vector3(0,-1,0);
            if (isValidGridPos()) {
                updateGrid();
            } else {
                transform.position = transform.position + new Vector3(0,1,0);
                down = false;

                // Clear filled horizontal lines
                PlayField.deleteFullRows();
                // Spawn next piece
                FindObjectOfType<Spawner>().spawnNext();
                // Disable script
                gameObject.tag="";
                enabled = false;
            }
            lastFall = Time.time;
            down = false;
        }
    }
    public void OnMove(InputValue input)
    {
        if (enabled == true) {
            Vector3 inputVec = input.Get<Vector3>();
            Vector3 tempVect = new Vector3(1*inputVec.x, 0, 0);
            transform.position += tempVect;
            if (inputVec.y < 0) down = true;
            if (inputVec.y > 0) up = true;
            if (isValidGridPos())
            {
                updateGrid();
            }
            else {
                transform.position -= tempVect;
            }
        }
    }
    public void OnRotate(InputValue input)
    {
        if (enabled == true) {
        float x = input.Get<float>();
        transform.Rotate(0, 0, x*90f);
        if (isValidGridPos())
        {
            updateGrid();
        }
        else 
        {
            transform.Rotate(0, 0, -(x*90f));
        }
        }
    }

    bool isValidGridPos() 
    {        
    foreach (Transform child in transform) {
        Vector2 v = PlayField.roundVec2(child.position);

        // Not inside Border?
        if (!PlayField.insideBorder(v))
            return false;

        // Block in grid cell (and not part of same group)?
        if (PlayField.grid[(int)v.x, (int)v.y] != null &&
            PlayField.grid[(int)v.x, (int)v.y].parent != transform)
            return false;
    }
    return true;
    }

    void updateGrid() 
    {
    // Remove old children from grid
    for (int y = 0; y < PlayField.h; ++y)
        for (int x = 0; x < PlayField.w; ++x)
            if (PlayField.grid[x, y] != null)
                if (PlayField.grid[x, y].parent == transform)
                    PlayField.grid[x, y] = null;

    // Add new children to grid
    foreach (Transform child in transform) {
        Vector2 v = PlayField.roundVec2(child.position);
        PlayField.grid[(int)v.x, (int)v.y] = child;
        }        
    }
}
