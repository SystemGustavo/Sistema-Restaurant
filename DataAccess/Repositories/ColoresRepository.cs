using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Repositories
{
    public class ColoresRepository : RepositoryMaster, IColoresRepository
    {
        private readonly string MostrarColor;
        public ColoresRepository()
        {
            MostrarColor = "MostrarColores";
        }
        public void InsertarColores()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colores> MostrarColores()
        {
            var table = ExecuteReader(MostrarColor);
            if (table.Rows.Count > 0)
            {
                var ListColores = new List<Colores>();
                foreach (DataRow row in table.Rows)
                {
                    ListColores.Add(new Colores
                    {
                        Idcolor = Convert.ToInt32(row[0]),
                        colorhtml = row[1].ToString()
                    });
                }
                return ListColores;
            }
            else
                return null;
        }
    }
}
