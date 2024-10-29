/*
# ----------------------------------------------------------------------------------------
#파일이름 : AXe.cs
#작성자 : 장승배
#생성일 : 2024.10.29
#내용 : A/D 버튼을 누르면 오브젝트가 날아가는 코드  
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXe : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 100f;
    [SerializeField] float respawnTime = 5f;

    [SerializeField] bool activate = true;  

    private float time;
    private float moveX2 = 0; 
    
    public float RespawnTime
    {
        get { return respawnTime; } 
    }
    void Update()
    {
        time += Time.deltaTime; 

        if (time < respawnTime)
        {
            if (activate) // A/D 입력을 한 번만 받도록
            {
                float moveX = Input.GetAxis("Horizontal");  
                moveX2 = moveX; 
                activate = false; 
                
            }
            
            transform.Translate(moveX2 * speed * Time.deltaTime, 0, 0);
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
