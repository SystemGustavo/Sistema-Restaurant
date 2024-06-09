using DataAccess.Entities;
using Domain.Models;

namespace Domain.Mapeador
{
    public abstract class MapEmpresaModel
    {
        protected Empresa MapAddEmpresa(EmpresaModel objEmpresaModel)
        {
            Empresa objEmpresa = new Empresa()
            {
                Nombre_Empresa= objEmpresaModel.Nombre_Empresa,
                Impuesto = objEmpresaModel.Impuesto,
                Porcentaje_impuesto = objEmpresaModel.Porcentaje_impuesto,
                Moneda = objEmpresaModel.Moneda,
                Trabajas_con_impuestos = objEmpresaModel.Trabajas_con_impuestos,
                Carpeta_para_copias_de_seguridad = objEmpresaModel.Carpeta_para_copias_de_seguridad,
                Ultima_fecha_de_copia_date = objEmpresaModel.Ultima_fecha_de_copia_date,
                Pais = objEmpresaModel.Pais,
                Logo = objEmpresaModel.Logo,
                Tiponotas = objEmpresaModel.Tiponotas
            };
            return objEmpresa;
        }

        protected Empresa MapUpdateEmpresa(EmpresaModel objEmpresaModel)
        {
            Empresa objEmpresa = new Empresa()
            {
                Nombre_Empresa = objEmpresaModel.Nombre_Empresa,
                Impuesto = objEmpresaModel.Impuesto,
                Porcentaje_impuesto = (double)objEmpresaModel.Porcentaje_impuesto,
                Moneda = objEmpresaModel.Moneda,
                Trabajas_con_impuestos = objEmpresaModel.Trabajas_con_impuestos,
                Carpeta_para_copias_de_seguridad = objEmpresaModel.Carpeta_para_copias_de_seguridad,
                Pais = objEmpresaModel.Pais,
                Logo = objEmpresaModel.Logo,
                Tiponotas = objEmpresaModel.Tiponotas
            };
            return objEmpresa;
        }



    }
}
