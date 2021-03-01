using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class UsersMapper : BaseSQLMapper<Users>
    {
        public static Users ValidateUser(string user, string hashpassword)
        {
            string SqlStatement = @"select a.*, b.* from users a inner join sucursales b on a.sucursalid = b.id
                                where a.NickName = @user and a.PasswordHash = @hashpassword";


            IList<Users> usr;
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    usr = connection.Query<Users, Sucursal, Users>(SqlStatement,
                        (user, sucursal) =>
                        {
                            user.Sucursal = sucursal;
                            return user;
                        }, new { user, hashpassword }, splitOn: "Id").Distinct().ToList();
                    
                    if (usr != null && usr.Count() > 0)
                    {
                        usr[0].Behaviours = BehavioursMapper.GetByUser(usr[0].Id, connection);
                        usr[0].Roles = RolesMapper.GetByUser(usr[0].Id, connection);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return usr.First();
        }
    }

}
