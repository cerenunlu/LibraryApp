using LibraryApp.DataLayer;
using LibraryApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace LibraryApp.Business
{
    public class BUser
    {
        public static UserDto RegisterRequest(UserDto registerDto)
        {
            using (var uow = new UnitOfWork())
            {
                ENTUser eNT = uow.UserRepository.GetByUsername(registerDto.UserName);

                ENTUser mem = new ENTUser();
                if (eNT == null)
                {
                    mem.Name = registerDto.Name;
                    mem.Surname = registerDto.Surname;
                    mem.UserName = registerDto.UserName;
                    mem.Password = registerDto.Password;

                    uow.UserRepository.Add(mem);
                    registerDto.ID = mem.ID;

                    return registerDto;

                }
                return null;



            }

        }

        public static LoginRequestDto LoginResponse(LoginRequestDto requestDto)
        {

            using (var uow = new UnitOfWork())
            {
                ENTUser EntUser = uow.UserRepository.GetByUsername(requestDto.UserName);

                if (EntUser != null)
                {

                    if (requestDto.Password == EntUser.Password)
                    {
                        LoginRequestDto dto = new LoginRequestDto();

                        dto.UserName = EntUser.UserName;
                        dto.Password = EntUser.Password;

                        return dto;

                    }
                    return null;


                }
                return null;

            }

        }

        public static List<UserDto> GetUserInfo()
        {
            using (var uow = new UnitOfWork())
            {
                List<ENTUser> userList = uow.UserRepository.GetAll().ToList();
                if (userList != null)
                {
                    List<UserDto> userDtoList = new List<UserDto>();
                    foreach (var item in userList)
                    {
                        UserDto userDto = new UserDto()
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Surname = item.Surname,
                            UserName = item.UserName
                        };
                        userDtoList.Add(userDto);
                    }
                    return userDtoList;
                }
                return null;
            }
        }

        public static void DeleteUser(int id)
        {
            using(var uow=new UnitOfWork())
            {
                uow.UserRepository.Remove(id);
            }
        }

        public static void UpdateUser(UserDto userDto)
        {
            using(var uow=new UnitOfWork())
            {
                if(userDto==null || DBNull.Value.Equals(userDto))
                {
                    return;
                }
                else
                {
                    var userInfo = uow.UserRepository.GetByID(userDto.ID);
                    if (userInfo != null & userInfo.ID == userDto.ID)
                    {
                        userInfo.ID = userDto.ID;
                        userInfo.Name = userDto.Name;
                        userInfo.Surname = userDto.Surname;
                        userInfo.UserName = userDto.UserName;
                        userInfo.Password = userDto.Password;
                    }

                    uow.UserRepository.Save(userInfo);
                }
               
            }
        }
    }
}
