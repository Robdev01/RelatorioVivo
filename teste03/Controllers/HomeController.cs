using System.Diagnostics;
using FastReport.Export.PdfSimple;
using FastReport;
using Microsoft.AspNetCore.Mvc;
using teste03.Models;
using System.IO;
using System.Drawing;

namespace teste03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Cabecalho
            {
                area = "",
                estado = "",
                usuario = "",
                empresa = "",
                inicio = DateTime.Now,
                fim = DateTime.Now,
                envio = DateTime.Now,
                aprovado = "",
                aprovacao = "",
                cod = "",
                numeroATP = "",
                cliente = "",
                endereco = "",
                municipio = "",
                uf = "",
                areaAT = "",
                status = "",
                certi = "",
                valorCert = "",
                valCent = "",
                obsCe = "",
                valCabo = "",
                obsAndarDoCen = "",
                valAndarDoCen = "",
                obsValdenCabo = "",
                img1 = null,
                obsImg1 = "",
                // tela 02
                quantFibra = "",
                img2 = null,
                img3 = null, 
                img4 = null,
                img5 = null,
                // tela03
                img6 = null,
                localLimpo01 = "",
                img7 = null,
                enlaceFribra = "",
                img8 = null,
                comentario01 = "",
                trabalhoRealizado = "",
                obsTrabaReali = "",
                quantCssAberta = "",
                obsCssAberta = "",
                caboUtili = "",
                obsCaboUtili = "",
                capaCaboNestaRede = "",
                obsCaboNestaRede = "",
                quantCaboExistenteReaberEmendas = "",
                img9 = null,
                // tela04
                img11 = null,
                trechoSubFinal ="",
                obsTrechoSubFinal = "",
                metragemCabo = "",
                obsMetragemCabo = "",
                img12 = null,
                limpo2 = "",
                img13 = null,
                img14 = null,
                // tela05
                img15 = null,
                perdaNivelSinal = "",
                obsPerdaNivelSinal = "",
                come01 = "",
                lancamentoCaboCliente = "",
                obsLancamentoCaboCliente = "",
                posicaoFribra = "",
                obsPosicaoFibra = "",
                comen03 = ""
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GerarRelatorioAsync(Cabecalho model)
        {
            ViewBag.Error = null;

            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Alguns campos não foram preenchidos corretamente.";
                return View("Index", model);
            }

            try
            {
                _logger.LogInformation("Recebido formulário para gerar relatório com os seguintes dados: {@Model}", model);

                // Carregar o relatório
                string caminhoRelatorio = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorio\Teste.frx");
                Report report = Report.FromFile(caminhoRelatorio);

                // Configurar os parâmetros do relatório
                report.SetParameterValue("area", model.area);
                report.SetParameterValue("estado", model.estado);
                report.SetParameterValue("usuario", model.usuario);
                report.SetParameterValue("empresa", model.empresa);
                report.SetParameterValue("inicio", model.inicio);
                report.SetParameterValue("fim", model.fim);
                report.SetParameterValue("aprovado", model.aprovado);
                report.SetParameterValue("aprovacao", model.aprovacao);
                report.SetParameterValue("envio", model.envio);
                report.SetParameterValue("cod", model.cod);
                report.SetParameterValue("numeroATP", model.numeroATP);
                report.SetParameterValue("cliente", model.cliente);
                report.SetParameterValue("endereco", model.endereco);
                report.SetParameterValue("municipio", model.municipio);
                report.SetParameterValue("uf", model.uf);
                report.SetParameterValue("areaAT", model.areaAT);
                report.SetParameterValue("status", model.status);
                
                report.SetParameterValue("certi", model.certi);
                report.SetParameterValue("valorCert", model.valorCert);

                
                report.SetParameterValue("valCent", model.valCent);
                report.SetParameterValue("obsCe", model.obsCe);

                report.SetParameterValue("valCabo", model.valCabo);
                report.SetParameterValue("obsAndarDoCen", model.obsAndarDoCen);

                report.SetParameterValue("valAndarDoCen", model.valAndarDoCen);
                report.SetParameterValue("obsValdenCabo", model.obsValdenCabo);

                report.SetParameterValue("obsImg1", model.obsImg1);

                report.SetParameterValue("quantFibra", model.quantFibra);

                // terceira tela
                report.SetParameterValue("localLimpo01", model.localLimpo01);
                report.SetParameterValue("enlaceFribra", model.enlaceFribra);
                report.SetParameterValue("comentario01", model.comentario01);
                report.SetParameterValue("trabalhoRealizado", model.trabalhoRealizado);
                report.SetParameterValue("obsTrabaReali", model.obsTrabaReali);
                report.SetParameterValue("quantCssAberta", model.quantCssAberta);
                report.SetParameterValue("capaCaboNestaRede", model.capaCaboNestaRede);
                report.SetParameterValue("obsCssAberta", model.obsCssAberta);

                report.SetParameterValue("caboUtili", model.caboUtili);
                report.SetParameterValue("obsCaboUtili", model.obsCaboUtili);
                report.SetParameterValue("obsCaboNestaRede", model.obsCaboNestaRede);
                report.SetParameterValue("quantCaboExistenteReaberEmendas", model.quantCaboExistenteReaberEmendas);


                report.SetParameterValue("trechoSubFinal", model.trechoSubFinal);
                report.SetParameterValue("obsTrechoSubFinal", model.obsTrechoSubFinal);
                report.SetParameterValue("metragemCabo", model.metragemCabo);
                report.SetParameterValue("obsMetragemCabo", model.obsMetragemCabo);
                report.SetParameterValue("limpo2", model.limpo2);

                report.SetParameterValue("perdaNivelSinal", model.perdaNivelSinal);
                report.SetParameterValue("obsPerdaNivelSinal", model.obsPerdaNivelSinal);
                report.SetParameterValue("come01", model.come01);
                report.SetParameterValue("lancamentoCaboCliente", model.lancamentoCaboCliente);
                report.SetParameterValue("obsLancamentoCaboCliente", model.obsLancamentoCaboCliente);
                report.SetParameterValue("posicaoFribra", model.posicaoFribra);
                report.SetParameterValue("obsPosicaoFibra", model.obsPosicaoFibra);
                report.SetParameterValue("comen03", model.comen03);

                // Função para processar uma imagem
                async Task ProcessarImagem(IFormFile imagem, string nomeObjeto)
                {
                    if (imagem != null && imagem.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            // Copiar a imagem para o MemoryStream
                            await imagem.CopyToAsync(memoryStream);

                            // Converter a imagem para um array de bytes
                            byte[] imageBytes = memoryStream.ToArray();

                            // Encontrar o objeto de imagem no relatório
                            PictureObject pictureObject = report.FindObject(nomeObjeto) as PictureObject;

                            if (pictureObject != null)
                            {
                                // Limpar a imagem existente e atribuir a nova
                                pictureObject.Image = null;
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    pictureObject.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }

                // Processar cada imagem enviada pelo usuário
                await ProcessarImagem(model.img1, "img10"); // Processar img1
                await ProcessarImagem(model.img2, "img2");
                await ProcessarImagem(model.img3, "img3");
                await ProcessarImagem(model.img4, "img4");

                await ProcessarImagem(model.img5, "img5");

                // terceira tela
                await ProcessarImagem(model.img6, "img6");
                await ProcessarImagem(model.img7, "img7");
                await ProcessarImagem(model.img8, "img8");
                await ProcessarImagem(model.img9, "img9");
                // Quarta tela
                await ProcessarImagem(model.img11, "img11");
                await ProcessarImagem(model.img12, "img12");
                await ProcessarImagem(model.img13, "img13");
                await ProcessarImagem(model.img14, "img14");
                // Quarta tela
                await ProcessarImagem(model.img15, "img15");



                // Preparar o relatório
                report.Prepare();

                // Exportar para PDF
                using var pdfExport = new PDFSimpleExport();
                using var reportStream = new MemoryStream();
                pdfExport.Export(report, reportStream);
                reportStream.Position = 0;

                // Retornar o arquivo PDF como resposta
                return File(reportStream.ToArray(), "application/pdf", "Relatorio.pdf");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao gerar o relatório: {ex.Message}";
                return View("Index", model);
            }
        }
    }
}


