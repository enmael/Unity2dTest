/*
# ----------------------------------------------------------------------------------------
#파일이름 :Monster.cs
#작성자 : 장승배
#생성일 : 2024.12.30
#내용 : 몬스터 오브젝트를 지정된 위치에 이동후 다음 지정 위치로 이동시키는 코드이다 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
  [SerializeField] Transform target; // 추적할 타겟 오브젝트

  [SerializeField] Transform [] trackingGameObject; //추적당할 오브젝트 목록 

  [SerializeField] int number = 0;
  [SerializeField] bool nextbool = true;

  public float speed = 5.0f; // 이동 속도 
  void Update() 
  { 
    Move();
    NextTarget();
  }

  private void Move() // 몬스터 이동 
  {
    // 타겟 방향 계산 
    Vector2 direction = target.position - transform.position; 
    direction.Normalize(); 

    // 몬스터 이동 
    transform.Translate(direction * speed * Time.deltaTime); 

  }

  private void NextTarget() // 다음 몬스터 타켓위치를 지정한느 코드  
  {
    
    if(target.position == transform.position && nextbool ==true)
    {
        if(number <= 3)
        {
            number++;
            nextbool = false;
            target = trackingGameObject[number];
            if(number == 3)
            {
                number = -1;
            }
        }
    }
    else
    {
        nextbool = true;
    }
  }

}
