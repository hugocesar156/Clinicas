using System.Collections.Generic;

namespace Clinicas.Models.Shared
{
    public class Notificacao
    {
        public string Alerta { get; set; }
        public string Icone { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public enum Tipo
        {
            Sucesso,
            Informacao,
            Aviso,
            Falha
        }

        public enum Entidade
        {
            Plataforma,
            Clinica
        }

        public enum Mensagem 
        {
            //Plataforma
            CadastroRealizado,
            FalhaCadastro,

            //Clínica
            CnpjInvalido
        }


        private static readonly Dictionary<Mensagem, (Tipo, string)> ConteudoMensagem = new Dictionary<Mensagem, (Tipo, string)> 
        {
            //Plataforma
            {Mensagem.CadastroRealizado, (Tipo.Sucesso, "Cadastro realizado com sucesso")},
            {Mensagem.FalhaCadastro, (Tipo.Falha, "Ocorreu uma falha durante o cadastro, tente novamenete.")},

            //Clínica
            {Mensagem.CnpjInvalido, (Tipo.Falha, "CNPJ informado já registrado no sistema.")}
        };

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
    }
}
