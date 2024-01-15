using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace VNT_CentralDeNotificacao
{
    partial class VNTServicoEnvioNotificacao : ServiceBase
    {
        public VNTServicoEnvioNotificacao()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Adicione aqui o código para iniciar seu serviço.
        }

        protected override void OnStop()
        {
            // TODO: Adicione aqui o código para realizar qualquer desmontagem necessária para interromper seu serviço.
        }
    }
}
