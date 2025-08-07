using LOLServer.dao.model;
using NetFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLServer.cache.impl
{
   public class UserCache:IUserCache
    {
       /// <summary>
       /// 用户ID和模型的映射表
       /// </summary>
       Dictionary<int, User> idToModel = new Dictionary<int, User>();
       /// <summary>
       /// 帐号ID和角色ID之间的绑定
       /// </summary>
       Dictionary<int, int> accToUid = new Dictionary<int, int>();

       Dictionary<int, UserToken> idToToken = new Dictionary<int, UserToken>();
       Dictionary<UserToken, int> tokenToId = new Dictionary<UserToken, int>();
       int index = 0;

       public bool create(NetFrame.UserToken token, string name, int accountId)
        {
            User user = new User();
            user.name = name;
            user.id = index++;
            user.accountId = accountId;
            List<int> list = new List<int>();
            for (int i = 1; i < 9; i++) {
                list.Add(i);
            }
            user.heroList = list;
                //创建成功 进行帐号ID和用户ID的绑定
                accToUid.Add(accountId, user.id);
           //创建成功 进行用户ID和用户模型的绑定
            idToModel.Add(user.id, user);
            return true;
        }

        public bool has(NetFrame.UserToken token)
        {
            return tokenToId.ContainsKey(token);
        }

        public bool hasByAccountId(int id)
        {
            return accToUid.ContainsKey(id);
        }

        public dao.model.User get(NetFrame.UserToken token)
        {
            if(!has(token))return null;

            return idToModel[tokenToId[token]];
        }

        public dao.model.User get(int id)
        {
            return idToModel[id];
        }

        public void offline(NetFrame.UserToken token)
        {
            if (tokenToId.ContainsKey(token)) {
                if (idToToken.ContainsKey(tokenToId[token])) {
                    idToToken.Remove(tokenToId[token]);
                }
                tokenToId.Remove(token);
            }
        }

        public NetFrame.UserToken getToken(int id)
        {
            return idToToken[id];
        }


        public User online(UserToken token, int id)
        {
            idToToken.Add(id, token);
            tokenToId.Add(token, id);
            return idToModel[id];
        }

        public User getByAccountId(int accId)
        {
            if (!accToUid.ContainsKey(accId)) return null;

            return idToModel[accToUid[accId]];

        }


        public bool isOnline(int id)
        {
            return idToToken.ContainsKey(id);
        }
    }
}
