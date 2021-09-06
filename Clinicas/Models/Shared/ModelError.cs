namespace Clinicas.Models.Shared
{
    public class ModelError
    {
        public class Geral
        {
            public const string CampoObrigatorio = "Campo obrigatório";
            public const string CampoInvalido = "Valor inválido para o campo";
        }

        public class Clinica 
        {
            public const string CnpjInvalido = "CNPJ informado já registrado no sistema.";
        }

        public class Usuario
        {
            public const string EmailEmUso = "Endereço de email já está em uso.";
            public const string ConfirmaSenha = "Falha ao confirmar senha.";
        }
    }
}
