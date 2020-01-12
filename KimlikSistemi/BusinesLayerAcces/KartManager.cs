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
  public  class KartManager:ManagerBase<Kart>
    {
        public BusinesLayerResult<Kart> CartUser(KartModelViews data)
        {

            BusinesLayerResult<Kart> kart = new BusinesLayerResult<Kart>
            {
                Result = Find(x => x.KartSahibiAdSoyad == data.NameSurname && x.KartNumarasi == data.KartNumarasi && x.CVV==data.CVV && x.Ay==data.Ay&&x.Yil==data.Yil)
            };
            if (kart.Result != null)
            {
                return kart;
            }
            else
            {
                kart.Errors.Add("Kart Bilgileri Bulunamadı.");
            }
            return kart;
        }
        public BusinesLayerResult<Kart> GetUserById(int id)
        {
            BusinesLayerResult<Kart> res = new BusinesLayerResult<Kart>();
            if (res.Result == null)
            {
                res.AddError(ErrorMessage.UserNotFound, "Kart Bulunamadı.");
            }
            return res;
        }
        public BusinesLayerResult<Kart> ActivateUser(Guid activateId)
        {
            BusinesLayerResult<Kart> res = new BusinesLayerResult<Kart>();
            res.Result = Find(x => x.ActivateGuid == activateId);

            if (res.Result != null)
            {
                if (res.Result.Onay)
                {
                    res.AddError(ErrorMessage.UserAlreadyActive, "Ödeme Alınmıştır.");
                    return res;
                }

                res.Result.Onay = true;
                Update(res.Result);
            }
            else
            {
                res.AddError(ErrorMessage.ActivateIdDoesNotExists, "Onaylanacak Bir Odeme Yoktur.");
            }

            return res;
        }

    }
}
