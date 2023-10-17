using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Repository;
using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Domain.Mapeador;
using System.Linq;
using Domain.ObjectValues;

namespace Domain.Models
{
    public class EmpresaModel : MapEmpresaModel,IEmpresaModel
    {
        public int Id_empresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public byte[] Logo { get; set; }
        public string Impuesto { get; set; }
        public double Porcentaje_impuesto { get; set; }
        public string Moneda { get; set; }
        public string Trabajas_con_impuestos { get; set; }
        public string Modo_de_busqueda { get; set; }
        public string Carpeta_para_copias_de_seguridad { get; set; }
        public string Correo_para_envio_de_reportes { get; set; }
        public string Ultima_fecha_de_copia_de_seguridad { get; set; }
        public DateTime Ultima_fecha_de_copia_date { get; set; }
        public int Frecuencia_de_copias { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Tiponotas { get; set; }

        private IEmpresaRepository IEmpresaRepository;

        public EmpresaModel()
        {
            IEmpresaRepository = new EmpresaRepository();
        }

        public void Add(EmpresaModel model)
        {
            IEmpresaRepository.Add(MapAddEmpresa(model));
        }

        public void Edit(EmpresaModel model)
        {
            IEmpresaRepository.Update(MapUpdateEmpresa(model));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmpresaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmpresaModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditarRespaldo()
        {
            return IEmpresaRepository.EditarRespaldos();
        }
        public List<Paises> ListPaises()
        {
            return new Paises().PaisesGetAll();
        }
        public List<string> ListImpuestos()
        {
            return new Impuesto().Impuestos();

        }
        public List<int> ListValoresImpuestos()
        {
            return new Impuesto().ValoresImpuestos();
        }
    }
}
