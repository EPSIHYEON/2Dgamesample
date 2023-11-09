using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator Panel;
    public TypeEffect talk;
    public Image portraitImg;
    public Animator portraitAnim;
    public Sprite prevPortrait;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;



    void Start()
    { 


        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
        //if (isAction) //Exit Action
        //{
        //    isAction = false;
        //}
        //else //Enter Action
        //{
        //    isAction = true;
        //    scanObject = scanObj;
        //    ObjData objdata = scanObject.GetComponent<ObjData>();
        //    Talk(objdata.id, objdata.isNpc);

        //}  //������ �ѱ�� ���� ���� �� SPACE �ٸ� �ѹ��� ���� �� �ִ� ���� ��Ʈ�� ġ�� ���� �� ���

        scanObject = scanObj;
        ObjData objdata = scanObject.GetComponent<ObjData>();
        Talk(objdata.id, objdata.isNpc);
        Panel.SetBool("isShow", isAction);
    }
    void Talk(int id, bool isNpc)
    {
        int questTalkIdex =0;
         string talkData= "";

        if (talk.isAnimation)
        {
            talk.SetMsg("");
            return;

        }
        else
        {
        questTalkIdex = questManager.GetQuestTalkIdex(id);
        //Set talk data
        talkData = talkManager.GetTalk(id + questTalkIdex, talkIndex);

        }
        //End Talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;    /////�ǵ����־����
            Debug.Log(questManager.CheckQuest(id));
            return;  //void ���� return�� ���� ���� ����
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));   /////PARSE �� ����ȯ �Լ� 
            portraitImg.color = new Color(1, 1, 1, 1);

            if(prevPortrait != portraitImg.sprite)
            {
            portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;

            }
        }

        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
