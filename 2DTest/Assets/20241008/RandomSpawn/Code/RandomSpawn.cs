/*
# ----------------------------------------------------------------------------------------
#파일이름 :RandomSpawn.cs
#작성자 : 장승배
#생성일 : 2024.10.08
#내용 : 코루틴을 지정한 시간동안 지정한 몬스터를 
        플레이어 위치 기준으로 랜덤하게 스폰 하는 기능 
# ------------------------------------------------------------------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform playerTransform; 
    private float timeElapsed = 0; 

    private int count = 0;

    //오브젝트 불러오기
    [SerializeField] GameObject[] gameObject;
    //몬스터 소환할 갯수 
    [SerializeField] int monstersNumber;
    //몬스터가 스폰하는 시간 
    [SerializeField] float spawnTime;

    private void Start()
    {
       //코루틴 
       StartCoroutine(MonsterSpawen());
        
    }

    //코루틴으로 지정한 시간마다 몬스터 스폰하기
    IEnumerator MonsterSpawen()
    {
        while (count < monstersNumber) 
        {
            SpawnPosition();
            count++;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    //플레이어 위치 기반 으로 랜덤한 위치에 몬스터 스폰하기 
    void SpawnPosition()
    {
        int typeMonsters = gameObject.Length;   
        if (playerTransform != null)
            {
                Vector2 playerPosition = playerTransform.position;

                System.Random rand = new System.Random();

                float xPos = rand.Next((int)playerPosition.x - 20, (int)playerPosition.x + 20);
                float yPos = rand.Next((int)playerPosition.y - 20, (int)playerPosition.y + 20);

                int rannum = rand.Next(0, typeMonsters - 1);

                Vector2 randomPos = new Vector2(xPos, yPos);


                GameObject monster = Instantiate(gameObject[rannum], randomPos, Quaternion.identity);

                RemoveCloneName(monster);


        }
    }

    //clone 삭제하고 이름뒤에 숫자 추가하는 코드
    void RemoveCloneName(GameObject clone)
    {
        if (clone.name.EndsWith("(Clone)"))
        {
            clone.name = clone.name.Replace("(Clone)", "");
            clone.name = clone.name + count;
            //Debug.Log(clone.name);
        }
    }

}
