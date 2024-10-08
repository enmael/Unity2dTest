/*
# ----------------------------------------------------------------------------------------
#�����̸� :RandomSpawn.cs
#�ۼ��� : ��¹�
#������ : 2024.10.08
#���� : �ڷ�ƾ�� ������ �ð����� ������ ���͸� 
        �÷��̾� ��ġ �������� �����ϰ� ���� �ϴ� ��� 
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

    //������Ʈ �ҷ�����
    [SerializeField] GameObject[] gameObject;
    //���� ��ȯ�� ���� 
    [SerializeField] int monstersNumber;
    //���Ͱ� �����ϴ� �ð� 
    [SerializeField] float spawnTime;

    private void Start()
    {
       //�ڷ�ƾ 
       StartCoroutine(MonsterSpawen());
        
    }

    //�ڷ�ƾ���� ������ �ð����� ���� �����ϱ�
    IEnumerator MonsterSpawen()
    {
        while (count < monstersNumber) 
        {
            SpawnPosition();
            count++;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    //�÷��̾� ��ġ ��� ���� ������ ��ġ�� ���� �����ϱ� 
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

    //clone �����ϰ� �̸��ڿ� ���� �߰��ϴ� �ڵ�
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
