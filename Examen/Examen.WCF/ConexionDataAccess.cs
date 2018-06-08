using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Examen.WCF
{
    public class ConexionDataAccess
    {
        SqlConnection mConexion;

        public ConexionDataAccess(){
            mConexion = new SqlConnection();
        }

        public string ObtenerConnectionstrings()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Examen"].ConnectionString;    
        }

        private void AbrirConexion(){
            if (!(this.mConexion.State==ConnectionState.Open)) {
                mConexion.ConnectionString = ObtenerConnectionstrings();
                mConexion.Open();
            }
        }

        private void CerrarConexion(){
            if (this.mConexion.State==ConnectionState.Open) {
                mConexion.Close();
            }
        }

        public void ExecuteNonQuery(string procedimiento, ArrayList parametros)
        {
            try
            {
                AbrirConexion();
                SqlCommand mComando = new SqlCommand(procedimiento, mConexion);
                mComando.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }

                mComando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                CerrarConexion();
                throw e;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public DataSet Fill(string procedimiento, ArrayList parametros)
        {
            DataSet mDataSet = new DataSet();

            try
            {
                AbrirConexion();
                SqlCommand mComando = new SqlCommand(procedimiento, mConexion);
                SqlDataAdapter mDataAdapter = new SqlDataAdapter(mComando);

                mComando.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }

                mDataAdapter.Fill(mDataSet);
                return mDataSet;
            }
            catch (Exception e)
            {
                CerrarConexion();
                throw e;
            }
            finally
            {
                CerrarConexion();
            }     
        }

        public object GetScalar(string procedimiento, ArrayList parametros)
        {
            try
            {
                AbrirConexion();
                SqlCommand mComando = new SqlCommand(procedimiento, mConexion);
                mComando.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }

                return mComando.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}