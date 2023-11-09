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

        //}  //문장을 넘기고 싶지 않을 때 SPACE 바를 한번만 누를 수 있는 양의 멘트를 치고 싶을 때 사용

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
            talkIndex = 0;    /////되돌려주어야함
            Debug.Log(questManager.CheckQuest(id));
            return;  //void 에서 return은 강제 종료 역할
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));   /////PARSE 는 형변환 함수 
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
