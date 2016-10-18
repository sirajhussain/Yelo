using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Yelo.BusinessEntities;
using Yelo.BusinessServices.Interfaces;
using Yelo.DataModel;
using Yelo.DataModel.UnitOfWork;

namespace Yelo.BusinessServices
{
    public class TokenServices : ITokenServices
    {
        private readonly UnitOfWork _unitOfWork;

        public TokenServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            //DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble(WebConfigurationManager.AppSettings["AuthTokenExpiry"]));
            DateTime expiredOn = DateTime.Now.AddSeconds(9000);
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            _unitOfWork.TokenRepository.Insert(tokendomain);
            _unitOfWork.Save();
            var tokenModel = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }


        // Valid forever.
        public bool ValidateToken(string tokenId)
        {
            var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId);
            if (token != null)
            {
                //_unitOfWork.TokenRepository.Update(token);
                //_unitOfWork.Save();
                return true;
            }
            return false;
        }

        //public bool ValidateToken(string tokenId)
        //{
        //    var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
        //    if (token != null && !(DateTime.Now > token.ExpiresOn))
        //    {
        //        //token.ExpiresOn = token.ExpiresOn.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
        //        token.ExpiresOn = token.ExpiresOn.AddSeconds(Convert.ToDouble(900));
        //        _unitOfWork.TokenRepository.Update(token);
        //        _unitOfWork.Save();
        //        return true;
        //    }
        //    return false;
        //}

        public bool Kill(string tokenId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            if (isNotDeleted)
            {
                return false;
            }
            return true;
        }

        public bool DeleteByUserId(int userId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            _unitOfWork.Save();

            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            return !isNotDeleted;
        }
    }
}
