/*
# ----------------------------------------------------------------------------------------
#파일이름 :ThorwAxe.cs
#작성자 : 장승배
#생성일 : 2024.10.29
#내용 : 오브젝트가 회전하게 하는 코드 
# ------------------------------------------------------------------------------------------
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorwAxe : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 300f;
    
    [SerializeField]Collider2D myCollider;
    void Start()
    {  
        myCollider = GetComponent<Collider2D>();

        StartCoroutine(myColliderCoroutine());
       
    }
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1), rotationSpeed * Time.deltaTime);  
    }
    IEnumerator myColliderCoroutine()
    {
       while (true)
        {
            // 콜라이더 비활성화
            myCollider.enabled = false;
            yield return new WaitForSeconds(0.5f);

            // 콜라이더 활성화
            myCollider.enabled = true;
            yield return new WaitForSeconds(2.5f);
        }
        
        
    }
    
}
