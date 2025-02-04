/*
# ----------------------------------------------------------------------------------------
#파일이름 : Dash.cs
#작성자 : 장승배
#생성일 : 2024.11.04
#내용 : 스페이스 키를 누르면 무적 대쉬를 하는 코드 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Collider2D playerCollider; 
    [SerializeField] float distance = 5f; // 대시 거리
    [SerializeField] float dashTime = 0.2f; // 대시 지속 시간
    [SerializeField] float dashCoolTime = 3f; // 대시 쿨타임

    private bool DasBool = true; // 대시 가능 여부

    private void Update() 
    {
        // 수평 이동 입력 감지
        float moveX = Input.GetAxis("Horizontal");

        // 스페이스 키를 눌렀을 때 대시 동작 실행
        if (Input.GetKeyDown(KeyCode.Space) && DasBool)
        {
            StartCoroutine(DashCoroutine(moveX));
                
        }
    }

    private IEnumerator DashCoroutine(float moveX)
    {
        DasBool = false; // 대시 사용 중 불가능 설정
        playerCollider.isTrigger = true;
        Vector2 startPosition = player.position;
        Vector2 targetPos; 
        if(moveX > 0)
        {
           targetPos =startPosition + new Vector2(distance, 0);
        }
        else
        {
           targetPos = startPosition + new Vector2(-distance, 0);
        }


        float elapsed = 0f;
        while (elapsed < dashTime)
        {
            // 현재 시간에 따른 부드러운 이동
            float t = elapsed / dashTime;
            player.position = Vector2.Lerp(startPosition, targetPos,t);
            elapsed += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }

        // 대시가 끝난 후 최종 위치 설정
        player.position = targetPos;
        playerCollider.isTrigger = false;
        Debug.Log("대쉬 사용 가능");
        // 대시 재사용 대기
        yield return new WaitForSeconds(dashCoolTime);
        DasBool = true; // 대시 가능 설정
    }
}
