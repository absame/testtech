using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;

namespace Examen.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService
    {
        public List<Cliente> ObtenerCliente()
        {
            ConexionDataAccess dac = new ConexionDataAccess();
            List<Cliente> personas = new List<Cliente>();
            ArrayList parametros = new ArrayList();

            try
            {
                DataSet ds = dac.Fill("spSelCliente", parametros);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        personas.Add(new Cliente()
                        {
                            ClienteId = Int32.Parse(row["ClienteId"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                            Telefono = row["Telefono"].ToString(),
                            Email = row["Email"].ToString()
                        });     
                    }
                }

                return personas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GuardarCliente(Cliente cliente)
        {
            ConexionDataAccess dac = new ConexionDataAccess();
            ArrayList parametros = null;
            try
            {
                if (cliente != null)
                {

                    parametros = new ArrayList();

                    //PARAMETROS DE ENTRADA
                    parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = cliente.Nombre });
                    parametros.Add(new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = cliente.ApellidoPaterno });
                    parametros.Add(new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = cliente.ApellidoMaterno});
                    parametros.Add(new SqlParameter { ParameterName = "@Telefono", SqlDbType = SqlDbType.VarChar, Value = cliente.Telefono });
                    parametros.Add(new SqlParameter { ParameterName = "@Email", SqlDbType = SqlDbType.VarChar, Value = cliente.Email });

                    dac.ExecuteNonQuery("spInsCliente", parametros);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EliminarCliente(int p_ClienteId)
        {
            ConexionDataAccess dac = new ConexionDataAccess();
            ArrayList parametros = null;
            try
            {
                parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@ClienteId", SqlDbType = SqlDbType.Int, Value = p_ClienteId });
                dac.ExecuteNonQuery("spDelCliente", parametros);
                return true;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
