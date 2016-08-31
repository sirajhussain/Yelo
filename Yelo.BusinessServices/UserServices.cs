using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelo.BusinessEntities;
using Yelo.BusinessServices.Interfaces;
using Yelo.DataModel;
using Yelo.DataModel.UnitOfWork;

namespace Yelo.BusinessServices
{
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>  
        /// Public method to authenticate user by user name and word.  
        /// </summary>  
        /// <param name="userName"></param>  
        /// <param name="word"></param>  
        /// <returns></returns>  
        public int Authenticate(string userName, string phoneNumber) {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.PhoneNumber == phoneNumber);
            if (user != null && user.UserId > 0) {  
                return user.UserId;  
            }  
            return 0;  
        }  
        
        /// <summary>
        /// 
        /// </summary>
        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BusinessEntities.UserEntity GetUserById(int userId)
        {
            var user = _unitOfWork.UserRepository.GetByID(userId);
            if (user != null)
            {
                Mapper.CreateMap<User, UserEntity>();
                var userModel = Mapper.Map<User, UserEntity>(user);
                return userModel;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.UserEntity> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            if (users.Any())
            {
                Mapper.CreateMap<User, UserEntity>();
                var usersModel = Mapper.Map<List<User>, List<UserEntity>>(users);
                return usersModel;
            }
            return null; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public int CreateUser(BusinessEntities.UserEntity userEntity)
        {
            //using (var scope = new TransactionScope()) // TODO: Handle transction scope.
            //{
            var user = new User
            {
                UserName = userEntity.UserName,
                PhoneNumber = userEntity.PhoneNumber
            };
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
            //scope.Complete();
            return user.UserId;
            //}  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public bool UpdateUser(int userId, BusinessEntities.UserEntity userEntity)
        {
            var success = false;
            if (userEntity != null)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                var user = _unitOfWork.UserRepository.GetByID(userId);
                if (user != null)
                {
                    user.UserName = userEntity.UserName;
                    user.PhoneNumber = userEntity.PhoneNumber;
                    _unitOfWork.UserRepository.Update(user);
                    _unitOfWork.Save();
                    //scope.Complete();
                    success = true;
                }
                //}
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(int userId)
        {
            var success = false;
            if (userId > 0)
            {
                //using (var scope = new TransactionScope())// TODO: Handle transction scope.
                //{
                var user = _unitOfWork.UserRepository.GetByID(userId);
                if (user != null)
                {

                    _unitOfWork.UserRepository.Delete(user);
                    _unitOfWork.Save();
                    //scope.Complete();
                    success = true;
                }
                //}
            }
            return success; 
        }
    }
}
