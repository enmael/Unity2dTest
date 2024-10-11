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
    private Rigidbody2D rb;
    private Vector2 movement;

    public float Speed
    {
        get { return speed; } 
        set { speed = value; } 
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
    }

    private void Update()
    {
        // 입력 받기 (WASD 또는 화살표 키)
        movement.x = Input.GetAxisRaw("Horizontal");  // 왼쪽(-1), 오른쪽(1)
        movement.y = Input.GetAxisRaw("Vertical");    // 아래(-1), 위(1)
    }

    private void FixedUpdate()
    {
        // Rigidbody2D를 사용하여 이동 처리
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
