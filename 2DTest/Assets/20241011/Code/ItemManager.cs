/*
# ----------------------------------------------------------------------------------------
#파일이름 :ItemManager.cs
#작성자 : 장승배
#생성일 : 2024.10.11
#내용 : 플레이어 주변에 아이템을 랜덤으로 뿌리는 코드 
# ------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject[] Item; 

    public Transform playerTransform;  

    private int count = 0;

    private void Start()
    {
       
       StartCoroutine(ItemSpawen());
        
    }

    IEnumerator ItemSpawen()
    {
        while (true) 
        {
            SpawnPosition();
            count++;
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnPosition()
    {
        int typeMonsters = Item.Length;   
        if (playerTransform != null)
            {
                Vector2 playerPosition = playerTransform.position;

                System.Random rand = new System.Random();

                float xPos = rand.Next((int)playerPosition.x - 20, (int)playerPosition.x + 20);
                float yPos = rand.Next((int)playerPosition.y - 20, (int)playerPosition.y + 20);

                int rannum = rand.Next(0, typeMonsters - 1);

                Vector2 randomPos = new Vector2(xPos, yPos);


                GameObject monster = Instantiate(Item[rannum], randomPos, Quaternion.identity);

                RemoveCloneName(monster);


        }
    }

    void RemoveCloneName(GameObject clone)
    {
        if (clone.name.EndsWith("(Clone)"))
        {
            clone.name = clone.name.Replace("(Clone)", "");
                    
        }
    }

}
