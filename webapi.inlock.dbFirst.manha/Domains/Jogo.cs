﻿using System;
using System.Collections.Generic;

namespace webapi.inlock.dbFirst.manha.Domains;

public partial class Jogo
{
    public Guid IdJogo { get; set; }

    public Guid? IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime Datalancamento { get; set; }

    public decimal Valor { get; set; }

    public virtual Estudio? IdEstudioNavigation { get; set; }
}
