using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public GameManager GameManager;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject ScanObject;
    Rigidbody2D rigid;
    Animator anim;

     void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = GameManager.isAction ? 0 :  Input.GetAxisRaw("Horizontal");     ////////////////상태창이 나올때는 캐릭터가 정지하게 삼항연산자 사용
        v = GameManager.isAction ? 0 :  Input.GetAxisRaw("Vertical");

        bool hDown = GameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = GameManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = GameManager.isAction ? false :  Input.GetButtonUp("Horizontal");
        bool vUp = GameManager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;

        else if (hUp || vUp)
            isHorizonMove = h != 0;


        //다른 모션을 받아드리지 못해 멈춰버리는 애니매이션 해결하는 법
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);

        }
        else
            anim.SetBool("isChange", false);



        //레이저 방향을 조절하기 위한 벡터 조절
        if (vDown && v == 1)
            dirVec = Vector3.up;
       else if (vDown && v == -1)
            dirVec = Vector3.down;
       else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;


        //Scan Object

        if (Input.GetButtonDown("Jump") && ScanObject != null)
            GameManager.Action(ScanObject);

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);  //대각선 못하게 하는 거
        rigid.velocity = moveVec * 10;

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            ScanObject = rayHit.collider.gameObject;
        }
        else
            ScanObject = null;
    }
}
