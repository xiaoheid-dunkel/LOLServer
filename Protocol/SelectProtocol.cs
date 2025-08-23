using System;
using System.Collections.Generic;
using System.Text;

namespace GameProtocol
{
    /// <summary>
    /// 选择协议
    /// </summary>
    public class SelectProtocol
    {
       public const int ENTER_CREQ = 0;//进入选择场景
        public const int ENTER_SRES = 1;//返回进入结果
        public const int ENTER_EXBRO = 2;//广播进入
        public const int SELECT_CREQ = 3;//选择角色
        public const int SELECT_SRES = 4;//返回选择结果
        public const int SELECT_BRO = 5;//广播选择
        public const int TALK_CREQ = 6;//聊天请求
        public const int TALK_BRO = 7;//广播聊天
        public const int READY_CREQ = 8;//准备请求
        public const int READY_BRO = 9;//广播准备
        public const int DESTORY_BRO = 10;//广播销毁
        public const int FIGHT_BRO = 11;//广播开始战斗
    }
}
