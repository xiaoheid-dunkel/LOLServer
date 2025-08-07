using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.dao.model
{
   public class User
    {
       public int id;//玩家ID 唯一主键
       public string name;//玩家昵称
       public int level;//玩家等级
       public int exp;//玩家经验
       public int winCount;//胜利场次
       public int loseCount;//失败场次
       public int ranCount;//逃跑场次
       public int accountId;//角色所属的帐号ID
       public List<int> heroList;
       public User() {
           level = 0;
           exp = 0;
           winCount = 0;
           loseCount = 0;
           ranCount = 0;
       }
    }
}
