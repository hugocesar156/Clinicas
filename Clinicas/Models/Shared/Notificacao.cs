using System.Collections.Generic;

namespace Clinicas.Models.Shared
{
    public class Notificacao
    {
        public string Alerta { get; set; }
        public string Icone { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public enum Mensagem
        {
            CadastroRealizado,
            FalhaCadastro,
            EdicaoRealizada,
            FalhaEdicao,
            RegistroRemovido,
            FalhaRemocao
        }

        private enum Tipo
        {
            Sucesso,
            Informacao,
            Aviso,
            Falha
        }

        public static Notificacao GerarNotificacao(Mensagem indice)
        {
            switch (ConteudoMensagem[indice].Item1)
            {
                case Tipo.Sucesso:
                    return new Notificacao
                    {
                        Alerta = "alert-success",
                        Icone = "bi-check-circle-fill",
                        Titulo = "Sucesso. ",
                        Descricao = ConteudoMensagem[indice].Item2
                    };

                case Tipo.Falha:
                    return new Notificacao
                    {
                        Alerta = "alert-danger",
                        Icone = "bi-exclamation-circle-fill",
                        Titulo = "Falha. ",
                        Descricao = ConteudoMensagem[indice].Item2
                    };

                default:
                    return new Notificacao();
            }
        }

        private static readonly Dictionary<Mensagem, (Tipo, string)> ConteudoMensagem = new Dictionary<Mensagem, (Tipo, string)>
        {
            {Mensagem.CadastroRealizado, (Tipo.Sucesso, "Cadastro realizado com sucesso.")},
            {Mensagem.FalhaCadastro, (Tipo.Falha, "Ocorreu uma falha durante o cadastro, tente novamenete.")},
            {Mensagem.EdicaoRealizada, (Tipo.Sucesso, "Registro editado com sucesso.")},
            {Mensagem.FalhaEdicao, (Tipo.Falha, "Ocorreu uma falha ao editar registro, tente novamenete.")},
            {Mensagem.RegistroRemovido, (Tipo.Sucesso, "Registro removido com sucesso.")},
            {Mensagem.FalhaRemocao, (Tipo.Falha, "Ocorreu uma falha ao remover registro, tente novamenete.")}
        };
    }
}
