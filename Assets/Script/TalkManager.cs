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
        talkData.Add(1000, new string[] { "안녕?:1" ,"처음보는 얼굴이네:2" });
        talkData.Add(2000, new string[] { "뭐야? 볼일없음 가지?:0" });

        talkData.Add(3000, new string[] { "평범한 책상이다" });

        //Quest Talk

        talkData.Add(1000 + 10, new string[] {"어서 와: 2" ,
                                               "이 마을에는 놀라운 전설이 있는데: 1",
                                                    "왼쪽 건널목에 있는 새미가 알려줄 꺼야: 2"});

        talkData.Add(11 + 2000, new string[]{"이 마을의 전설이 궁금하다고?:1",
                                           "호수에 비친 자신의 모습이 실제 모습과 다르게 보인다면: 1" ,
                                            "그건 곧 죽을 것이라는 전설이 있지: 1",
                                            "뭐 전설일 뿐이지만 : 2",
                                             "궁금하면 직접 단서를 찾아봐, 상자를 뒤지면 나올지도? :1"});


        talkData.Add(20 + 5000, new string[] { "호수의 전설은 비밀이 있다." });


        talkData.Add(20 + 1000, new string[] {"호수의 비밀은 사실이래: 1",
                                              "실제로 내 할머니는 호수의 전설을 굳게 믿으셨는데: 1",
                                               "호수의 모습과 자신의 모습이 다르다고 말하신지 3일 뒤에 돌아가셨어: 3"});
        talkData.Add(20 + 2000, new string[] {"루도가 그래?: 1 ",
                                                "맹목적인 믿음은 때론 진실처럼 보이게 하기도 하지:1",
                                                "난 호수의 전설을 믿지 않아, 모두가 그런 건 아니였거든: 0"});






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
    {//해당 퀘스트 진행 중 대사가 없을 때
        //키가 1로 끝나는 것도 0으로 끝나는 것도 실행이 되게 하는 법
        //뒤가 0일때 %100

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
