using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRod : MonoBehaviour
{
     [SerializeField] Transform player;
    [SerializeField] float speed = 100f;
    [SerializeField] float respawnTime = 5f;

    [SerializeField] bool activate = true;  

    private float time;
    private float moveX2 = 0; 

   [SerializeField] GameObject heatRodobject;

   private void Start() 
   {
        Vector3 playerPosition = player.position;
        transform.position = playerPosition;
        heatRodobject.SetActive(false);  
   }

    void Update()
    {
        time += Time.deltaTime; 

        if (time < respawnTime)
        {
            
            if (activate == true) // A/D 입력을 한 번만 받도록
            {
                float moveX = Input.GetAxis("Horizontal");  
                moveX2 = moveX; 
                activate = false; 
                
            }

            if(moveX2 == 0)
            {
                // 움직이지 않을때는 한 방향으로만 날라감 
                 //transform.Translate(1 * speed * Time.deltaTime, 0, 0);
                 heatRodobject.transform.localScale = new Vector3(10, 1);    
            }
           
            //transform.Translate(moveX2 * speed * Time.deltaTime, 0, 0);
            heatRodobject.transform.localScale = new Vector3(10, 1); 
        }
        else
        {
            Vector3 playerPosition = player.position;
            transform.position = playerPosition;
            time = 0; 
            activate = true;
        }

        
    }
  
}
