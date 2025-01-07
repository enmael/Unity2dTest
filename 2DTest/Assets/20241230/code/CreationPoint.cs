// /*
// # ----------------------------------------------------------------------------------------
// #파일이름 :CreationPoint.cs
// #작성자 : 장승배
// #생성일 : 2025.01.02
// #내용 : 몬스터를 지정한숫자 만큼 지정한 시간간격으로 스폰하고 스폰을 멈추는 코드  
// # ------------------------------------------------------------------------------------------
// */


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CreationPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;  // 스폰 위치
    [SerializeField] GameObject monster;    // 스폰할 몬스터
    [SerializeField] int monsterNumber;     // 스폰할 몬스터 수
    [SerializeField] float spawnTime;       // 스폰 시간
    [SerializeField] int copyNumber;        // 확인용

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnTime);
            if (monsterNumber == copyNumber)
               yield break;
            SpawnObjects();
        }
    }

    private void SpawnObjects()
    {
        Instantiate(monster, spawnPoint.position, Quaternion.identity);
        copyNumber++;
    }
}

