using Entities;
using Entities.Messages;
using Entities.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayerAcces
{
    public class UserManager : ManagerBase<User>
    {
        public BusinesLayerResult<User> LoginUser(UserLoginModel data)
        {

            BusinesLayerResult<User> res = new BusinesLayerResult<User>
            {
                Result = Find(x => x.TCKN == data.TCKimlik && x.DogumTarihi == data.DogumTarihi)
            };
            if (res.Result != null)
            {
                return res;
            }
            else
            {
                res.Errors.Add("T.C Kimlik ya da Doğum Tarihi Bulunamadı.");
            }
            return res;
        }
        public BusinesLayerResult<User> GetUserById(int id)
        {
            BusinesLayerResult<User> res = new BusinesLayerResult<User>();
            if (res.Result == null)
            {
                res.AddError(ErrorMessage.UserNotFound, "Kullanıcı bulunamadı.");
            }
            return res;
        }



    }
}
