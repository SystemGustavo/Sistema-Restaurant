using Domain.Models;
using Presentation.Presenter;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //IIniciarSesionView view = new FrmIniciarSesion();
            //new IniciarSesionPresenter(view, new UsuariosModel(),
            //                                 new MovimientoDeCajaModel(),
            //                                 new CajasModel(),
            //                                 new InicioDeSesionModel());

            //IUsuariosView view = new FrmUsuarios();
            //new UsuariosPresenter(view, new UsuariosModel(),
            //                            new ModulosModel(),
            //                            new PermisosModel(),
            //                            new IniciosDeSesionModel(),
            //                            new CajasModel());

            //IAperturaDeCajaView view = new FrmAperturaDeCaja();
            //new AperturarCajaPresenter(view, new MovimientoDeCajaModel(),new CajasModel());


            IEmpresaView view = new FrmEmpresa();
            new EmpresaPresenter(view, new EmpresaModel());

            Application.Run((Form)(view));
        }
    }
}
