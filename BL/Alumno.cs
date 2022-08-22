﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Alumno
    { 
        //METODOS CON QUERY
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result(); //Intancia
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Sexo])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Sexo)";
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;
                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = alumno.FechaNacimiento;
                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = alumno.Sexo;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowAffect = cmd.ExecuteNonQuery();
                        if (RowAffect > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct=false;
                            result.ErrorMessage = "Ocurrio un error al insertar el Alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //METODS CON SP
        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result(); //Intancia
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AlumnoAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;
                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = alumno.FechaNacimiento;
                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = alumno.Sexo;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowAffect = cmd.ExecuteNonQuery();
                        if (RowAffect > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al insertar el Alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoGetAll";
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable tableAlumno = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(tableAlumno);

                    if (tableAlumno.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in tableAlumno.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Email = row[4].ToString();

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
