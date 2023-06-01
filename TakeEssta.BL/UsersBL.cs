using TakeEssta.Mappers;
using TakeEssta.Model;

namespace TakeEssta.BL
{
    public class UsersBL
    {
        public static Response<Users> ValidateUser(string user, string password)
        {
            if (user == null) user = "";
            if (password == null) password = "";

            var hashpass = CommonFunctions.GetSHA256(password);
            Users users = UsersMapper.ValidateUser(user, hashpass);

            var rtn = new Response<Users>
            {
                Item = users
            };

            if (users != null)
            {
                rtn.Message = "Usuario recuperado con Exito";
                rtn.MessageType = MessageType.OK;
            }
            else
            {
                rtn.Message = "Usuario o Password no Validos";
                rtn.MessageType = MessageType.Alert;
            }
            return rtn;
        }
    }
}