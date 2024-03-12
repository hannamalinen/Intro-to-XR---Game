using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableComponent : MonoBehaviour
{
    public List <GameObject> brakablePieces;
    public float time2break = 2;
    public float timer = 0;

    void Start()
    {
        foreach (var item in brakablePieces)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;
        
        if(timer > time2break) 
        {
            foreach (var item in brakablePieces)
            {
            item.SetActive(true);
            item.transform.parent = null;
            }
            gameObject.SetActive(false);
        } 
    }
}
