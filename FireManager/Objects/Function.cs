﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.Models;

namespace FireManager.Objects
{
    public class Function
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public List<FuncParameter> Parametros { get; set; }

        public void Inicializar()
        {
            Parametros = new List<FuncParameter>();
        }
    }
}
