/*
# ----------------------------------------------------------------------------------------
#파일이름 :Move.cs
#작성자 : 장승배
#생성일 : 2024.09.02
#내용 : 플레이어 캐릭터의 움직임을 구현 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
  public float speed = 5f;  // 이동 속도
    [SerializeField] Rigidbody2D rb;
    private Vector2 movement;

    public float Speed
    {
        get { return speed; } 
        set { speed = value; } 
    }

//#-------------------------
// 추가 날짜 : 2024.10.30
    public Vector2 Movement
    {
        get { return movement; } 
    }
//#---------------------------


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        // 입력 받기 (WASD 또는 화살표 키)
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
