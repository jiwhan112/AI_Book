using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 메시지 발송 관리
/// 이벤트 설정해줌
/// </summary>
public class MessageDispatcher : Singleton<MessageDispatcher>
{
    List<MAGADATA.Telegram> mListDelayMsg;

    private void Start()
    {
        mListDelayMsg = new List<MAGADATA.Telegram>();
    }

    private void Update()
    {
        DispatchDelayedMessages();

    }
    // 전보전달
    void Discharge(Miner Reciver, MAGADATA.Telegram msg)
    {

    }



    // 다른에이전트에게 메시지를 보냄
    public void DispatchMessage(float delayTime,int Sender, int Receiver, int Msg, object Extrainfo)
    {
        Miner ReceiverMiner = MinerGameManager.I.GetMiner(Receiver);
        MAGADATA.Telegram tel = new MAGADATA.Telegram(0, Sender, Receiver, Msg, Extrainfo);

        // 지연될 필요가 없으면 발송
        if (delayTime <= 0.0f)
            Discharge(ReceiverMiner, tel);
        else //시간 계산
        {
            tel.DispatchTime = delayTime;
            mListDelayMsg.Add(tel);
        }
    }

    // 지연된 모든 메시지를 보냄  // 딜레이시간이 0이 아닐때 시간 계산
    // 게임의 주 루프를 통해서 매번 호출
    public void DispatchDelayedMessages()
    {
        foreach (var item in mListDelayMsg)
        {
            if (item.DispatchTime > 0)
                item.DispatchTime -= Time.deltaTime;
            else
            {
                Miner s = MinerGameManager.I.GetMiner(item.Receiver);
                Discharge(s, item);
                mListDelayMsg.Remove(item);
            }
        }
    }

}
