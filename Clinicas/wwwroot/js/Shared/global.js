$(document).ready(function () {
    $('.celular').mask('00 00000-0000');
    $('.cep').mask('00000-000');
    $('.cnpj').mask('00.000.000/0000-00');
    $('.cpf').mask('000.000.000-00');
    $('.rg').mask('00.000.000-0');
})

function BuscarEndereco(cep) {
    cep = cep.replace('-', '');

    if (cep.length === 8) {
        var url = `https://viacep.com.br/ws/${cep}/json/?callback=?`;

        $.getJSON(url, function (endereco) {
            if (!('erro' in endereco)) {
                $('#logradouro').val(endereco.logradouro);
                $('#bairro').val(endereco.bairro);
                $('#cidade').val(endereco.localidade);
                $('#uf').val(endereco.uf);
            }
        });
    }
}