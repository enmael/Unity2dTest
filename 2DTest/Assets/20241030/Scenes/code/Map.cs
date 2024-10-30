/*
# ----------------------------------------------------------------------------------------
#파일이름 :Map.cs
#작성자 : 장승배
#생성일 : 2024.10.30
#내용 : x축 기준으로 만든 무한 맵 코드이다.
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(move))]
public class Map : MonoBehaviour
{   
    [SerializeField]List<GameObject>list;    
    move Move;

    int number;
    private void Start() 
    {
        Move = GetComponent<move>();

        list.Capacity = 10; 
    }

    private void Update() 
    {
        Debug.Log("x :" + Move.Movement.x);
    
        if (list != null && list.Count > 0)
        {
            //right(1) left(-1)
            Vector2 vectorRight = new Vector2(40,0);
            Vector2 vectorLeft= new Vector2(-40,0);

            if(Move.Movement.x  > 0)
            {   
                Vector2 listA =list[0].transform.position;
                listA = listA +  vectorRight;
                list[0].transform.position = listA;
                //list[0].gameObject.SetActive(true);
                list.RemoveAt(0);
                 
            }
            else if(Move.Movement.x <0)
            {
                 Vector2 listA =list[0].transform.position;
                listA = listA +  vectorLeft;
                list[0].transform.position = listA;
                //list[0].gameObject.SetActive(true);
                list.RemoveAt(0);
            }
        }   
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject gameObject= other.gameObject;
        if (other.CompareTag("floor"))
        {
            //gameObject.SetActive(false);
            list.Add(gameObject);
        }
    }

}
