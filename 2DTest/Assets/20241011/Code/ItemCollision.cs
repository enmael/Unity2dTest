/*
# ----------------------------------------------------------------------------------------
#파일이름 :ItemCollision.cs
#작성자 : 장승배
#생성일 : 2024.10.11
#내용 : 아이템에 플레이어가 충돌하면 아이템 효과가 나타나면서 아이템 오브젝트가 비활성화 되는 코드 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{

    [SerializeField] public GameObject[]item;

    private move Move;
    private void Start()
    {
      
        Move = FindObjectOfType<move>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        for(int i = 0; i < item.Length; i++)
        {
            if(other.gameObject.name == item[i].name)
            {
                ItemFunction(other.gameObject);
            }
        }   

    }

    private void ItemFunction(GameObject gameObject)
    {
        if(gameObject.name =="HpItem")
        {
            Debug.Log("Hp up");
        }    

        if(gameObject.name =="SpeedItem")
        {
            Move.Speed = Move.Speed+1f;
            Debug.Log("Spped up:" + Move.Speed);
            gameObject.SetActive(false);
        }

    }
    
}
