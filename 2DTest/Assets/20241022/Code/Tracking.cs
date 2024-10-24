using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D target; // 추적할 대상
    public Rigidbody2D rigid; // 몬스터의 Rigidbody2D 컴포넌트
    private SpriteRenderer sprite; // 몬스터의 SpriteRenderer 컴포넌트


    private void Awake()
    {
        // 컴포넌트 초기화
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        barrage();
        
    }

    public void barrage()
    {
        Vector3 playerPosition = target.position;
        // 플레이어 위치로 향하는 방향 벡터 계산
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexVec = dirVec.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nexVec);
    }
}
