using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingManager : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] GameObject boxing1;
    //[SerializeField] GameObject boxing2;
    
    [SerializeField] float speed = 100f;
    [SerializeField] float respawnTime = 1f;

    [SerializeField] bool activate = true;  

    private float time;

    private float moveX2 = 0; 

    private void Start() 
    {
        boxing1.SetActive(false);
        //boxing2.SetActive(false);
        Vector3 playerPosition = player.position;
        transform.position = playerPosition;
    }

    private void Update()
    {
        time += Time.deltaTime; 

        if (time < respawnTime)
        {
            
            if (activate == true) // A/D 입력을 한 번만 받도록
            {
                float moveX = Input.GetAxis("Horizontal");  
                moveX2 = moveX; 
                activate = false;
                boxing1.SetActive(true);
                
            }
            
            boxing1.transform.Translate(moveX2 * speed * Time.deltaTime, 0, 0);
            
        }
        else
        {
            Vector3 playerPosition = player.position;
            transform.position = playerPosition;
            time = 0; 
            activate = true;
            boxing1.SetActive(false);
        } 
    }
}
