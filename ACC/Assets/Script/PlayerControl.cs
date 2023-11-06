using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 2f; //이동속도
    public float rotationSpeed = 360f; //방향전환 속도

    CharacterController charCtrl; //캐릭터컨트롤 선언
    Animator anim; //애니메이터 선언

    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude);
    }
}
