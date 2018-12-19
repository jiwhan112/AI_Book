using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAGADATA {
    /// <summary>
    /// AI 관련 
    /// </summary>
    public enum LocationType
    {
        HOME,
        WORK,
        BAR,
        BANK
    }

    /// <summary>
    /// 전보 AI 관련 
    /// </summary>
    
    public class Telegram
    {
        public int Sender;
        public int Receiver;
        public int Msg;
        public double DispatchTime;
        public object EXInfo;

        public Telegram(double dispatchTime, int sender, int receiver, int msg, object eXInfo)
        {
            DispatchTime = dispatchTime;
            Sender = sender;
            Receiver = receiver;
            Msg = msg;

            EXInfo = eXInfo;
        }
    }
    public enum MessageTYPE
    {
        MSG_Exhaustion, // 탈진이벤트
        MSG_GOWORK,
    }
    public enum EntityType
    {
        Default,
        Runner,
        Knight,
    }

}
