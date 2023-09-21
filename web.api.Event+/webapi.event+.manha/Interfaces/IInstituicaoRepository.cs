﻿using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicao);

        void Deletar(Guid id);

        List<TiposEvento> Listar();

        TiposEvento BuscarPorID(Guid id);

        void Atualizar(Guid id, Instituicao instituicao);
    }
}
