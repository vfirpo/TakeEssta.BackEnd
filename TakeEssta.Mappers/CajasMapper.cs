using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TakeEssta.Model;

namespace TakeEssta.Mappers
{
    public class CajasMapper: BaseSQLMapper<Cajas>
    {
        public static PageItems<Cajas> GetCajas(int Sucursal, int PageSize, int CurrentPage)
        {
            string SqlStatement = @"select a.Id, a.FechaApertura, a.FechaCierre, a.IsOpen, a.SucursalId, b.Description as [SucursalDescripcion], 
								a.Turno, a.InicioDeCaja, a.TotalTeoricoDeCaja, a.UserId, (c.FirstName + ' ' + c.LastName) as [UserNombre] 
								from cajas a inner join Sucursales b on a.SucursalId = b.Id inner join Users c on a.UserId = c.Id 
								Where a.SucursalId = @sucursalId order by a.Id DESC OFFSET (@currentPage - 1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY";
            
            string SqlStatement2 = @"select count(*) from cajas Where SucursalId = @sucursalId";

            var rtrnObj = new PageItems<Cajas>();
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    rtrnObj.Items = GetSQL(SqlStatement, new { sucursalId = Sucursal, currentPage = CurrentPage, pageSize = PageSize }, connection); 
                    rtrnObj.RecordCounts = (int)GetValueSQL(SqlStatement2, new { sucursalId = Sucursal });
                    rtrnObj.CurrentPage = CurrentPage;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

			return rtrnObj;

		}

        public static Response<Cajas> GetLastCaja(int sucursalId)
        {
            string SqlStatement = @"select a.Id, a.FechaApertura, a.FechaCierre, a.IsOpen, a.SucursalId, b.Description as [SucursalDescripcion], 
                                a.Turno, a.InicioDeCaja, a.TotalTeoricoDeCaja, a.UserId, (c.FirstName + ' ' + c.LastName) as [UserNombre] 
                                from cajas a inner join Sucursales b on a.SucursalId = b.Id inner join Users c on a.UserId = c.Id 
                                Where a.SucursalId = @sucursalId and a.id = (select max(Id) from cajas where SucursalId = @sucursalId)
                                ORDER BY a.Id DESC";

            var rtrnObj = new Response<Cajas>();
            try
            {
                rtrnObj.Items = GetSQL(SqlStatement, new { sucursalId });
            }
            catch (Exception e)
            {
                rtrnObj.MessageType = MessageType.Error;
                rtrnObj.Message = e.Message;
            }
            return rtrnObj;
        }

        public static Response<Cajas> GetOpen(int sucursalId)
        {
            string SqlStatement = @"select a.Id, a.FechaApertura, a.FechaCierre, a.IsOpen, a.SucursalId, b.Description as [SucursalDescripcion], 
                                a.Turno, a.InicioDeCaja, a.TotalTeoricoDeCaja, a.UserId, (c.FirstName + ' ' + c.LastName) as [UserNombre] 
                                from cajas a inner join Sucursales b on a.SucursalId = b.Id inner join Users c on a.UserId = c.Id 
                                Where a.SucursalId = @sucursalId and a.IsOpen = 1 ORDER BY a.Id DESC";

            var rtrnObj = new Response<Cajas>();
            try
            {
                rtrnObj.Items = GetSQL(SqlStatement, new { sucursalId });
            }
            catch (Exception e)
            {
                rtrnObj.MessageType = MessageType.Error;
                rtrnObj.Message = e.Message;
            }
            return rtrnObj;
        }

        public static bool IsOpen(int sucursalId)
        {
            string SqlStatement = @"select count(*) from cajas a Where a.SucursalId = @sucursalId and a.IsOpen = 1";

            bool rtrnObj = false;
            try
            {
                rtrnObj = Convert.ToBoolean(GetValueSQL(SqlStatement, new { sucursalId }));
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtrnObj;
        }

        public static Response<Cajas> CrearCaja(Cajas caja)
        {
            string SqlStatement2 = @"INSERT INTO Cajas (FechaApertura, IsOpen, SucursalId, Turno, InicioDeCaja, TotalTeoricoDeCaja, UserId)
            VALUES (@FechaApertura, 1, @SucursalId, @Turno, @InicioDeCaja, 0, @UserId)";

            string SqlStatement = @"select count(*) from cajas a Where a.SucursalId = @sucursalId and a.FechaApertura = @FechaApertura 
                                AND a.Turno = @Turno";


            var rtrnObj = new Response<Cajas>();
            try
            {
                using (var connection = new SqlConnection(SqlConn))
                {
                    var count = (int)GetValueSQL(SqlStatement, new
                    {
                        FechaApertura = caja.FechaApertura,
                        SucursalId = caja.SucursalId,
                        Turno = caja.Turno,
                    }, connection);

                    if (count > 0)
                    {
                        rtrnObj.Message = "Ya Existe una caja para el Turno seleccionado";
                        rtrnObj.MessageType = MessageType.Alert;

                        return rtrnObj;
                    }

                    ExecuteSQL(SqlStatement2, new
                    {
                        FechaApertura = caja.FechaApertura,
                        SucursalId = caja.SucursalId,
                        Turno = caja.Turno,
                        InicioDeCaja = caja.InicioDeCaja,
                        UserId = caja.UserId
                    }, connection);

                    rtrnObj = GetLastCaja(caja.SucursalId);
                }
                rtrnObj.MessageType = MessageType.OK;
            }
            catch (Exception e)
            {
                rtrnObj.MessageType = MessageType.Error;
                rtrnObj.Message = e.Message;
            }
            return rtrnObj;
        }

        public static Response<Cajas> GetCajasById(int cajaId)
        {
            string SqlStatement = @"select a.Id, a.FechaApertura, a.FechaCierre, a.IsOpen, a.SucursalId, b.Description as [SucursalDescripcion], 
                                a.Turno, a.InicioDeCaja, a.TotalTeoricoDeCaja, a.UserId, (c.FirstName + ' ' + c.LastName) as [UserNombre] 
                                from cajas a inner join Sucursales b on a.SucursalId = b.Id inner join Users c on a.UserId = c.Id 
                                Where a.Id = @cajaId";

            var rtrnObj = new Response<Cajas>();
            try
            {
                rtrnObj.Items = GetSQL(SqlStatement, new { cajaId });
            }
            catch (Exception e)
            {
                rtrnObj.MessageType = MessageType.Error;
                rtrnObj.Message = e.Message;
            }
            return rtrnObj;
        }

    }
}
