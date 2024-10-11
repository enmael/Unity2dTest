/*
# ----------------------------------------------------------------------------------------
#파일이름 :HP.cs
#작성자 : 장승배
#생성일 : 2024.10.11
#내용 :플레이어게 충돌 하면 hp up 이라고 뜨는 코드 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "player");
        {
            Debug.Log("Hp up");
        }
    }
}
