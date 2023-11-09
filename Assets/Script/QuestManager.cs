using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questobject;

    Dictionary<int, QuestData> questlist;

    void Awake()
    {
        questlist = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questlist.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] {1000, 2000 }));
        questlist.Add(20, new QuestData("ȣ���� ��� �˾Ƴ���", new int[] { 2000, 5000 }));
        questlist.Add(30, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));
    }

   public int GetQuestTalkIdex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        

        if(id == questlist[questId].npcId[questActionIndex])
        questActionIndex++;

        ControlObject();


        if (questActionIndex == questlist[questId].npcId.Length)
            NextQuest();

        return questlist[questId].questName;
    }

    public string CheckQuest()
    {
        return questlist[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex ==2)
                    questobject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questobject[0].SetActive(false);
                break;
        }
    }
}
