using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Repository;
using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Domain.Mapeador;
using System.Linq;
using Domain.ObjectValues;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class EmpresaModel : MapEmpresaModel, IEmpresaModel
    {
        [DisplayName("Id")]
        public int Id_empresa { get; set; }
        [DisplayName("Empresa")]
        [Required(ErrorMessage = "El nombre de la Empresa es requerido.")]
        public string Nombre_Empresa { get; set; }
        [DisplayName("Imagen")]
        [Required(ErrorMessage = "El Imagen es requerido.")]
        public byte[] Logo { get; set; }
        [DisplayName("Impuesto")]
        [RegularExpression(@"^(?!<< Seleccione Impuesto >>$).*$",
         ErrorMessage = "Seleccione Impuesto")]
        public string Impuesto { get; set; }
        [DisplayName("% Impuesto")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "El % Impuesto debe ser diferente de 0.")]
        public double? Porcentaje_impuesto { get; set; }
        [DisplayName("Moneda")]
        [Required(ErrorMessage = "La Moneda es requerido.")]
        public string Moneda { get; set; }
        [DisplayName("Trabaja con_impuestos")]
        [Required(ErrorMessage = "Trabaja con_impuestos es requerido.")]
        public string Trabajas_con_impuestos { get; set; }
        public string Modo_de_busqueda { get; set; }
        [DisplayName("Carpeta para Copias de Seguridad")]
        [Required(ErrorMessage = "La ruta para la carpeta de seguridad es requerido.")]
        public string Carpeta_para_copias_de_seguridad { get; set; }
        public string Correo_para_envio_de_reportes { get; set; }
        public string Ultima_fecha_de_copia_de_seguridad { get; set; }
        [DisplayName("Ultima Fecha para Copias de seguridad")]
        [Required(ErrorMessage = "La ultima Fecha para copiasde seguridad es requerido.")]
        public DateTime Ultima_fecha_de_copia_date { get; set; }
        public int Frecuencia_de_copias { get; set; }
        public string Estado { get; set; }
        [DisplayName("Pais")]
        [RegularExpression(@"^(?!<< Seleccione un Pais >>$).*$",
         ErrorMessage = "Seleccione un Pais")]
        [Required(ErrorMessage = "El Pais es requerido.")]
        public string Pais { get; set; }
        //[DisplayName("Tipo de Notas")]
        //[Required(ErrorMessage = "El Tipo de Notas es requerido.")]
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
