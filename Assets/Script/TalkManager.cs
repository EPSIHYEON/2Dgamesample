using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
   
    void Awake()
    {
       talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }


    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:1" ,"ó������ ���̳�:2" });
        talkData.Add(2000, new string[] { "����? ���Ͼ��� ����?:0" });

        talkData.Add(3000, new string[] { "����� å���̴�" });

        //Quest Talk

        talkData.Add(1000 + 10, new string[] {"� ��: 2" ,
                                               "�� �������� ���� ������ �ִµ�: 1",
                                                    "���� �ǳθ� �ִ� ���̰� �˷��� ����: 2"});

        talkData.Add(11 + 2000, new string[]{"�� ������ ������ �ñ��ϴٰ�?:1",
                                           "ȣ���� ��ģ �ڽ��� ����� ���� ����� �ٸ��� ���δٸ�: 1" ,
                                            "�װ� �� ���� ���̶�� ������ ����: 1",
                                            "�� ������ �������� : 2",
                                             "�ñ��ϸ� ���� �ܼ��� ã�ƺ�, ���ڸ� ������ ��������? :1"});


        talkData.Add(20 + 5000, new string[] { "ȣ���� ������ ����� �ִ�." });


        talkData.Add(20 + 1000, new string[] {"ȣ���� ����� ����̷�: 1",
                                              "������ �� �ҸӴϴ� ȣ���� ������ ���� �����̴µ�: 1",
                                               "ȣ���� ����� �ڽ��� ����� �ٸ��ٰ� ���Ͻ��� 3�� �ڿ� ���ư��̾�: 3"});
        talkData.Add(20 + 2000, new string[] {"�絵�� �׷�?: 1 ",
                                                "�͸����� ������ ���� ����ó�� ���̰� �ϱ⵵ ����:1",
                                                "�� ȣ���� ������ ���� �ʾ�, ��ΰ� �׷� �� �ƴϿ��ŵ�: 0"});






        portraitData.Add(1000 + 0 , portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);





    }



    public string GetTalk(int id, int talkIndex)
    {//�ش� ����Ʈ ���� �� ��簡 ���� ��
        //Ű�� 1�� ������ �͵� 0���� ������ �͵� ������ �ǰ� �ϴ� ��
        //�ڰ� 0�϶� %100

        if (!talkData.ContainsKey(id))
        {

            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
                return GetTalk(id - id % 10, talkIndex);
        }


        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];


    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
