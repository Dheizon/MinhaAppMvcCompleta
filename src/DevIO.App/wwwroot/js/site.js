function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $("form", dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }

    });
}

function BuscaCep() {
    let cepAnterior = "";
    $(document).ready(function () {
        function limpa_formulario_cep() {
            $(".cep").val("");
            $(".logradouro").val("");
            $(".bairro").val("");
            $(".cidade").val("");
            $(".uf").val("");
            $(".ibge").val("");
            $(".siafi").val("");
        }

        $(".cep").focus(function () {
            cepAnterior = $(this).val().replace(/\D/g, '');
        });

        $(".cep").blur(function () {
            var cep = $(this).val().replace(/\D/g, '');

            if (cep === cepAnterior) {
                return;
            }

            if (cep !== "") {
                var validacep = /^[0-9]{8}$/;

                if (validacep.test(cep)) {
                    $(".logradouro").val("...");
                    $(".bairro").val("...");
                    $(".cidade").val("...");
                    $(".uf").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {
                            console.log(dados);
                            if (!("erro" in dados)) {
                                $(".logradouro").val(dados.logradouro);
                                $(".bairro").val(dados.bairro);
                                $(".cidade").val(dados.localidade);
                                $(".uf").val(dados.uf);
                                $(".ibge").val(dados.ibge);
                                $(".siafi").val(dados.siafi);
                            } else {
                                limpa_formulario_cep();
                                alert("CEP não encontrado");
                                $(".cep").focus();
                            }
                        });
                } else {
                    limpa_formulario_cep();
                    alert("Formato do CEP inválido.");
                }
            } else {
                limpa_formulario_cep();
            }
        })

    })
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
})