using System.Collections;
using UnityEngine;
public class SwapenManager : MonoBehaviour
{
   public Transform playerTransform;
    private int count = 0;

    [SerializeField] GameObject[] gameObjects; // 오브젝트 배열
    [SerializeField] int monstersNumber; // 몬스터 소환할 갯수 
    [SerializeField] float spawnTime; // 몬스터가 스폰하는 시간

    private void Start()
    {
        // 코루틴으로 지정한 시간마다 몬스터 소환 시작
        StartCoroutine(MonsterSpawn());
    }

    IEnumerator MonsterSpawn()
    {
        while (count < monstersNumber)
        {
            SpawnPosition();
            count++;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnPosition()
{
    if (playerTransform != null)
    {
        // 플레이어 주변 랜덤 위치 생성
        float xPos = UnityEngine.Random.Range(playerTransform.position.x - 20f, playerTransform.position.x + 20f);
        float yPos = UnityEngine.Random.Range(playerTransform.position.y - 20f, playerTransform.position.y + 20f);
        Vector2 randomPos = new Vector2(xPos, yPos);

        // 랜덤 몬스터 타입 선택
        int randomIndex = UnityEngine.Random.Range(0, gameObjects.Length);
        GameObject monster = Instantiate(gameObjects[randomIndex], randomPos, Quaternion.identity);

        // 소환된 몬스터에 플레이어 Transform 설정
        MonsterChase monsterChase = monster.GetComponent<MonsterChase>();
        if (monsterChase != null)
        {
            monsterChase.SetPlayerTransform(playerTransform);
        }

        // 클론 이름 정리
        RemoveCloneName(monster);
    }
}


    // Clone을 제거하고 고유 이름 생성
    void RemoveCloneName(GameObject clone)
    {
        if (clone.name.EndsWith("(Clone)"))
        {
            clone.name = clone.name.Replace("(Clone)", "") + count;
        }
    }
}
